import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import router from './router'
// import Vuetify from 'vuetify'
// import 'vuetify/dist/vuetify.min.css'
// import 'material-design-icons-iconfont/dist/material-design-icons.css'
import '@mdi/font/css/materialdesignicons.css'
// import '@fortawesome/fontawesome-free/css/all.css'
import VeeValidate, { Validator } from 'vee-validate'
import {dict} from './utils/diccionario'
/* -------------- Components --------------- */
import alert from './components/shared/alert'
import alertModal from './components/shared/alertModal'
import loadingDialog from './components/shared/loadingDialog'
/* -------------- Rutas/Sincronizacion --------------- */
import {store} from './store/index'
import {sync} from 'vuex-router-sync'
import vuetify from './plugins/vuetify';
sync(store, router)
/* -------------- Axios --------------- */
Vue.prototype.$http = axios
/* -------------- Vuetify --------------- */
// Vue.use(Vuetify, {
//   iconfont: 'mdi' // 'md' || 'mdi' || 'fa' || 'fa4'
// })
/* -------------- Validaciones --------------- */
Vue.use(VeeValidate)
Validator.localize('es', dict)
/* -------------- Use Components --------------- */
Vue.component('app-alert', alert)
Vue.component('app-alertModal', alertModal)
Vue.component('app-loadingDialog', loadingDialog)


Vue.config.productionTip = false

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
