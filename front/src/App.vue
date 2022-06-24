<template>
  <v-app>
    <div id="app">
      <h1>HI</h1>
      <TesteIntegracao />
    </div>
  </v-app>
</template>


<script>
import TesteIntegracao from './components/TesteIntegracao.vue'

export default {
  name: 'App',
  components: {
    TesteIntegracao
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
