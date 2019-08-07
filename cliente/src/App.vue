<template>
  <v-app>
    <!-- <v-navigation-drawer app></v-navigation-drawer> -->
    <v-app-bar app dense dark>
      <v-btn icon @click="$router.push('/biblioteca')" v-if="userIsLoggedIn">
        <v-icon large>mdi-home</v-icon>
      </v-btn>
      <v-spacer></v-spacer>
      <div v-if="userIsLoggedIn">
        <span class="hidden-xs-only"> {{ user.email ? user.email : user.phone }} </span>
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-btn v-on="on" icon large @click="logOut">
              <v-icon>mdi-exit-to-app</v-icon>
            </v-btn>
          </template>
          <span>Salir</span>
        </v-tooltip>
      </div>
    </v-app-bar>
    <v-content>
      <v-container fluid>
        <loader v-if="loading"></loader>
        <router-view v-else></router-view>
        <snackBar></snackBar>
        <app-loadingDialog v-if="loadingDialog"></app-loadingDialog>
      </v-container>
    </v-content>
    <AppFooter app></AppFooter>
  </v-app>
</template>

<script>
import AppFooter from './components/footer'
import loader from './components/loader'
import snackBar from './components/shared/snackBar'

export default {
  name: 'app',
  components: {
    'AppFooter': AppFooter,
    loader,
    snackBar
  },
  computed: {
    userIsLoggedIn () {
      return this.$store.getters.userIsLoggedIn
    },
    user () {
      return this.$store.getters.user
    },
    loading () {
      return this.$store.getters.loading
    },
    loadingDialog () {
      return this.$store.getters.loadingDialog
    }
  },
  methods: {
    logOut () {
      this.$store.dispatch('signOut')
      this.$router.push('/')
    }
  },
  created () {
    this.$store.dispatch('userPersisting')
  },
   watch: {
    user (value) {
      if (value !== null && value !== undefined) {
        this.$router.push('/biblioteca')
      }
    }
  }
}
</script>

<style>
body {
  margin: 0;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

@import url('https://fonts.googleapis.com/css?family=Pacifico|Exo');

.pacifico {
  font-family: 'Pacifico', cursive;
}

.parrafo {
  font-family: 'Exo', sans-serif;
}

.custom-loader {
    animation: loader 1s infinite;
    display: flex;
}
@-moz-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-webkit-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-o-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>
