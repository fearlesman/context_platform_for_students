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
    <el-menu-item index="1" @click="navigateTo('/')">
      首页
    </el-menu-item>
    <el-menu-item index="2" @click="navigateTo('/contest')">
      竞赛组队
    </el-menu-item>
    <div class="flex-grow" />
    <el-menu-item index="3" @click="navigateTo('/login')">
      登录
    </el-menu-item>
    <el-menu-item index="4" @click="navigateTo('/personal')">
      个人中心
    </el-menu-item>
    <el-menu-item index="5" @click="navigateTo('/markdown')">
      主页编辑
    </el-menu-item>
  </el-menu>
</template>

<script>
import router from '@/rounter';

export default {
  data() {
    return {
      activeIndex: '1'
    };
  },
  methods: {
    // handleSelect(key, keyPath) {
    //   console.log(key, keyPath);
    // },
    navigateTo(path) {
      router.push(path);
    }
  }
};
</script>

<style>
.flex-grow {
  flex-grow: 1;
}
</style>