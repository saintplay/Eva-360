var Vue = require('vue/dist/vue.js');

const eva360 = new Vue({
    el: '#app',
    data: {
        Error: window.errorfromcontroller,
        Usuario: '',
        Password: '',
    }
});