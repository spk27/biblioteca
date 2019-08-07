<template>
<v-dialog v-model="loading" persistent width="300">
  <v-card color="success" dark>
    <v-card-text>
      Procesando..
      <v-progress-linear indeterminate color="white" class="mb-0" ></v-progress-linear>
    </v-card-text>
  </v-card>
  <!-- <v-layout align-center justify-center>
    <span slot="loader" class="custom-loader">
      <v-icon light size="150px">cached</v-icon>
    </span>
  </v-layout> -->
</v-dialog>
</template>
<script>
export default {
  name: 'loadingDialog',
  data: () => ({
    loading: true
  })
}
</script>