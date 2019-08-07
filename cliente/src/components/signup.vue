<template>
    <div>
      <v-layout align-center justify-center>
        <v-flex xs12>
          <v-card>
            <v-card-title primary-title>
              Registro
            </v-card-title>
            <v-card-text>
              <v-form>
                <v-text-field v-model="newUser.email" prepend-icon="mdi-email" name="email" label="Correo" type="text" required
                              v-validate="'required|email|max:100'" :error-messages="errors.collect('correo')" data-vv-name="correo"
                ></v-text-field>
                <v-text-field v-model="newUser.password" id="passwordSignUp" ref="passwordRef" prepend-icon="mdi-lock" name="password" label="Contraseña" type="password"
                              v-validate="'required|min:6|max:50'" :error-messages="errors.collect('contra')" data-vv-name="contra" required
                ></v-text-field>
                <v-text-field v-model="newUser.confirmPassword" id="confirmPassword" prepend-icon="mdi-lock" name="confirmPassword" label="Confirma Contraseña" type="password"
                              v-validate="'required|max:50|confirmed:passwordRef'" :error-messages="errors.collect('repContra')" data-vv-name="repContra" required
                ></v-text-field>
              </v-form>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <!-- <v-btn small @click="$emit('closeSignUp')">Cerrar</v-btn> -->
              <v-btn small :dark="!loading" color="dark" @click="sendSignUp" :disabled="loading" :loading="loading">
                Registrate
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
  name: 'Signup',
  data: () => ({
    newUser: { email: null, password: null, confirmPassword: null }
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
    sendSignUp () {
      this.$validator.validateAll()
      if (!this.errors.any()) {
        this.$store.dispatch('signUserUp', {email: this.newUser.email, password: this.newUser.password})
      }
    },
    onDismissed () {
      this.$store.dispatch('clearError')
    }
  }
  // created () {
  //   eventBus.$on('openSignUp', () =>
  //     this.$emit('openSignUp')
  //   )
  // }
}
</script>

