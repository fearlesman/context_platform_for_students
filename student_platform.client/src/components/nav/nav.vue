<template>
  <el-menu
    :default-active="activeIndex"
    mode="horizontal"
    @select="handleSelect"
    width=100%
  >
    <el-row>
      <el-col :span="6">
        <el-menu-item index="1" class="menu-item">
          <router-link class="nav-link" to="/">
            <p>首页</p>
          </router-link>
        </el-menu-item>
      </el-col>
  <el-col :span="6">
    <el-menu-item index="2" class="menu-item">
      <router-link class="nav-link" to="/contest">
        <p>比赛组队</p>
      </router-link>
    </el-menu-item>
  </el-col>
  <el-col :span="6" v-if="loginstatus==0">
    <el-menu-item index="3" class="menu-item">
      <router-link class="nav-link" to="/register">
        <p>注册</p>
      </router-link>
      /
      <router-link class="nav-link" to="/login">
        <p>登录</p>
      </router-link>
    </el-menu-item>
  </el-col>
  </el-row>
  </el-menu>
  <div v-if="loginstatus==1" class="user-info">
    <span>欢迎，{{username}}</span>
    <el-button type="text" @click="logout()">退出</el-button>
  </div>

</template>

<script>
import { ref } from 'vue'

export default {
  setup() {
    const activeIndex = ref('1')

    const handleSelect = (key, keyPath) => {
      activeIndex.value = key
    }
    return {
      activeIndex,
      handleSelect
    }
  }
}
</script>
<style>
.user-info {
  position: absolute;
  top: 123px;
  right: 123px;
  font-size: 14px;
  color: #fff;
  padding: 10px;
  z-index: 999;
}
</style>