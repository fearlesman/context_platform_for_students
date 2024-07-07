<template>
    <div class="container">
      <div class="header">
        <div class="user-info">
          <img class="avatar" :src="user.avatar" alt="Avatar">
          <div class="username">{{ user.username }}</div>
          <div class="user-id">ID: {{ user.id }}</div>
          <div class="tags">
            <el-tag v-for="tag in user.tags" :key="tag" class="tag" >{{ tag }}</el-tag>
          </div>
        </div>
      </div>
  
      <div class="content">
        <div class="profile">
          <h2>个人简介</h2>
          <div class="markdown-content" v-html="compiledMarkdown"></div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import { marked } from 'marked';
     
  
  export default {
    data() {
      return {
        user: {
          username: 'John Doe',
          avatar: 'https://via.placeholder.com/150',
          id: 'ABC123',
          tags: ['JavaScript', 'Vue.js', 'Web Development']
        },
        customizationContent: '# 欢迎来到我的个人主页!\n\n这里是您可以自定义的个性化内容区域。您可以使用 Markdown 格式进行编辑。'
      }
    },
    computed: {
      compiledMarkdown() {
        return marked(this.customizationContent)
      }
    }
  }
  </script>
  
  <style>
  .container {
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
  }
  
  .header {
    background-color: #f5f5f5;
    padding: 20px;
    border-radius: 5px;
    display: flex;
    justify-content: flex-end;
  }
  
  .user-info {
    display: flex;
    align-items: center;
    gap: 10px;
  }
  
  .avatar {
    width: 50px;
    height: 50px;
    border-radius: 50%;
  }
  
  .username {
    font-size: 18px;
    font-weight: bold;
  }
  
  .user-id {
    font-size: 14px;
    color: #666;
  }
  
  .tags {
    font-size: 14px;
  }
  
  .tag {
    background-color: #e6e6e6;
    padding: 4px 8px;
    border-radius: 4px;
    margin-right: 5px;
  }
  
  .content {
    margin-top: 20px;
  }
  
  .profile,
  .customization {
    background-color: #f5f5f5;
    padding: 20px;
    border-radius: 5px;
    margin-bottom: 20px;
  }
  
  .markdown-content {
    white-space: pre-wrap;
  }
  
  .markdown-editor textarea {
    width: 100%;
    height: 200px;
    font-size: 16px;
    padding: 10px;
    border: 1px solid #ddd;
    border-radius: 5px;
    resize: vertical;
  }
</style>