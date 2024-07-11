<template>
    <!-- 注册表单 -->
    <el-card class="register-card">
      <h3 class="register-title">注册</h3>
      <el-form :model="registerForm" :rules="rules" ref="registerForm" label-width="100px">
        <el-form-item label="用户名" prop="username">
          <el-input v-model="registerForm.username"></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="password">
          <el-input type="password" v-model="registerForm.password"></el-input>
        </el-form-item>
        <el-form-item label="确认密码" prop="confirmPassword">
          <el-input type="password" v-model="registerForm.confirmPassword" rules="confirmPasswordValidator"></el-input>
        </el-form-item>
        <el-form-item label="邮箱" prop="email">
          <el-input v-model="registerForm.email"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="submitForm('registerForm')">注册</el-button>
          <el-button type="primary" @click="navigateTo('login')">返回登录</el-button>
        </el-form-item>
      </el-form>
    </el-card>
  </template>
  
  <script>
  import axios from 'axios';
  export default {
    data() {
          return {
           Result: null,
              registerForm: {
                  username: '',
                  password: '',
                  confirmPassword: '',
                  email: '',
                  university:''
              },
        rules: {
          username: [
            { required: true, message: '请输入用户名', trigger: 'blur' },
            { min: 3, max: 15, message: '长度在 3 到 15 个字符', trigger: 'blur' }
          ],
          password: [
            { required: true, message: '请输入密码', trigger: 'blur' },
            { min: 6, message: '密码长度不能少于6位', trigger: 'blur' }
          ],
          confirmPassword: [
            { required: true, message: '请确认密码', trigger: 'blur' },
            { validator: this.confirmPasswordValidator, trigger: 'blur' }
          ],
          email: [
            { required: true, message: '请输入邮箱地址', trigger: 'blur' },
            { type: 'email', message: '请输入有效的邮箱地址', trigger: 'blur' }
          ]
        }
      };
    },
    methods: {
      // 路由跳转

      // 表单验证
      confirmPasswordValidator(rule, value, callback) {
        if (value !== this.registerForm.password) {
          callback(new Error('两次输入密码不一致!'));
        } else {
          callback();
        }
      },

      navigateTo(path) {
        this.$router.push(path);
      },
      submitForm(formName) {
        this.$refs[formName].validate((valid) => {
            if (valid) {
                alert('提交注册信息!');
                axios.post('https://localhost:7201/api/Register',this.registerForm)
                  .then(response => {
                      alert(response.data);
                  })
                  .catch(error => {
                      alert(error.response.data);
                  })
            // 在这里添加注册的逻辑
          } else {
            console.log('error submit!!');
            return false;
          }
        });
      },
      confirmPasswordValidator(rule, value, callback) {
        if (value !== this.registerForm.password) {
          callback(new Error('两次输入密码不一致!'));
        } else {
          callback();
        }
      },
      goToLoginPage() {
        this.$router.push('/login');
      }
    }
  };
  </script>