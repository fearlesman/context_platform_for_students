<template>
  <el-menu
    :default-active="activeIndex"
    class="el-menu-demo"
    mode="horizontal"
    :ellipsis="false"
    @select="handleSelect"
  >
    <el-menu-item index="0">
      <img
        style="width: 100px"
        src=""
        alt="logo"
      />
    </el-menu-item>
    <el-menu-item index="1" >
      <router-link to="/">首页</router-link>
    </el-menu-item>
    <el-menu-item index="2">
      <router-link to="/contest">竞赛组队</router-link>
    </el-menu-item>
    <div class="flex-grow" />
    <el-menu-item index="3">
      <router-link to="/login">登录</router-link>
      /
      <router-link to="/register">注册</router-link>
    </el-menu-item>
    
    <el-menu-item index="4">
      <router-link to="/personal">个人中心</router-link>
    </el-menu-item>
    <el-menu-item index="5">
      <router-link to="/markdown">主页编辑</router-link>
    </el-menu-item>
  </el-menu>
</template>

<script lang="ts" setup>
import router from '@/rounter';
import { ref } from 'vue'

const activeIndex = ref('1')
const handleSelect = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}
</script>

<style>
.flex-grow {
  flex-grow: 1;
}
</style>
