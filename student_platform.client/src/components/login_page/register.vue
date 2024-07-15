<template>
    <!-- 注册表单 -->
    <el-card class="register-card">
      <h3 class="register-title">注册</h3>
      <el-form :model="registerForm" :rules="rules" ref="registerForm" label-width="100px">
        <el-form-item label="用户名" prop="username">
          <el-input v-model="registerForm.username"></el-input>
        </el-form-item>
        <div class="avatar-upload-container">
            <el-upload class="avatar-uploader"
                       :ref="uploadref"
                       :show-file-list="false"
                       :on-success="handleAvatarSuccess"
                       :on-error="handleAvatarError"
                       :before-upload="beforeAvatarUpload"
                       auto-upload:false>
                <img src="https://via.placeholder.com/150" class="avatar">
            </el-upload>
            <div class="upload-tip">
                只能上传 JPG/PNG 文件,且文件大小不超过 2MB
            </div>
        </div>
        <el-form-item label="密码" prop="password">
          <el-input type="password" v-model="registerForm.password" :rules="[
            { required: true, message: '请输入密码', trigger: 'blur' },
            { min: 6, max: 16, message: '密码长度应该在6-16个字符之间', trigger: 'blur' },
            { validator: passwordValidator, message: '密码应该包含数字、字母',trigger: 'blur' }  
          ]"></el-input>
        </el-form-item>
        <el-form-item label="确认密码" prop="confirmPassword">
          <el-input type="password" v-model="registerForm.confirmPassword" :rules="[
            { required: true, message: '请输入确认密码', trigger: 'blur' },
            { validator: confirmPasswordValidator, trigger: 'submit' }
          ]"></el-input>
        </el-form-item>
        <el-form-item label="邮箱" prop="email">
          <el-input v-model="registerForm.email"></el-input>
        </el-form-item>
        <el-form-item>
          <el-select v-model="registerForm.university" placeholder="请选择大学">
            <el-option v-for="university in universities" :key="university.value" :label="university.label" :value="university.value">
              {{ university.label }}
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="submitForm()">注册</el-button>
          <el-button type="primary" @click="navigateTo('login')">返回登录</el-button>
        </el-form-item>
        
      </el-form>
    </el-card>
  </template>
  
  <script>
  import axios from 'axios';
  import { ref } from 'vue';
  export default {
    setup() {
      const uploadRef = ref(null)
    return {
      uploadRef,
    }
  },
    data() {
        return {
           Result: null,
              registerForm: {
                  username: '',
                  password: '',
                  confirmPassword: '',
                  email: '',
                  university:'',
                  img:null,
                  img_type:null,
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
          ],
          universities: []
        }
      };
    },
    methods: {
      // 路由跳转
      // 上传头像
    handleAvatarSuccess(res, file) {
      this.imageUrl = URL.createObjectURL(file.raw);
      this.$message.success('头像上传成功');
    },
    handleAvatarError(err) {
      this.$message.error('头像上传失败');
    },
    beforeAvatarUpload(file) {
      console.log(file);
      this.img_type = null;
      if (file.type === 'image/jpeg')
      this.img_type = 'jpg';
      else if (file.type === 'image/png')
      this.img_type = 'png';
      const isLt2M = file.size / 1024 / 1024 < 2;
      if (this.img_type != 'jpg'&&this.img_type != 'png') {
        this.$message.error('上传头像图片只能是 JPG/PNG 格式!');
      }
      if (!isLt2M) {
        this.$message.error('上传头像图片大小不能超过 2MB!');
      }
      return this.img_type && isLt2M;
    },
    confirmPasswordValidator(rule, value, callback) {
          if (value !== this.registerForm.password) {
            callback(new Error('两次输入密码不一致!'));
          } else {
            callback();
          }
        },

      passwordValidator(rule, value, callback) {
        const passwordRegex = /^(?=.*\d)(?=.*[a-zA-Z]).{6,16}$/;
        if (!passwordRegex.test(value)) {
          callback(new Error('密码应该包含数字、字母'));
        } else {
          callback();
        }
      },
      goToLoginPage() {
        this.$router.push('/login');
      },
      navigateTo(path) {
        this.$router.push(path);
      },
      convertToArrayBuffer(file) {
      return new Promise((resolve, reject) => {
        const fileReader = new FileReader();
        fileReader.onload = () => {
          resolve(fileReader.result);
        };
        fileReader.onerror = (error) => {
          reject(error);
        };
        fileReader.readAsArrayBuffer(file);
      });
    },
      submitForm() {
        // 将文件添加到 formData 中
        this.uploadRef.value.files.forEach(file => {
          this.registerForm.img = this.convertToArrayBuffer(file);
          file.type === 'image/jpg' ? this.registerForm.img_type = 'jpg' : this.registerForm.img_type = 'png';
        });
          alert('提交注册信息!');
          axios.post('https://localhost:7201/api/Register',this.registerForm)
              .then(response => {
                  alert(response.data);
                  this.$router.push('/login');
              })
              .catch(error => {
                  alert(error.response.data);
              })
      },
    }
  };
  </script>