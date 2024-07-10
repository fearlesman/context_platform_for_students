<template>
  <div id="app">
    <el-container>
      <el-header>
        <h1>我的参赛队伍</h1>
        <el-input v-model="searchText" placeholder="搜索队伍" @input="searchData"></el-input>
      </el-header>
      <el-main>
        <el-row :gutter="20">
          <el-col :span="6" v-for="team in filteredTeams" :key="team.name">
            <el-card class="team-card">
              <div class="team-header">
                <div class="team-avatar">
                  <img :src="team.leaderAvatar" alt="Team Avatar">
                </div>
                <div class="team-info">
                  <h3>{{ team.name }}</h3>
                  <p>队长: <a href="#" @click.prevent="showleaderProfile(team.leaderName)">{{ team.leaderName }}</a></p>
                  <p>所在院校: {{ team.University }}</p>
                  <p>比赛类型: {{ team.type }}</p>
                  <p>比赛名称: {{ team.race }}</p>
                  <p>队伍状态: {{ team.status }}</p>
                </div>
              </div>
              <div class="team-members">
                <h4>队员信息:</h4>
                <div class="member-avatar" v-for="member in team.members" :key="member.id">
                  <img :src="member.avatar" :alt="member.name" @click="showMemberProfile(member.id)">
                  <p>{{ member.name }}</p>
                </div>
              </div>
              <div class="team-tags">
                <h4>标签:</h4>
                <el-tag v-for="tag in team.tags" :key="tag" @click="addTags(tag)" style="cursor: pointer;">{{ tag }}</el-tag>
              </div>
              <div class="team-description">
                <p>{{ team.description }}</p>
              </div>
              <div class="team-actions">
                <el-button type="primary" @click="JoinTeam">加入队伍</el-button>
              </div>
            </el-card>
          </el-col>
        </el-row>
      </el-main>
      <el-footer>
        <el-row>
          <el-col :span="6">
            <el-select v-model="selectedStatus" placeholder="选择状态" @change="searchData">
              <el-option label="全部" value=""></el-option>
              <el-option label="招募中" value="招募中"></el-option>
              <el-option label="招募结束" value="招募结束"></el-option>
            </el-select>
          </el-col>
          <el-col :span="6">
            <el-select v-model="selectedType" placeholder="选择比赛类型" @change="searchData">
              <el-option label="全部" value=""></el-option>
              <el-option v-for="type in allTypes" :key="type" :label="type" :value="type"></el-option>
            </el-select>
          </el-col>
          <el-col :span="6">
            <el-tag v-for="tag in selectedTags" :key="tag" closable @close="removeTag(tag)">{{ tag }}</el-tag>
          </el-col>
          <el-col :span="6">
            <el-button type="primary" @click="resetFilters">重置筛选</el-button>
          </el-col>
        </el-row>
      </el-footer>
    </el-container>
  </div>
</template>

<script>
export default {
  data() {
    return {
      teams: [
        // 您之前提供的 teams 数据
      ],
      searchText: '',
      selectedStatus: '',
      selectedTags: [],
      selectedType: '',
      filteredTeams: [],
      searchResults: []
    }
  },
  computed: {
    allTags() {
      // 计算所有标签
    },
    allTypes() {
      // 计算所有比赛类型
    }
  },
  created() {
    this.filteredTeams = this.teams;
  },
  methods: {
    filterTeams() {
      // 根据搜索、状态、标签、比赛类型筛选队伍
    },
    showMemberProfile(memberId) {
      // 显示队员个人信息
    },
    showleaderProfile(leaderName) {
      // 显示队长个人简介
    },
    addTags(tag) {
      // 添加标签筛选
    },
    removeTag(tag) {
      // 移除标签筛选
    },
    resetFilters() {
      // 重置筛选条件
    },
    searchData() {
      // 实时搜索
    },
    JoinTeam() {
      // 加入队伍
    }
  }
}
</script>

<style>
.team-card {
  margin-bottom: 20px;
}

.team-header {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
}

.team-avatar img {
  width: 50px;
  height: 50px;
  border-radius: 50%;
}

.team-info {
  flex: 1;
  margin-left: 10px;
}

.team-members {
  margin-bottom: 10px;
}

.member-avatar {
  display: inline-block;
  text-align: center;
  margin-right: 10px;
  cursor: pointer;
}

.member-avatar img {
  width: 40px;
  height: 40px;
  border-radius: 50%;
}

.team-tags {
  margin-bottom: 10px;
}

.team-description {
  margin-bottom: 10px;
}
</style>