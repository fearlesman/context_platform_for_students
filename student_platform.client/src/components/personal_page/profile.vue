<template>
    <el-container>
      <el-header>
        <h1>个人简历</h1>
      </el-header>
      <el-main>
        <el-row>
          <el-col :span="6">
            <el-card class="profile-card">
              <div class="profile-picture">
                <img src="" alt="个人头像">
              </div>
              <h2>John Doe</h2>
              <p>Web 开发工程师</p>
            </el-card>
          </el-col>
          <el-col :span="18">
            <el-card class="resume-card">
              <h2>个人信息</h2>
              <el-row>
                <el-col :span="12">
                  <p>姓名: John Doe</p>
                  <p>年龄: 30</p>
                  <p>手机: 123-456-7890</p>
                  <p>邮箱: john.doe@example.com</p>
                </el-col>
                <el-col :span="12">
                  <p>地址: 123 Main St, Anytown USA</p>
                  <p>GitHub: github.com/johndoe</p>
                  <p>LinkedIn: linkedin.com/in/johndoe</p>
                </el-col>
              </el-row>
              <h2>教育背景</h2>
              <el-timeline>
                <el-timeline-item timestamp="2015-2019" placement="top">
                  <h3>某大学 - 计算机科学学士</h3>
                  <p>GPA: 3.8</p>
                </el-timeline-item>
                <el-timeline-item timestamp="2012-2015" placement="top">
                  <h3>某高中</h3>
                  <p>主修: 数理化</p>
                </el-timeline-item>
              </el-timeline>
              <h2>工作经验</h2>
              <el-timeline>
                <el-timeline-item timestamp="2020-present" placement="top">
                  <h3>某科技公司 - Web 开发工程师</h3>
                  <p>负责公司主要网站的开发和维护工作。使用 Vue.js 和 Element-UI 框架完成了多个项目。</p>
                </el-timeline-item>
                <el-timeline-item timestamp="2018-2020" placement="top">
                  <h3>某互联网公司 - 前端实习生</h3>
                  <p>参与公司内部系统的开发,学习和使用 React 框架。</p>
                </el-timeline-item>
              </el-timeline>
              <h2>技能</h2>
              <el-row>
                <el-col :span="12">
                  <ul>
                    <li>HTML/CSS/JavaScript</li>
                    <li>Vue.js</li>
                    <li>React</li>
                    <li>Node.js</li>
                  </ul>
                </el-col>
                <el-col :span="12">
                  <ul>
                    <li>Git</li>
                    <li>SQL</li>
                    <li>Adobe Creative Cloud</li>
                    <li>Office 套件</li>
                  </ul>
                </el-col>
              </el-row>
            </el-card>
          </el-col>
        </el-row>
      </el-main>
    </el-container>
  </template>
  
  <script>
  export default {
    name: 'ResumeApp'
  }
  </script>
  
  <style>
  .profile-card {
    text-align: center;
    padding: 20px;
  }
  
  .profile-picture img {
    width: 150px;
    height: 150px;
    border-radius: 50%;
    object-fit: cover;
    margin-bottom: 10px;
  }
  
  .resume-card {
    padding: 20px;
  }
  
  .el-timeline-item__content {
    padding-bottom: 20px;
  }
  </style>