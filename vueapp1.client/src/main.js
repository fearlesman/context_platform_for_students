
import { createApp } from 'vue'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import App from './App.vue'
import './components/asserts/home.css'
import './components/asserts/context_page.css'
import './components/asserts/login_page.css'
const app = createApp(App)

app.use(ElementPlus)
app.mount('#app')
