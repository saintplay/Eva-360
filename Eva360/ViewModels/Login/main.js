var Vue = require('vue/dist/vue.js');
var MyCheckbox = require('./Checkbox.vue');

const v = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue.js!'
    },
    components: {
        'my-checkbox': MyCheckbox
    }
});