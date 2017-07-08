<template>
    <form>
      <input v-for="d in data" :key="d.name" :name="d.name" type="hidden" :value="d.value"> 
    </form>
</template>
<script>
  export default {
    data() {
      return {
        url: '',
        datos: []
      }
    },
    methods: {
      submit: function() {
        this.checked = !this.checked;
      }
    }
  }
</script>