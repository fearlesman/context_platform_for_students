<script>
  import axios from 'axios';
  export default {
  data() {
    return {
      activeIndex: '1',
      loginstatus: false,
      userid: '123',
      visitorId: null, // 存储访客的唯一标识符
    };
  },
  methods: {

    // handleSelect(key, keyPath) {
    //   console.log(key, keyPath);
    // },
    navigateTo(path) {
      this.$router.push(path);
    },
    navigate(path,thisname) {
      if (this.$store.state.loginstatus === true){
        this.$router.push({ name: thisname, params: { id: this.userid } });
      }
      else{
        alert('请先登录！');
        this.$router.push('/login');
      }
    },
    changestatus(){
      if(this.$store.state.loginstatus === false)
      this.$store.commit('login','123');
      else
      this.$store.commit('logout');
      this.$forceUpdate() ;
    },
    getloginstatus(){ return this.$store.state.loginstatus; },

  // axios.get(url)
  //               .then(response => {
  //                   const a = response.data;
  //                   if(a === 1){
  //                     this.loginstatus = true;
  //                   }else{
  //                     this.loginstatus = false;
  //                     alert('登录失败！');
  //                   }
  //               })
  //               .catch(error => {
  //                   alert('服务器错误！');
  //               });
  //return loginstatus;
  //},
}
};
</script>
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
    <el-sub-menu index="2" >
      <template #title>竞赛组队</template>
      <el-menu-item index="2-1" @click="navigate('/join','join')">
        加入队伍
      </el-menu-item>
      <el-menu-item index="2-2" @click="navigate('/create','create')">
        创建队伍
      </el-menu-item>
    </el-sub-menu>
    <el-menu-item index="3" @click="navigate('/myteam','myteam')">
      我的团队
    </el-menu-item>
    <div class="flex-grow" />
    <el-menu-item index="4" @click="navigateTo('/login')" v-if="getloginstatus() === false">
      登录
    </el-menu-item>
    <el-menu-item index="5" @click="navigate('/home', 'home')" v-if="getloginstatus() === true">
      个人中心
    </el-menu-item>
    <el-menu-item index="6" @click="changestatus()" v-if="getloginstatus() === true">
      退出登录
    </el-menu-item>
    <el-menu-item index="7" @click="changestatus()">
      状态切换
    </el-menu-item>
    </el-menu>
    <footer class="footer">
      <p>Copyright 2023 · 纵横团队 · ALL RIGHTS RESERVED</p>
    </footer>
</template>

<style>
.flex-grow {
  flex-grow: 1;
}
.footer {
  position: fixed;
  left: 0;
  bottom: 0;
  width: 100%;
  height: 30px;
  text-align: center;
  padding: 10px 0;
  background-color: #f8f8f8;
  color: #333;
  box-shadow: 0 -1px 2px rgba(0,0,0,0.1);
  z-index: 999;
}
</style>