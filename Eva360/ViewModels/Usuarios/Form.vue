<template>
<div>
    <h1 class="title">{{ titulo }}</h1>
    <form id="rightbar-form" class="form">
        <input name="UsuarioId" type="hidden" v-model.number="usuario.UsuarioId">
        <div class="field is-narrow">
            <label class="label">Nombre</label>
            <p class="control is-expanded">
                <input name="Nombre" class="input" type="text" v-model.trim="usuario.Nombre">
            </p>
        </div>
        <div class="field is-narrow">
            <label class="label">Apellido</label>
            <p class="control is-expanded">
                <input name="Apellido" class="input" type="text" v-model.trim="usuario.Apellido">
            </p>
        </div>
        <div v-if="usuario_nuevo" class="field is-narrow">
            <label class="label">Password</label>
            <p class="control is-expanded">
                <input name="Password" class="input" type="password" v-model.trim="usuario.Password">
            </p>
        </div>
        <div v-if="usuario_nuevo" class="field is-narrow">
            <label class="label">Codigo</label>
            <p class="control is-expanded">
                <input name="Codigo" class="input" type="text" v-model.trim="usuario.Codigo">
            </p>
        </div>
        <div class="field is-narrow">
            <label class="label">Email</label>
            <p class="control is-expanded">
                <input name="Email" class="input" type="email" v-model.trim="usuario.Email">
            </p>
        </div>
        <div class="field is-narrow">
            <label class="label">Fecha de Nacimiento</label>
            <p class="control is-expanded">
                <input name="FechaNacimiento" class="input" type="date" v-model="usuario.FechaNacimiento">
            </p>
        </div>
        <div class="field is-narrow">
            <label class="label">Sexo</label>
            <p class="control is-expanded">
                <span class="select">
                    <select name="Sexo" v-model="usuario.Sexo">
                        <option value="M">Hombre</option>
                        <option value="F">Mujer</option>
                    </select>
                </span>
            </p>
        </div>
        <div v-if="usuario_nuevo" class="field is-narrow">
            <label class="label">Rol</label>
            <p class="control is-expanded">
                <span class="select">
                    <select name="Rol" v-model="usuario.Rol">
                        <option v-for="rol in roles" :value="rol" :key="rol">{{ toCapitalCase(rol) }}</option>
                    </select>
                </span>
            </p>
        </div>
        <label class="label">Documento de Indentidad</label>
        <div class="field is-grouped">
            <p class="control">
                <span class="select">
                    <select name="TipoDocumentoId" v-model.number="usuario.TipoDocumentoId">
                        <option v-for="t in tipodocumentos" :value="t.TipoDocumentoId" :key="t.TipoDocumentoId">{{t.Sigla}}</option>
                    </select>
                </span>
            </p>
            <p class="control is-expanded">
                <input name="NroDocumento" class="input" type="text" v-model.trim="usuario.NroDocumento">
            </p>
        </div>
        <div class='field'>
            <div class='control'>
                <a class="button is-primary" @click="actualizar()">
                    <span class="icon"><i class="fa fa-plus"></i></span>
                    <span class="submit-text">Guardar</span>
                </a>
            </div>
        </div>
    </form>
</div>
</template>

<script>
// Librerias
const axios = require("axios");
const moment = require('moment');
const serialize = require('form-serialize');

// Helpers
const toCapitalCase = require('./../Helpers/Converters').toCapitalCase;

function cargarDatosPorDefecto() {
    return {
        titulo: 'Registrar',
        usuario_nuevo: true,
        usuario: {
            Nombre: '',
            Apellido: '',
            Codigo: '',
            Email: '',
            FechaNacimiento: moment().add(-20, 'years').format("YYYY-MM-DD"),
            Rol: "EMPLEADO",
            TipoDocumentoId: 1,
            Sexo: 'M',
            NroDocumento: ''
        }
    }
}


export default {
    props: ['roles', 'tipodocumentos'],
    data: function() {
        return cargarDatosPorDefecto();
    },
    created: function(){
        let vm = this;
        bus.$on('RegistrarUsuario', this.cargarDatosPorDefecto);
        bus.$on('EditarUsuario', this.cargarDatosUsuario);
    },
    methods: {
        cargarDatosPorDefecto: function() {
            let datosDefecto = cargarDatosPorDefecto();
            for (let prop in datosDefecto) {
                this[prop] = datosDefecto[prop];
            }
        },
        cargarDatosUsuario: function(usuario_clone) {
            this.titulo = 'Editar Usuario',
            this.usuario = usuario_clone,
            this.usuario_nuevo = false
        },
        actualizar: function () {
            let vm = this;
            let form = document.getElementById('rightbar-form');
            let datos_serializados = serialize(form);

            if (vm.usuario.UsuarioId) { // Editar
                axios({
                    method: "POST",
                    url: '/Usuario/ActualizarUsuario',
                    data: datos_serializados
                })
                .then(function (response) {
                    bus.$emit('UsuariosUpdates', response.data.usuarios);
                    bus.$emit('TipoDocumentosUpdates', response.data.tipodocumentos);
                    bus.$emit('FinRegistroEdicion');
                })
                .catch(function (error) {
                    if (error.response.data.errores) {
                        eva360.errores.push(...error.response.data.errores);
                    }
                    else {
                        eva360.errores.push(error.message);
                    }

                    bus.$emit('FinRegistroEdicion');
                });
            }
            else { // Crear
                axios({
                    method: "POST",
                    url: '/Usuario/ActualizarUsuario', 
                    data: datos_serializados
                })
                .then(function (response) {
                    bus.$emit('UsuariosUpdates', response.data.usuarios);
                    bus.$emit('TipoDocumentosUpdates', response.data.tipodocumentos);
                    bus.$emit('FinRegistroEdicion');
                })
                .catch(function (error) {
                    if (error.response.data.errores) {
                        eva360.errores.push(...error.response.data.errores);
                    }
                    else {
                        eva360.errores.push(error.message);
                    }

                    bus.$emit('FinRegistroEdicion');
                });
            }
        },
        toCapitalCase
    }
}
</script>
