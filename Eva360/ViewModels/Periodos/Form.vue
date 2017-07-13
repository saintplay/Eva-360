<template>
    <div>
        <button id="right-close" class="delete is-danger is-medium is-pulled-right" @click="$emit('close')"></button>
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
                            <option v-for="rol in roles" :value="rol" :key="rol">{{ rol }}</option>
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
export default {
    props: ['roles', 'tipodocumentos'],
    data: function() {
        return {
            usuario_nuevo,
            usuario,
            titulo
        }
    },
    methods: {
        actualizar: function () {
            var vm = this;

            if (vm.usuario.UsuarioId) { // Editar
                var $form = $('#rightbar-form');
                var datos_serializados = $form.serialize();

                axios({
                    method: "POST",
                    url: '/Usuario/ActualizarUsuario',
                    data: datos_serializados
                })
                .then(function (response) {
                    eva360.usuarios = response.data.usuarios;
                    eva360.tipodocumentos = response.data.tipodocumentos;
                    rightbar.cerrar();
                })
                .catch(function (error) {
                    if (error.response.data.errores) {
                        eva360.errores.push(...error.response.data.errores);
                    }
                    else {
                        eva360.errores.push(error.message);
                    }

                    rightbar.cerrar();
                });
            }
            else { // Crear
                var $form = $('#rightbar-form');
                var datos_serializados = $form.serialize();

                axios({
                    method: "POST",
                    url: '/Usuario/ActualizarUsuario', 
                    data: datos_serializados
                })
                .then(function (response) {
                    eva360.usuarios = response.data.usuarios;
                    eva360.tipodocumentos = response.data.tipodocumentos;
                    rightbar.cerrar();
                })
                .catch(function (error) {
                    if (error.response.data.errores) {
                        eva360.errores.push(...error.response.data.errores);
                    }
                    else {
                        eva360.errores.push(error.message);
                    }

                    rightbar.cerrar();
                });
            }
        }
    }
}
</script>
