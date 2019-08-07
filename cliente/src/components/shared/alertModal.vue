<template>
<v-dialog v-model="dialog" max-width="290">
  <v-card>
    <v-card-title class="headline"></v-card-title>
    <v-card-text>
      <v-alert :value="true" :color="type" :icon="icon" outline>
        {{ message }}
      </v-alert>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn :color="type" flat="flat" @click="$emit('closeDialogAlert')">
        Aceptar
      </v-btn>
    </v-card-actions>
  </v-card>
</v-dialog>
</template>
<script>
export default {
  name: 'Alert',
  props: ['message', 'type', 'icon'],
  data: () => ({
    dialog: true
  })
}
</script>
