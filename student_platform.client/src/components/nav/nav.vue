<script>
  import axios from 'axios';
  import FingerprintJS from '@fingerprintjs/fingerprintjs';
  export default {
  data() {
    return {
      activeIndex: '1',
      loginstatus: false,
      userid: '123',
      visitorId: null, // 存储访客的唯一标识符
    };
  },
  mounted() {
  if (!this.visitorId) {
    this.loadFingerprintJS();
  }
},
  methods: {
    loadFingerprintJS() {
  FingerprintJS.load()
    .then(fp => fp.get())
    .then(result => {
      this.visitorId = result.visitorId;
      console.log('唯一标识:' + this.visitorId);
    })
    .catch(error => {
      console.error('FingerprintJS 加载失败:', error);
    });
},

    // handleSelect(key, keyPath) {
    //   console.log(key, keyPath);
    // },
    navigateTo(path) {
      this.$router.push(path);
    },
    navigate(path,thisname) {
      if (this.loginstatus === true){
        this.$router.push({ name: thisname, params: { id: this.userid } });
      }
      else{
        alert('请先登录！');
        this.$router.push('/login');
      }
    },
    changestatus(){
      this.loginstatus = this.loginstatus === false? true : false;
    },
    getloginstatus(){ return this.loginstatus; },

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
        src="@/icon/"
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
      <image
        src="g"
        mode="scaleToFill"
      />
    </el-menu-item>
    <el-menu-item index="6" @click="changestatus()" v-if="getloginstatus() === true">
      退出登录
    </el-menu-item>
    <el-menu-item index="7" @click="changestatus()">
      状态切换
    </el-menu-item>
  </el-menu>
</template>

<style>
.flex-grow {
  flex-grow: 1;
}
</style>