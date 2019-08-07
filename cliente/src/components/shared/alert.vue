<template>
  <v-alert dismissible :value="true" error icon="warning" @input="$emit('dismissed')">
    {{ message }}
  </v-alert>
</template>
<script>
export default {
  name: 'Alert',
  props: ['message', 'type', 'icon', 'code'],
  data: () => ({
  })
}
</script>
