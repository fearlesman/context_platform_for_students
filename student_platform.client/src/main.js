
import { createApp } from 'vue'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import App from './App.vue'
import './components/asserts/home.css'
import './components/asserts/contest_page.css'
import './components/asserts/login_page.css'
import './components/asserts/register.css'
import router from './rounter/index.js' // 引入路由实例
import { createStore } from 'vuex'

const store = createStore({
  state () {
    return {
      loginstatus: false,
      userid:''
    }
  },
  mutations: {
    login (state, userid) {
      state.loginstatus = true;
      state.userid = userid;
    },
    logout (state) {
      state.loginstatus = false;
      state.userid = '';
    }
  }
})
const app = createApp(App)
app.use(router)
app.use(store)
app.use(ElementPlus)
app.mount('#app')
