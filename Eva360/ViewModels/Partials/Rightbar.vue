<template>
    <aside id="rightbar-vue" :class="{active}">
        <div id="right-mask" @click="cerrar"></div>
        <div id="right-wrapper" class="section">
            <div class="container is-paddingless width-auto">
                <div class="columns">
                    <div class="column is-12">
                        <button id="right-close" class="delete is-danger is-medium is-pulled-right" @click="cerrar"></button>
                        <slot></slot> 
                    </div>
                </div>
            </div>
        </div>
    </aside>
</template>

<script>
export default {
    data: function() {
        return {
            active: false
        }
    },
    methods: {
        mostrar: function() {
            this.active = true;
        },
        cerrar: function() {
            this.active = false;
        }
    },
    created: function() {
        bus.$on('FinRegistroEdicion', this.cerrar);
        bus.$on('RegistrarUsuario', this.mostrar);
        bus.$on('EditarUsuario', this.mostrar);
    }
}
</script>

