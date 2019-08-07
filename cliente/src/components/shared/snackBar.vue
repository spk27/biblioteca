<template>
  <!-- <v-alert dismissible :value="true" error icon="warning" outline>
    {{ message }}
  </v-alert> -->
  <v-snackbar v-if="snackbar" v-model="snackbar.show" :top="snackbar.pos === 'top'" :bottom="snackbar.pos === 'bottom'" :timeout="snackbar.timeout" vertical>
    {{ snackbar.message }}
    <v-btn :color="snackbar.type" flat @click="closeSnackBar" >
      Cerrar
    </v-btn>
  </v-snackbar>
</template>
<script>
export default {
  name: 'snackBar',
  data: () => ({
  }),
  computed: {
    snackbar () {
      return this.$store.getters.snackbar
    }
  },
  methods: {
    closeSnackBar () {
      this.$store.dispatch('clearSnackBar')
    }
  }
}
</script>