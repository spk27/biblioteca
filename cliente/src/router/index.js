import Vue from 'vue'
import Router from 'vue-router'
import panel from '@/components/panel'
import biblioteca from '@/components/Biblioteca'
import category from '@/components/category'
import autor from '@/components/autor'
import book from '@/components/book'
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
    },
    {
      path: '/category',
      name: 'Categorias',
      component: category,
      beforeEnter: AuthGuard
    },
    {
      path: '/autor',
      name: 'Autores',
      component: autor,
      beforeEnter: AuthGuard
    },
    {
      path: '/book',
      name: 'Libros',
      component: book,
      beforeEnter: AuthGuard
    }
  ]
})
