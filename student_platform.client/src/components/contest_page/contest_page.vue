<template>
  <div class='contest-page'>
    <br>
    <el-row :gutter="20">
      <el-col :span="6">
        <el-input v-model="searchText" placeholder="搜索队伍名、队长名或标签" clearable @input="filterTeams">
          <template v-slot:prefix>
              <i  class="el-input__icon el-icon-search"></i>
          </template>
        </el-input>
      </el-col>
      <el-col :span="6">
        <el-select v-model="selectedStatus" placeholder="选择状态" @change="$forceUpdate(),searchData()">
          <el-option label="所有状态" value=""></el-option>
          <el-option label="招募中" value="招募中"></el-option>
          <el-option label="招募完成" value="招募完成"></el-option>
        </el-select>
      </el-col>
      <el-col :span="6">
        <el-select v-model="selectedTags" multiple placeholder="选择标签" @change="searchData()">
          <el-option v-for="tag in allTags" :key="tag" :label="tag" :value="tag"></el-option>
        </el-select>
      </el-col>
      <el-col :span="6">
        <el-button type="primary" @click="resetFilters">重置</el-button>
      </el-col>
    </el-row>
    <el-divider />
    <el-row :gutter="20" style="margin-top: 20px;">
      <el-col :span="24">
        <el-table :data="filteredTeams" stripe>
          <el-table-column prop="name" label="队伍名" width="150">
            <template v-slot="scope">
              <span>{{ scope.row.name }}</span>
            </template>
          </el-table-column>
          <el-table-column label="队长" width="100">
            <template v-slot="scope">
              <el-avatar :src="scope.row.leaderAvatar" @click="showLeaderProfile(scope.row.leaderName)"></el-avatar>
            </template>
          </el-table-column>
          <el-table-column prop="description" label="比赛介绍" width="200">
            <template v-slot="scope">
              <span>{{ scope.row.description }}</span>
            </template>
          </el-table-column>
          <el-table-column prop="currentMembers" label="队伍人数" width="100">
            <template v-slot="scope">
              <span>{{ scope.row.currentMembers }}/{{ scope.row.totalMembers }}</span>
            </template>
          </el-table-column>
          <el-table-column prop="status" label="状态" width="150">
            <template v-slot="scope">
              <el-tag :type="scope.row.status === '招募中' ? 'success' : 'danger'">{{ scope.row.status }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column prop="tags" label="标签" width="300">
            <template v-slot="scope">
              <el-tag v-for="tag in scope.row.tags" :key="tag" style="margin-right: 5px;">{{ tag }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column label="操作" width="150">
            <template v-slot="scope">
              <el-button type="text" @click="showLeaderProfile(scope.row.leaderName)">查看详情</el-button>
            </template>
          </el-table-column>
        </el-table>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  data() {
    return {
      teams: [
        {
          name: '队伍A',
          leaderName: '队长A',
          leaderAvatar: 'https://via.placeholder.com/150',
          description: '这是队伍A的介绍',
          currentMembers: 10,
          totalMembers: 20,
          status: '招募中',
          tags: ['标签1', '标签2', '标签3']
        },
        {
          name: '队伍B',
          leaderName: '队长B',
          leaderAvatar: 'https://via.placeholder.com/150',
          description: '这是队伍B的介绍',
          currentMembers: 15,
          totalMembers: 25,
          status: '招募完成',
          tags: ['标签4', '标签5', '标签6']
        },
        // 添加更多队伍数据
      ],
      searchText: '',
      selectedStatus: '',
      selectedTags: [],
      filteredTeams: [],
      searchResults: []
    }
  },
  computed: {
    allTags() {
      const allTags = new Set();
      this.teams.forEach(team => {
        team.tags.forEach(tag => allTags.add(tag));
      });
      return Array.from(allTags);
    }
  },
  created() {
    this.filteredTeams = this.teams;
  },
  methods: {
    filterTeams() {
        this.filteredTeams = this.teams.filter(team => {
          // 根据搜索框内容、状态、标签筛选条件
          const searchText = this.searchText.toLowerCase();
          const matchesSearchText = team.name.toLowerCase().includes(searchText)
            || team.leaderName.toLowerCase().includes(searchText)
            || team.tags.some(tag => tag.toLowerCase().includes(searchText));
          const matchesStatus = this.selectedStatus ? team.status === this.selectedStatus : true;
          const matchesTags = this.selectedTags.length
            ? this.selectedTags.every(tag => team.tags.includes(tag))
            : true;
          return matchesSearchText && matchesStatus && matchesTags;
      });
    },
    
    showLeaderProfile(leaderName) {
      alert(`查看${leaderName}的个人简介`);
    },
    resetFilters() {
      this.searchText = '';
      this.selectedStatus = '';
      this.selectedTags = [];
      this.filterTeams();
    },
    // 实时显示
    searchData() {
      let data = this.teams; 
      // 根据状态筛选
      if (this.selectedStatus) {
        data = data.filter(item => item.status === this.selectedStatus);
      }
      // 根据搜索框内容筛选
      if (this.searchText) {
        const searchText = this.searchText.toLowerCase();
        data = data.filter(team => {
          return team.name.toLowerCase().includes(searchText)
            || team.leaderName.toLowerCase().includes(searchText)
            || team.tags.some(tag => tag.toLowerCase().includes(searchText));
        });
      }
      // 根据标签筛选
      if (this.selectedTags.length) {
        data = data.filter(team => {
          return this.selectedTags.every(tag => team.tags.includes(tag));
        });
      }
      this.filteredTeams = data;
    }
  }
}
</script>