<template>
    <!-- 注册表单 -->
    <el-card class="register-card">
      <h3 class="register-title">注册</h3>
      <el-form :model="registerForm" :rules="rules" ref="registerForm" label-width="100px">
        <el-form-item label="用户名" prop="username">
          <el-input v-model="registerForm.username"></el-input>
        </el-form-item>
        <el-form-item label="选择头像" prop="img" :rules="[]">
          <el-upload
              list-type="picture-card"
              :auto-upload="false"
              :on-change="handleChange"
              :multiple="false"
              :before-upload="beforeAvatarUpload"
              :file-list="fileList"
              :limit="1"
              accept=".png, .jpg, .JPG, .JPEG, .jpeg, .PNG .GIF, .gif"
            >
              <template #default>
                <i class="el-icon-plus" />
              </template>
              <template #file="{ file }">
                <div style="width: 100%;height: 100%;">
                  <img
                    style="width: 100%;height: 100%;"
                    class="el-upload-list__item-thumbnail"
                    :src="file.url"
                    alt=""
                  >
                </div>
              </template>
          </el-upload>
        </el-form-item>

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
              fileList: [],
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
      beforeAvatarUpload(file) {
        const fileType = file.raw.type
        const isJPG = fileType === 'image/jpg' || fileType === 'image/jpeg' || fileType === 'image/png'
        const isLt20M = file.raw.size / 1024 / 1024 < 20
        if (!isJPG) {
          this.$message.error('上传图片的格式只能是 JPG或PNG 格式!')
        }
        if (!isLt20M) {
          this.$message.error('上传图片的大小不能超过 20M!')
        }
        return isJPG && isLt20M
      },
      // 移除图片
      handleRemove(file) {
        const index = this.fileList.indexOf(file.url)
        this.fileList.splice(index, 1)
      },
      // 上传图片
      handleChange(file, fileList) {
        const isFileType = this.beforeAvatarUpload(file)
        // 如果文件类型不对，则清空表单及附件列表
        if (!isFileType) {
          this.fileList = []
          return
        }
        this.registerForm.img = file.raw  // 这个就是咱们上传图片的二进制对象
        this.registerForm.img_type = file.type
        this.fileList = [fileList[0]]
      },
      submitForm() {
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