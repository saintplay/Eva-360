<template>
<div class="column is-10 is-offset-1 padding-20">
    <div class="columns">
        <div class="column">
            <h2 class="title is-3">Lista de Usuarios</h2>
        </div>
        <div class="column">
            <button class="button is-success is-pulled-right" @click="nuevo">Registrar</button>
        </div>
    </div>
    <div class="columns">
        <div class="column">
            <table class="table">
                <tr>
                    <th>Nombre</th>
                    <th>Codigo</th>
                    <th>Email</th>
                    <th>F. Nac</th>
                    <th>Sexo</th>
                    <th>Doc. Indentidad</th>
                    <th colspan="2">Acciones</th>
                </tr>
                <tr v-for="(usuario, index) in usuarios" :key="usuario.UsuarioId">
                    <td>{{ usuario.Nombre + " " + usuario.Apellido }}</td>
                    <td>{{ usuario.Codigo }}</td>
                    <td>{{ usuario.Email }}</td>
                    <td>{{ parseFormatDate(usuario.FechaNacimiento) }}</td>
                    <td>{{ getGenero(usuario.Sexo) }}</td>
                    <td>
                        <strong>{{ getTipoDocumentoSigla(usuario.TipoDocumentoId) }}</strong><br />
                        <span>{{ usuario.NroDocumento }}</span>
                    </td>
                    <td><button class="button is-warning" @click="editar(usuario)">Editar</button></td>
                </tr>
            </table>
        </div>
    </div>
    <rightbar>
        <formulario :roles="roles" :tipodocumentos="tipodocumentos"></formulario>
    </rightbar>
</div>
</template>

<script>
// Librerias
const axios = require("axios");
const clone = require("clone");

// Funciones
const parseDate = require('./../Helpers/NetParsing').parseDate;
const parseFormatDate = require('./../Helpers/NetParsing').parseFormatDate;
const getGenero = require('./../Helpers/Converters').getGenero;

// Componentes
const Rightbar = require('./../Partials/Rightbar.vue');
const Formulario = require('./Form.vue');

export default {
    data: function() {
        return {
            errores: [],
            usuarios: [],
            tipodocumentos: [],
            roles: [],
        }
    },
    created: function() {
        this.fetchData();
        bus.$on('UsuariosUpdates', this.updateUsuarios);
        bus.$on('TipoDocumentosUpdates', this.updateTipoDocumentos);
    },
    methods: {
        fetchData: function() {
            let vm = this;
            axios.get('/Usuario/ListarUsuario')
                .then(function (response) {
                    vm.usuarios = response.data.usuarios;
                    vm.tipodocumentos = response.data.tipodocumentos;
                    vm.roles = response.data.roles;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        updateUsuarios: function(nuevos_usuarios) {
            this.usuarios = nuevos_usuarios;
        },
        updateTipoDocumentos: function(nuevos_tipodocumentos) {
            this.tipodocumentos = nuevos_tipodocumentos;
        },
        nuevo: function() {
            bus.$emit('RegistrarUsuario');
        },
        editar: function(usuario) {
            let usuario_clone = clone(usuario);
            usuario_clone.FechaNacimiento = this.parseDate(usuario.FechaNacimiento);
            bus.$emit('EditarUsuario', usuario_clone);
        },
        getTipoDocumentoSigla: function (TipoDocumentoId) {
            return this.tipodocumentos.find(t => t.TipoDocumentoId == TipoDocumentoId).Sigla;
        },
        ocultarError: function(index) {
            this.errores.splice(index, 1);
        },
        getGenero,
        parseDate,
        parseFormatDate
    },
    components: {
        formulario: Formulario,
        rightbar: Rightbar
    }
}
</script>