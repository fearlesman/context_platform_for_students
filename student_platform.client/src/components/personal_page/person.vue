<template>
    <div class="container">
      <div class="header">
        <div class="user-info">
          <img class="avatar" :src="user.avatar" alt="Avatar">
          <div class="username">{{ user.username }}</div>
          <br>
          <div class="University">{{ user.university }}</div>
          <p>User ID: {{ $route.params.id }}</p> <!-- 使用$route访问动态参数 -->
          <div class="tags">
            <el-tag v-for="tag in user.tags" :key="tag" class="tag" >{{ tag }}</el-tag>
          </div>
        </div>
        <div class="profile" :v-if="show">
          <el-button type="primary" @click="downloadPdf" >
            <i class="el-icon-download"></i>
            查看简历
          </el-button>
          <div>
            <el-popover
              v-model:visible="uploadPopoverVisible"
              placement="bottom"
              :width="500"
              trigger="click"
            >
              <template #reference>
                <el-button type="primary">上传简历</el-button>
              </template>
              <el-upload
                ref="upload"
                accept=".pdf"
                multiple
                :action="uploadUrl"
                :headers="uploadHeaders"
                :on-exceed="handleExceed"
                :on-success="handleUploadSuccess"
                :on-error="handleUploadError"
                :file-list="fileList"
                :limit="1"
                :auto-upload="false"
                @change="handleFileUpload"
              >
                <el-button type="primary">选择文件</el-button>
                <template #tip>
                  <div class="el-upload__tip">
                    只能上传PDF文件,且不超过 5MB
                  </div>
                </template>
              </el-upload>
              <div class="dialog-footer">
                <el-button @click="uploadPopoverVisible = false">取消</el-button>
                <el-button type="primary" @click="uploadPdf" :disabled="!pdfFile">上传</el-button>
              </div>
            </el-popover>
          </div>
        </div>
      </div>
  
      <div class="content">
        <div class="profile">
            <h2>个人简介</h2>
            <el-button @click="navigateTo(this.$store.state.userid)">编辑简介</el-button>
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
          tags: ['JavaScript', 'Vue.js', 'Web Development'],
          university: '清华大学'
        },
        customizationContent: '# 欢迎来到我的个人主页!\n\n这里是您可以自定义的个性化内容区域。您可以使用 Markdown 格式进行编辑。',
        uploadPopoverVisible: false,
        uploadUrl: '/api/upload',
        pdfSrc: '../../../../Student_platform.Server/resumes/',
        fileList: [],
        pdfFile: null,
        uploadHeaders: {}
      }
    },
    computed: {
      compiledMarkdown() {
        return marked(this.customizationContent)
      }
    },
    methods: {
      navigateTo(pid) {
        this.$router.push({ name: 'markdown', params: { id: pid } });
      },
      downloadPdf() {
        const link = document.createElement('a');
        link.href = this.pdfSrc;
        link.download = this.$route.params.id+'.pdf';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
      },
      handleFileUpload(file) {
      this.pdfFile = file
        },
        show() {
            return this.$router.params.id === this.$store.state.userid;
        },
    handleExceed(files, fileList) {
      this.$message.warning(`最多只能上传 1 个文件`)
    },
    handleUploadSuccess(response, file, fileList) {
      this.fileList = fileList
      this.$message.success('上传成功')
    },
    handleUploadError(err, file, fileList) {
      this.fileList = fileList
      this.$message.error('上传失败')
    },
    uploadPdf() {
      
    }
    }
}
</script>
  
  <style>
  .container {
    max-width: 1200px;
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
    flex-grow :1;
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