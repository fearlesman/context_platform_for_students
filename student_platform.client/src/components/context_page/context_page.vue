<template>
  <div class='context-page'>
    <el-row :gutter="20">
      <el-col :span="6">
        <el-input v-model="searchText" placeholder="搜索队伍名、队长名或标签" clearable @input="filterTeams">
          <i slot="prefix" class="el-input__icon el-icon-search"></i>
        </el-input>
      </el-col>
      <el-col :span="6">
        <el-select v-model="selectedStatus" placeholder="选择状态" @change="filterTeams">
          <el-option label="所有状态" value=""></el-option>
          <el-option label="招募中" value="招募中"></el-option>
          <el-option label="招募完成" value="招募完成"></el-option>
        </el-select>
      </el-col>
      <el-col :span="6">
        <el-select v-model="selectedTags" multiple placeholder="选择标签" @change="filterTeams">
          <el-option v-for="tag in allTags" :key="tag" :label="tag" :value="tag"></el-option>
        </el-select>
      </el-col>
      <el-col :span="6">
        <el-button type="primary" @click="resetFilters">重置</el-button>
      </el-col>
    </el-row>
    <el-row :gutter="20" style="margin-top: 20px;">
      <el-col :span="24">
        <el-table :data="filteredTeams" stripe>
          <el-table-column prop="name" label="队伍名" width="200">
            <template v-slot="scope">
              <span>{{ scope.row.name }}</span>
            </template>
          </el-table-column>
          <el-table-column label="队长" width="100">
            <template v-slot="scope">
              <el-avatar :src="scope.row.leaderAvatar" @click="showLeaderProfile(scope.row.leaderName)"></el-avatar>
            </template>
          </el-table-column>
          <el-table-column prop="description" label="队伍简介" width="300">
            <template v-slot="scope">
              <span>{{ scope.row.description }}</span>
            </template>
          </el-table-column>
          <el-table-column prop="currentMembers" label="队伍人数" width="150">
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
      filteredTeams: []
    }
  },
  created() {
    this.filteredTeams = this.teams;
  },
  methods: {
    filterTeams() {
      this.filteredTeams = this.teams.filter(team => {
        const searchText = this.searchText.toLowerCase();
        return team.name.toLowerCase().includes(searchText)
          || team.leaderName.toLowerCase().includes(searchText)
          || team.tags.some(tag => tag.toLowerCase().includes(searchText));
      });
    },
    showLeaderProfile(leaderName) {
      alert(`查看${leaderName}的个人简介`);
    }
  }
}
</script>