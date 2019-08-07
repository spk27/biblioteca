import Vue from 'vue'
import Router from 'vue-router'
import panel from '@/components/panel'
import biblioteca from '@/components/Biblioteca'
import AuthGuard from './auth-guard'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'panel',
      component: panel
    },
    {
      path: '/biblioteca',
      name: 'biblioteca',
      component: biblioteca,
      beforeEnter: AuthGuard
    }
  ]
})
