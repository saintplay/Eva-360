<template>
<div>
    <h1 class="title">{{ titulo }}</h1>
    <form id="rightbar-form" class="form">
        <input name="PeriodoId" type="hidden" v-model.number="periodo.PeriodoId">
        <div class="field is-narrow">
            <label class="label">Nombre</label>
            <p class="control is-expanded">
                <input name="Nombre" class="input" type="text" v-model.trim="periodo.Nombre">
            </p>
        </div>
        <div class="field is-narrow">
            <label class="label">Estado</label>
            <p class="control is-expanded">
                <span class="select">
                    <select name="Estado" v-model="periodo.Estado">
                        <option value="ACT">Activo</option>
                        <option value="INA">Inactivo</option>
                    </select>
                </span>
            </p>
        </div>
        <div class="field is-narrow">
            <label class="label">Fecha de Inicio</label>
            <p class="control is-expanded">
                <input name="FechaInicio" class="input" type="date" v-model="periodo.FechaInicio">
            </p>
        </div>
        <div class="field is-narrow">
            <label class="label">Fecha de Fin</label>
            <p class="control is-expanded">
                <input name="FechaFin" class="input" type="date" v-model="periodo.FechaFin">
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

// Mixins
const rightbarformmixin = require('./../Mixins/RightBarForm').rightbarformmixin;

function cargarDatosPorDefecto() {
    return {
        titulo: "Agregar Periodo",
        periodo: {
            Nombre: '',
            Estado: 'ACT',
            FechaInicio: moment().format("YYYY-MM-DD"),
            FechaFin: moment().add(1, 'years').format("YYYY-MM-DD")
        }
    }
}

export default {
    props: ['roles', 'tipodocumentos'],
    data: function() {
        return cargarDatosPorDefecto();
    },
    created: function(){
        bus.$on('RegistrarPeriodo', this.cargarDatosPorDefecto);
        bus.$on('EditarPeriodo', this.cargarDatosPeriodo);
    },
    methods: {
        cargarDatosPorDefecto: function() {
            let datosDefecto = cargarDatosPorDefecto();
            for (let prop in datosDefecto) {
                this[prop] = datosDefecto[prop];
            }
        },
        cargarDatosPeriodo: function(periodo_clone) {
            this.titulo = 'Editar Periodo';
            this.periodo = periodo_clone;
        },
        actualizar: function () {
            let vm = this;
            let form = document.getElementById('rightbar-form');
            let datos_serializados = serialize(form);

            if (vm.periodo.PeriodoId) { // Editar
                axios({
                    method: "POST",
                    url: '/Periodo/ActualizarPeriodo',
                    data: datos_serializados
                })
                .then(function (response) {
                    bus.$emit('PeriodosUpdates', response.data.periodos);
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
                    url: '/Periodo/ActualizarPeriodo', 
                    data: datos_serializados
                })
                .then(function (response) {
                    bus.$emit('PeriodosUpdates', response.data.periodos);
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
        }
    }
}
</script>