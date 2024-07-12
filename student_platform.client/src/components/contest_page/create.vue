<template>
  <el-card class="create-card">
    <el-form ref="teamForm" :model="teamData" :rules="rules" label-width="120px">
      <el-form-item label="团队名称" prop="name">
        <el-input v-model="teamData.name" />
      </el-form-item>
      <el-form-item label="参加的竞赛" prop="race">
        <el-input v-model="teamData.race" />
      </el-form-item>
      <el-form-item label="队伍介绍" prop="description">
        <el-input type="textarea" v-model="teamData.description" />
      </el-form-item>
      <el-form-item label="需要的人员数" prop="totalMembers">
        <el-input-number v-model="teamData.totalMembers" :min="1" />
      </el-form-item>
      <el-form-item label="比赛类型" prop="type">
        <el-select v-model="teamData.type" placeholder="选择比赛类型" @change="$forceUpdate()">
          <el-option label="校内赛" value="校内赛"></el-option>
          <el-option label="省赛" value="省赛"></el-option>
          <el-option label="国赛" value="国赛"></el-option>
        </el-select>
      </el-form-item>
      <el-row>
        <el-col :span="12">
          <el-form-item
            label="演练开始日期"
            prop="startTime"
            :rules="[{ required: true, message: '不能为空', trigger: 'blur' }]"
          >
            <el-date-picker
              v-model="teamData.startTime"
              class="baseInput"
              type="date"
              placeholder="选择日期"
              format="YYYY-MM-DD "
              :picker-options="pickerOptionsStart"
            ></el-date-picker>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item
            label="演练结束日期"
            prop="endTime"
            :rules="[{ required: true, message: '不能为空', trigger: 'blur' }]"
          >
            <el-date-picker
              v-model="teamData.endTime"
              class="baseInput"
              type="date"
              placeholder="选择日期"
              format="YYYY-MM-DD"
              :picker-options="pickerOptionsEnd"
            ></el-date-picker>
          </el-form-item>
        </el-col>
      </el-row>
      <el-form-item label="添加标签">
        <el-tag
          v-for="tag in teamData.tags"
          :key="tag"
          closable
          @close="handleTagClose(tag)"
          style="margin-right: 8px;"
        >
          {{ tag }}
        </el-tag>
        <el-input
          v-model="newTag"
          placeholder="输入标签并按回车键添加"
          style="width: 250px;"
          @keyup.enter="handleTagAdd"
        />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="submitForm">提交申请</el-button>
      </el-form-item>
    </el-form>
  </el-card>
</template>
<script setup>
const university = this.getu(this.$route.params.id);
const pid = this.getpid()+1;
</script>

<script>
const currentTime = new Date();

export default {
  setup() {
   
  },
  data() {
    return {
      teamData: {
        name: '',
        race: '',
        type: '',
        id: pid,
        leader: '',
        description: '',
        University: university,
        totalMembers: 1,
        currentMembers: 1,
        startTime: currentTime,
        endTime: currentTime,
        tags: [],
        members: []
      },
      newTag: '',
      rules: {
        name: [{ required: true, message: '请输入团队名称', trigger: 'blur' }],
        race: [{ required: true, message: '请输入参加的竞赛名称', trigger: 'blur' }],
        description: [{ required: true, message: '请输入队伍介绍', trigger: 'blur' }],
        totalMembers: [{ required: true, message: '请输入需要的人员数量', trigger: 'blur' }],
        startTime: [{ required: true, message: '请选择招募开始日期', trigger: 'change' }],
        endTime: [{ required: true, message: '请选择招募结束日期', trigger: 'change' }],
        tags: [
          { required: true, message: '请至少输入一个标签', trigger: 'change' },
          { validator: (value, callback) => {
            if (this.tags.includes(value)) {
              callback(new Error('输入的标签不能重复'));
            } else {
              callback();
            }
          }, trigger: 'change' }
        ]
      },
      pickerOptionsStart: {
        disabledDate: time => {
          if (this.teamData.endTime) {
            return time.getTime() > Date.now() - 86400000 || time.getTime() > this.teamData.endTime;
          }
          return time.getTime() > Date.now() - 86400000;
        }
      },
      pickerOptionsEnd: {
        disabledDate: time => {
          if (this.teamData.startTime) {
            return time.getTime() > Date.now() - 86400000 || time.getTime() < this.teamData.startTime;
          }
          return time.getTime() > Date.now() - 86400000;
        }
      }
    };
  },
  methods: {
    handleTagClose(tag) {
      this.teamData.tags.splice(this.teamData.tags.indexOf(tag), 1);
    },
    handleTagAdd() {
      if (this.newTag && this.teamData.tags.includes(this.newTag) === false) {
        this.teamData.tags.push(this.newTag);
      }
      this.newTag = '';
    },
    submitForm() {
      this.$refs.teamForm.validate(valid => {
        if (valid) {
          // 提交表单数据到服务器
          console.log(this.teamData);
        } else {
          return false;
        }
      });
    },
    getu(id){
        //使用用户id获取大学的接口
      return "清华·大学"
    },
      getpid() {
          //获取pid,pid是指当前最大的用户id
      return 1234
    }
  }
};
</script>

<style>
.create-card {
  width: 800px;
  margin: 100px auto;
}
.login-title {
  text-align: center;
  margin-bottom: 20px;
}
</style>