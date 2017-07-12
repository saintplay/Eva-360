var Vue = require('vue/dist/vue.js');
const VueRouter = require("vue-router");
Vue.use(VueRouter);

var Dashboard = require("./AdminDash.vue");
var CrudUsuarios = require("./../Usuarios/Crud.vue");
var CrudPeriodos = require("./../Periodos/Crud.vue");

var router = new VueRouter({
    history: true,
    routes: [
        {
            path: '/',
            component: Dashboard
        },
        {
            path: '/Usuarios',
            props: true,
            component: CrudUsuarios
        },
        {
            path: '/Periodos',
            props: true,
            component: CrudPeriodos
        }
    ]
});

window.eva360 = new Vue({
    router
}).$mount('#app')