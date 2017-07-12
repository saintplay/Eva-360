<template>
    <div class="column is-10 is-offset-1 padding-20">
        <div class="columns">
            <div class="column">
                <h2 class="title is-3">Lista de Periodos</h2>
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
                        <th>Estado</th>
                        <th>Fecha Inicio</th>
                        <th>Fecha Fin</th>
                        <th colspan="2">Acciones</th>
                    </tr>
                    <tr v-for="(periodo, index) in periodos" :key="periodo.PeriodoId">
                        <td>{{ periodo.Nombre }}</td>
                        <td>{{ getEstadoPeriodo(periodo.Estado) }}</td>
                        <td>{{ parseFormatNetDate(periodo.FechaInicio) }}</td>
                        <td>{{ parseFormatNetDate(periodo.FechaFin) }}</td>
                        <td><button class="button is-warning" @click="editar(periodo)">Editar</button></td>
                        <td><button class="button is-danger">Eliminar</button></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</template>


<script>
    const axios = require('axios');
    const parseDate = require('./../Helpers/NetParsing').parseDate;
    const parseFormatDate = require('./../Helpers/NetParsing').parseFormatDate;

    export default {
        data: function() {
            return {
                errores: [],
                periodos: []
            }
        },
        created: function() {
            this.fetchData();
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
            getEstadoPeriodo: function (estado) {
                switch (estado) {
                    case 'ACT':
                        return "Activo";
                    case 'INA':
                        return "Inactivo";
                }
            },
            parseNetDate: parseDate,
            parseFormatNetDate: parseFormatDate
        }
    };
</script>