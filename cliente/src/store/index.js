import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)
const url = 'http://localhost:5000/api/'

export const store = new Vuex.Store({
    state: {
      isLoggedIn: false,
      user: null,
      token: null,
      loading: false,
      categories: [],
      autors: [],
      books: [],
      error: null
    },
    getters: {
      userIsLoggedIn (state) {
          return (state.user !== null && state.user !== undefined)
          // return localStorage.getItem('access_token');
      },
      user (state) {
        return state.user
      },
      token (state) {
        return localStorage.getItem('access_token');
      },    
      loading (state) {
        return state.loading
      },    
      error (state) {
        return state.error
      },    
      categories (state) {
        return state.categories
      },    
      autors (state) {
        return state.autors
      },    
      books (state) {
        return state.books
      }
    },
    mutations: {
      setUser (state, payload) {
        state.user = payload
      },
      setLoading (state, payload) {
        state.loading = payload
      },
      setError (state, payload) {
        state.error = payload
      },
      clearError (state) {
        state.error = null
      },
      setToken (state, payload) {
        state.token = payload
      },
      setCategories (state, payload) {
        state.categories = payload
      },
      setAutors (state, payload) {
        state.autors = payload
      },
      setBooks (state, payload) {
        state.books = payload
      },
      clearState (state) {
        state.isLoggedIn = false
        state.user = null
        state.loading = false
        state.error = null
        state.categories = []
        state.autors = []
        state.books = []
      }
    },
    actions: {
      signUserUp ({commit, dispatch}, payload) {
        axios.post(url + 'account/Registrar', {
          userName: payload.email,
          password: payload.password
        }, 
        { headers: { 'Content-Type': 'application/json' } })
        .then((res) => {
          // commit('setToken', res.token)
          localStorage.setItem('access_token', res.data)
          localStorage.setItem('access_user', payload.email)
          commit('setUser', { email: payload.email })
          dispatch('chargeData', res.data)
        })
        .catch((error) => {
          console.log(error);
        });
      },
      signUserIn ({commit, dispatch}, payload) {
        axios.post(url + 'auth/login', {
          userName: payload.email,
          password: payload.password
        }, 
        { headers: { 'Content-Type': 'application/json' } })
        .then((res) => {
          // commit('setToken', res.token)
          localStorage.setItem('access_token', res.data)
          localStorage.setItem('access_user', payload.email)
          commit('setUser', { email: payload.email })
          dispatch('chargeData', res.data)
        })
        .catch((error) => {
          console.log(error);
        });
      },
      signOut ({commit}) {
        localStorage.removeItem('access_token');
        localStorage.removeItem('access_user');
        commit('clearState')
      },
      userPersisting({commit, state, dispatch}) {
        const token = localStorage.getItem('access_token')
        if (token) {
          commit('setUser', { email: localStorage.getItem('access_user') })
          dispatch('chargeData', token)
        }
      },
      chargeData({commit, dispatch}, token) {
        dispatch('getCategories', token)
        dispatch('getAutors', token)
        dispatch('getBooks', token)
      },
      getCategories({commit}, token) {
        axios.get(url + 'category', { headers: { "Authorization": 'Bearer ' + token }})
        .then((res) => {
          commit('setCategories', res.data)
        })
        .catch((error) => {
          console.log(error);
        });
      },
      getAutors({commit}, token) {
        axios.get(url + 'autor', { headers: { "Authorization": 'Bearer ' + token }})
        .then((res) => {
          commit('setAutors', res.data)
        })
        .catch((error) => {
          console.log(error);
        });
      },
      getBooks({commit}, token) {
        axios.get(url + 'book', { headers: { "Authorization": 'Bearer ' + token }})
        .then((res) => {
          commit('setBooks', res.data)
        })
        .catch((error) => {
          console.log(error);
        });
      }
    }
})