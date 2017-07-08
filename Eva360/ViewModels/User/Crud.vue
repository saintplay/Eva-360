<template>
    <div class="column is-10 is-offset-1 padding-20">
        <div class="columns">
            <div class="column">
                <h2 class="title is-3">Lista de Usuarios</h2>
            </div>
            <div class="column">
                <button class="button is-success is-pulled-right" @click="nuevo()">Agregar</button>
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
                        <td>{{ parseFormatNetDate(usuario.FechaNacimiento) }}</td>
                        <td>{{ getGenero(usuario.Sexo) }}</td>
                        <td>
                            <strong>{{ getTipoDocumentoSigla(usuario.TipoDocumentoId) }}</strong><br />
                            <span>{{ usuario.NroDocumento }}</span>
                        </td>
                        <td><button class="button is-warning" @click="editar(usuario)">Editar</button></td>
                        <td><button class="button is-danger">Eliminar</button></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
    const netdate = require("./../Partials/RegexSamples").netdate;
    const moment = require("moment");
    const axios = require("axios");

    export default {
        data: function() {
            return {
                errores: [],
                usuarios: [],
                tipodocumentos: [],
                roles: []
            }
        },
        created: function() {
            this.fetchData();
        },
        methods: {
            fetchData: function() {
                var vm = this;
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
            nuevo: function() {
                rightbar.datos = {
                    titulo: "Agregar Usuario",
                    tipodocumentos: this.tipodocumentos,
                    usuario: {
                        Nombre: '',
                        Apellido: '',
                        Codigo: '',
                        Email: '',
                        FechaNacimiento: moment().add(-20, 'years').format("YYYY-MM-DD"),
                        TipoDocumentoId: this.tipodocumentos[0] ? this.tipodocumentos[0].TipoDocumentoId : 0,
                        Sexo: 'M',
                        NroDocumento: ''
                    }
                };
                rightbar.mostrar();
                rightbar.componente_activo = "crud-usuario";
            },
            editar: function(usuario) {
                var usuario_clone = _.clone(usuario);
                usuario_clone.FechaNacimiento = this.parseNetDate(usuario.FechaNacimiento);
                rightbar.datos = {
                    tipodocumentos: eva360.tipodocumentos,
                    titulo: "Editar Usuario",
                    usuario: usuario_clone
                };
                rightbar.mostrar();
                rightbar.componente_activo = "crud-usuario";
            },
            eliminar: function(usuario) {

            },
            getGenero: function(sexo) {
                return sexo == "F" ? "Mujer" : sexo == "M" ? "Hombre" : "-";
            },
            getTipoDocumentoSigla: function (TipoDocumentoId) {
                return this.tipodocumentos.find(t => t.TipoDocumentoId == TipoDocumentoId).Sigla;
            },
            ocultarError: function(index) {
                this.errores.splice(index, 1);
            },
            parseNetDate: function (date) {
                var timestamp = date.replace(netdate, "$1");
                return moment(parseInt(timestamp)).format("YYYY-MM-DD");
            },
            parseFormatNetDate: function (date) {
                var timestamp = date.replace(netdate, "$1");
                return moment(parseInt(timestamp)).format("DD-MM-YYYY");
            }
        }
    }
</script>