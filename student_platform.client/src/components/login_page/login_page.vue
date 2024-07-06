<template>
    <!-- 登录表单 -->
        <el-card class="login-card">
          <h3 class="login-title">登录</h3>
          <el-form :model="loginForm" :rules="rules" ref="loginForm" label-width="100px">
            <el-form-item label="用户名" prop="username">
              <el-input v-model="loginForm.username"></el-input>
            </el-form-item>
            <el-form-item label="密码" prop="password">
              <el-input type="password" v-model="loginForm.password"></el-input>
            </el-form-item>
            <el-form-item>
              <el-button type="primary" @click="submitForm('loginForm')">登录</el-button>
              <el-button type="primary">
                <router-link class="nav-link" to="/register">
                  <p>注册</p>
                </router-link>
              </el-button>
            </el-form-item>
          </el-form>
        </el-card>
</template>

<script>
export default {
  data() {
    return {
      loginForm: {
        username: '',
        password: ''
      },
      rules: {
        username: [
          { required: true, message: '请输入用户名', trigger: 'blur' },
          { min: 3, max: 15, message: '长度在 3 到 15 个字符', trigger: 'blur' }
        ],
        password: [
          { required: true, message: '请输入密码', trigger: 'blur' },
          { min: 6, message: '密码长度不能少于6位', trigger: 'blur' }
        ]
      },
      url:'personal_page'
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          alert('提交登录信息!');
            //测试登录,成功了，返回的是string类型json的字符串，不过axios好像可以直接解析成json对象，就是response.data
            axios.get('https://localhost:7201/api/Login')
                .then(response => {
                    const a = JSON.stringify(response.data);
                    alert(a);

                })
                .catch(error => {
                    alert('登录失败！');
                })
        } else {
          console.log('error submit!!');
          return false;
        }
      });
    }
  }
};
</script>