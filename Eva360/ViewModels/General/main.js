var Vue = require('vue/dist/vue.js');
var QuickForm = require('vue/dist/vue.js');

Vue.component("quick-form", QuickForm);

const eva360 = new Vue({
    el: '#navbar-vue',
    data: {
        message: 'Hola'
    }
});