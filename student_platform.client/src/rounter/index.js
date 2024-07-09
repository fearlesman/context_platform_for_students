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
  { path: '/join', component: contest_page },
  { path: '/login', component: login_page },
  { path: '/register', component: register_page },
  { path: '/markdown', component: markdown_page },
  { path: '/create', component: create_page },
  { path: '/user/:id', component: personal_page},
  { path: '/myteam', component: myteam_page},
]

const router = createRouter({
  history: createWebHashHistory(),
  routes,
})

export default router