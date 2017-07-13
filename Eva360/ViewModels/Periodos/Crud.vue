<template>
<div class="column is-10 is-offset-1 padding-20">
    <div class="columns">
        <div class="column">
            <h2 class="title is-3">Lista de Periodos</h2>
        </div>
        <div class="column">
            <button class="button is-success is-pulled-right" @click="nuevo">Agregar</button>
        </div>
    </div>
    <div class="columns">
        <div class="column">
            <table class="table">
                <tr>
                    <th>Nombre</th>
                    <th>Estado</th>
                    <th>Fecha Inicio</th>
                    <th>Fecha Fin</th>
                    <th colspan="2">Acciones</th>
                </tr>
                <tr v-for="(periodo, index) in periodos" :key="periodo.PeriodoId">
                    <td>{{ periodo.Nombre }}</td>
                    <td>{{ getEstadoPeriodo(periodo.Estado) }}</td>
                    <td>{{ parseFormatDate(periodo.FechaInicio) }}</td>
                    <td>{{ parseFormatDate(periodo.FechaFin) }}</td>
                    <td><button class="button is-warning" @click="editar(periodo)">Editar</button></td>
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
const axios = require('axios');
const clone = require('clone');

// Helpers
const parseDate = require('./../Helpers/NetParsing').parseDate;
const parseFormatDate = require('./../Helpers/NetParsing').parseFormatDate;
const getEstadoPeriodo = require('./../Helpers/Converters').getEstadoPeriodo;

// Componentes
const Rightbar = require('./../Partials/Rightbar.vue');
const Formulario = require('./Form.vue');

export default {
    data: function() {
        return {
            errores: [],
            periodos: []
        }
    },
    created: function() {
        this.fetchData();
        bus.$on('PeriodosUpdates', this.updatePeriodos);
    },
    methods: {
        fetchData: function() {
            var vm = this;
            axios.get('/Periodo/ListarPeriodos')
                .then(function (response) {
                    vm.periodos = response.data.periodos;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        updatePeriodos: function(periodos) {
            this.periodos = periodos;
        },
        nuevo: function() {
            bus.$emit('RegistrarPeriodo');
        },
        editar: function(periodo) {
            let periodo_clone = clone(periodo);
            periodo_clone.FechaInicio = this.parseDate(periodo.FechaInicio);
            periodo_clone.FechaFin = this.parseDate(periodo.FechaFin);
            bus.$emit('EditarPeriodo', periodo_clone);
        },
        getEstadoPeriodo,
        parseDate,
        parseFormatDate
    },
    components: {
        formulario: Formulario,
        rightbar: Rightbar
    }
};
</script>