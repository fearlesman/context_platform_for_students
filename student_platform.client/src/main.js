
import { createApp } from 'vue'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import App from './App.vue'
import './components/asserts/home.css'
import './components/asserts/contest_page.css'
import './components/asserts/login_page.css'
import './components/asserts/register.css'
import router from './rounter/index.js' // 引入路由实例
const app = createApp(App)
app.use(router)
app.use(ElementPlus)
app.mount('#app')
