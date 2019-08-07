<template>
  <v-container fluid fill-height v-if="!user">
    <v-layout align-center justify-center>
      <div v-show="!userIsLoggedIn">
        <Signup></Signup>
        <Signin></Signin>          
      </div>
    </v-layout>
  </v-container>
</template>
<script>

import Signup from './signup'
import Signin from './signin'
export default {
  name: 'panel',
  components: {
    Signup,
    Signin
  },
  data: () => ({
  }),
  methods: {
  },
  computed: {
    userIsLoggedIn () {
      return this.$store.getters.userIsLoggedIn
    },
    user () {
      return this.$store.getters.user
    },
    error () {
      return this.$store.getters.error
    }
  }
}
</script>
