import { createWebHashHistory, createRouter } from 'vue-router'
import contest_page from "@/components/contest_page/contest_page.vue"
import login_page from "@/components/login_page/login_page.vue"
import home from "@/components/home/home.vue"
import register_page from "@/components/login_page/register.vue"
import personal_page from "@/components/personal_page/person.vue"
import markdown_page from "@/components/personal_page/markdown.vue"
import create_page from "@/components/contest_page/create.vue"
import myteam_page from "@/components/personal_page/myteam.vue"
const routes = [
  { path: '/', component: home },
  { path: '/user/:id/join', 
    component: contest_page ,
    name:'join',
    beforeEnter: (to, from, next) => {
      if(this.$store.state.user.id!='')
        next()
      else
        next('/')
    }
  },
  { path: '/login', component: login_page ,name:'login'},
  { path: '/register', component: register_page,name:'register'},
  { path: '/user/:id/markdown', 
    component: markdown_page,
    name:'markdown',
    beforeEnter: (to, from, next) => {
      if(this.$store.state.user.id!='')
        next()
      else
        next('/')
    }},
  { path: '/user/:id/create', 
    component: create_page,
    name:'create',
    beforeEnter: (to, from, next) => {
      if(this.$store.state.user.id!='')
        next()
      else
        next('/')
    }
  },
  { path: '/user/:id/home', 
    component: personal_page,
    name:'home',
    beforeEnter: (to, from, next) => {
      if(this.$store.state.user.id!='')
        next()
      else
        next('/')
    }
  },
  { path: '/user/:id/myteam', 
    component: myteam_page,
    name:'myteam',
    beforeEnter: (to, from, next) => {
      if(this.$store.state.user.id!='')
        next()
      else
        next('/')
    }
  },
  { path: '/home', redirect: '/user/:id/home'}
]

const router = createRouter({
  history: createWebHashHistory(),
  routes,
})

export default router