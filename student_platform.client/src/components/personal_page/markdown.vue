
<script>
import { marked } from 'marked'
import 'element-plus/dist/index.css'

export default {
  data() {
    return {
      content: '# 欢迎来到我的个性化页面!\n\n这里是您可以自定义的内容区域。您可以使用 Markdown 格式进行编辑。',
      previewMode: false
    }
  },
  computed: {
    compiledMarkdown() {
      return marked(this.content)
    }
  },
  methods: {
    previewContent() {
      this.previewMode = true
    },
    saveContent() {
      // 在此处添加保存内容的逻辑
      console.log('保存内容:', this.content)
    },
    submitContent() {
      // 在此处添加提交内容的逻辑
      console.log('提交内容:', this.content)
    }
  }
}
</script>

<template>
    <div class="container">
      <div class="editor-container">
        <div class="editor-header">
          <h2>个性化界面编辑器</h2>
          <div class="editor-actions">
            <el-button @click="previewContent" type="primary">预览</el-button>
            <el-button @click="saveContent" type="success">保存</el-button>
            <el-button @click="submitContent" type="warning">提交</el-button>
          </div>
        </div>
        <div class="editor-content">
          <textarea v-model="content" placeholder="使用 Markdown 编辑您的个性化内容"></textarea>
        </div>
      </div>
  
      <div class="preview-container" v-if="previewMode">
        <div class="preview-header">
          <h2>预览</h2>
          <el-button @click="previewMode = false" type="danger">关闭预览</el-button>
        </div>
        <div class="preview-content" v-html="compiledMarkdown"></div>
      </div>
    </div>
  </template>
  
  <style scoped>
  .container {
    display: flex;
    max-width: 1200px;
    margin: 0 auto;
    padding: 20px;
  }
  
  .editor-container {
    flex: 1;
    background-color: #f5f5f5;
    padding: 20px;
    border-radius: 5px;
    margin-right: 20px;
  }
  
  .editor-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
  }
  
  .editor-actions button {
    margin-left: 10px;
  }
  
  .editor-content textarea {
    width: 100%;
    height: 500px;
    font-size: 16px;
    padding: 10px;
    border: 1px solid #ddd;
    border-radius: 5px;
    resize: vertical;
  }
  
  .preview-container {
    flex: 1;
    background-color: #f5f5f5;
    padding: 20px;
    border-radius: 5px;
  }
  
  .preview-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
  }
  
  .preview-content {
    white-space: pre-wrap;
  }
  </style>