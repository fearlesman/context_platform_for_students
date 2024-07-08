<script>
  import axios from 'axios';
  import router from '@/rounter';
  export default {
  data() {
    return {
      activeIndex: '1',
      loginstatus: false,
      // url='/api/loginstatus/'+account,
    };
  },
  methods: {
    // handleSelect(key, keyPath) {
    //   console.log(key, keyPath);
    // },
    navigateTo(path) {
      router.push(path);
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
        src=""
        alt="logo"
      />
    </el-menu-item>
    <el-menu-item index="1" @click="navigateTo('/')">
      首页
    </el-menu-item>
    <el-sub-menu index="2" >
      <template #title>竞赛组队</template>
      <el-menu-item index="2-1" @click="navigateTo('/create')">
        <div>
          创建队伍
        </div>
      </el-menu-item>
      <el-menu-item index="2-2" @click="navigateTo('/join')">
        加入队伍
      </el-menu-item>
    </el-sub-menu>
    <div class="flex-grow" />
    <el-menu-item index="3" @click="navigateTo('/login')" v-if="getloginstatus() === false">
      登录
    </el-menu-item>
    <el-menu-item index="4" @click="navigateTo('/personal')" v-if="getloginstatus() === true">
      个人中心
    </el-menu-item>
    <el-menu-item index="5" @click="changestatus()" v-if="getloginstatus() === true">
      退出登录
    </el-menu-item>
    <el-menu-item index="6" @click="changestatus()">
      状态切换
    </el-menu-item>
  </el-menu>
</template>

<style>
.flex-grow {
  flex-grow: 1;
}
</style>