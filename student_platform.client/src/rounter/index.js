import Vue from 'vue'
import router from 'vue-router'

Vue.use(router)

const router = new Router({
  mode: 'hash',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('@/home.vue')
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('@/login.vue')
    },
    {
      path: '/context',
      name: 'context',
      component: () => import('@/context.vue')
    },
    {
      path: '/register',
      name: 'register',
      component: () => import('@/views/Register.vue')
    },
  ]
})