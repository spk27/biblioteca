<template>
    <div>   
      <v-layout align-center justify-center>
        <v-flex xs12>
          <v-card>
            <v-card-title primary-title>
              Ingreso
            </v-card-title>
            <v-card-text>
              <v-form>
                <v-text-field v-model="newUser.email" prepend-icon="mdi-email" name="email" label="Correo" type="text" required
                              v-validate="'required|email|max:100'" :error-messages="errors.collect('correo')" data-vv-name="correo"
                ></v-text-field>
                <v-text-field v-model="newUser.password" id="password" prepend-icon="mdi-lock" name="password" label="Contraseña" type="password"
                              v-validate="'required|max:50'" :error-messages="errors.collect('contra')" data-vv-name="contra" required
                ></v-text-field>
              </v-form>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <!-- <v-btn small @click="$emit('closeSignIn')">Cerrar</v-btn> -->
              <v-btn small :dark="!loading" color="dark" @click="sendSignIn" :disabled="loading" :loading="loading">
                Ingresar
                <span slot="loader" class="custom-loader">
                  <v-icon light>cached</v-icon>
                </span>
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
      <v-layout row wrap v-if="error">
        <app-alert @dismissed="onDismissed" :message="error.message" :code="error.code"></app-alert>
      </v-layout>
    </div>
</template>
<script>
// import { eventBus } from '../main'
export default {
  name: 'Signin',
  data: () => ({
    newUser: { login: null, password: null }
  }),
  computed: {
    user () {
      return this.$store.getters.user
    },
    error () {
      return this.$store.getters.error
    },
    loading () {
      return this.$store.getters.loading
    }
  },
  methods: {
    sendSignIn () {
      this.$validator.validateAll()
      if (!this.errors.any()) {
        this.$store.dispatch('signUserIn', {email: this.newUser.email, password: this.newUser.password})
      }
    },
    onDismissed () {
      this.$store.dispatch('clearError')
    }
  }
  // created () {
  //   eventBus.$on('openSignIn', () => {
  //     this.$emit('openSignIn')
  //   })
  // }
}
</script>