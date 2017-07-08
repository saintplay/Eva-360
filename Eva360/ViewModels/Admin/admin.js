var Vue = require('vue/dist/vue.js');
const VueRouter = require("vue-router");
Vue.use(VueRouter);

var Dashboard = require("./AdminDash.vue");
var Crud = require("./../User/Crud.vue");

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
            component: Crud
        }
    ]
});

window.eva360 = new Vue({
    router
}).$mount('#app')