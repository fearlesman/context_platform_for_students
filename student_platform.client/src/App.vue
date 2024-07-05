<script setup>
import { ElCalendar, ElCard, ElCarousel, textProps } from 'element-plus';
import context_page from "./components/context_page/context_page.vue"
import login_page from "./components/login_page/login_page.vue"
import home from "./components/home/home.vue"
import register_page from "./components/login_page/register.vue"
import personal_page from "./components/personal_page/person.vue"
</script>

<template>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <header>
    <el-menu
    :default-active="activeIndex"
    class="el-menu-demo"
    mode="horizontal"
    :ellipsis="false"
    :unique-opened="true"
    background-color="#545c64"
    text-color="#fff"
    id="app-menu"
    v-model:collapse="isCollapse"
    expand-on-click:false
    menu-trigger="click"
  >
    <el-menu-item index="0" id="logo">
      <img
        style="width: 100px"
        src="./components/icons/teamlogo.png"
        alt="Element logo"
      />
    </el-menu-item>
    <div class="flex-grow" />
    <el-menu-item  @click="jumpToSection('front_page')">
      <p class="menu" :style="{ width: '200px' }">首页</p>
    </el-menu-item>
    <el-menu-item @click="jumpToSection('context_page')">  
      <p class="menu" :style="{ width: '200px' }">竞赛组队</p>  
    </el-menu-item>
  </el-menu>
  <div class="main" v-if="loginstatus==false">
    <el-button type="primary" @click="jumpToSection('login_page')" class="login-button" >
      登录
    </el-button>
    <el-button type="primary" @click="jumpToSection('register_page')" class="login-button" >
      注册
    </el-button>
  </div>
  <el-button type="primary" @click="jumpToSection('personal_page')" class="login-button" >
    主页
  </el-button>
  <div class="main" v-if="loginstatus==true">
    <el-card>
      <el-carousel height="200px" :interval="5000">
        <el-carousel-item v-for="item in 4" :key="item">
          <img
            src="https://element.eleme.cn/uploads/element-ui/poster.png"
            alt="poster"
          />
        </el-carousel-item>
      </el-carousel>
    </el-card>
  </div>
  </header>
  <context_page v-if="nowpage =='context_page'" />
  <home v-if="nowpage =='front_page'" />
  <login_page v-if="nowpage =='login_page'" />
  <register_page v-if="nowpage =='register_page'" />
</template>
<script>
export default {
  data() {
    return {
      nowpage:"front_page",
      loginstatus:false,
   }
  },
  methods: {
    jumpToSection(page) {
      this.nowpage=page;
      this.$router.go(0);
    }
  }
}
</script>
<style>
.main{
  position: absolute;
  right: 100px;
  top: 15px;
}
.menu{
  width: 10%;
  font-size: 18px;
  font-weight: bold;
  text-align: center;
  margin: 0;
  padding: 0;
}
</style>
