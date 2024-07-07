<template>
  <div class='contest-page'>
    <br>
    <el-row :gutter="20">
      <el-col :span="4">
        <el-input v-model="searchText" placeholder="搜索队伍名、队长名或标签" clearable @input="filterTeams">
          <template v-slot:prefix>
              <i  class="el-input__icon el-icon-search"></i>
          </template>
        </el-input>
      </el-col>
      <el-col :span="4">
        <el-select v-model="selectedType" placeholder="选择比赛类型" @change="searchData()">
          <el-option label="所有类型" value=""></el-option>
          <el-option
            v-for="type in allTypes"
            :key="type"
            :label="type"
            :value="type"
            @click="searchData()"
          ></el-option>
        </el-select>
      </el-col>
      <el-col :span="4">
        <el-select v-model="selectedStatus" placeholder="选择状态" @change="$forceUpdate(),searchData()">
          <el-option label="所有状态" value=""></el-option>
          <el-option label="招募中" value="招募中"></el-option>
          <el-option label="招募完成" value="招募完成"></el-option>
        </el-select>
      </el-col>
      <el-col :span="4">
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
          <el-table-column prop="race" label="比赛名称" width="200">
            <template v-slot="scope">
              <span>{{ scope.row.race }}</span>
            </template>
          </el-table-column>
          <el-table-column prop="type" label="比赛类型" width="100">
            <template v-slot="scope">
              <span>{{ scope.row.type }}</span>
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
              <el-tag v-for="tag in scope.row.tags" 
                      :key="tag" 
                      style="margin-right: 5px;"
                      @click="addTags(tag), searchData()"
                      >{{ tag }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column label="操作" width="150">
            <template v-slot="scope">
              <el-popover placement="right" :width="400" trigger="click">
                <template #reference>
                  <el-button style="margin-right: 16px" type="primary">查看详情</el-button>
                </template>
                <div>
                  <h3>{{ scope.row.name }}</h3>
                  <p>{{ scope.row.description }}</p>
                  <p>比赛类型: {{ scope.row.type }}</p>
                  <p>队长: {{ scope.row.leaderName }}</p>
                  <p>当前人数: {{ scope.row.currentMembers }}/{{ scope.row.totalMembers }}</p>
                  <p>状态: 
                    <el-tag :type="scope.row.status === '招募中' ? 'success' : 'danger'">
                      {{ scope.row.status }}
                    </el-tag>
                  </p>
                  <p>标签: 
                    <el-tag
                      v-for="tag in scope.row.tags"
                      :key="tag"
                      style="margin-right: 5px;"
                    >
                      {{ tag }}
                    </el-tag>
                  </p>
                </div>
              </el-popover>

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
          name: 'see you again',
          leaderName: '牢大',
          leaderAvatar: 'https://via.placeholder.com/150',
          race: '直升机赛',
          description: '孩子们，我回来了',
          type: '国赛',
          currentMembers: 10,
          totalMembers: 200,
          status: '招募中',
          tags: ['直升机', '篮球', '冰红茶']
        },
        {
          name: '姬霓太美',
          leaderName: '坤坤',
          leaderAvatar: 'https://via.placeholder.com/150',
          race:'篮球赛',
          description: '迎面而来的你让我如此蠢蠢欲动',
          type: '校内赛',
          currentMembers: 15,
          totalMembers: 20,
          status: '招募中',
          tags: ['小黑子', '坤坤', '篮球']
        },
        {
          name: '双料高级特工',
          leaderName: '催逝员',
          leaderAvatar: 'https://via.placeholder.com/150',
          race:'厨艺比赛',
          description: '诶嘿嘿，鸡汤来喽。这菜都上齐了，大家怎么都不吃啊',
          type:'校内赛',
          currentMembers: 4,
          totalMembers: 4,
          status: '招募结束',
          tags: ['厨艺', '鸡汤']
        }
        // 其他队伍数据按照上面的格式对齐
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
      const allTags = new Set();
      this.teams.forEach(team => {
        team.tags.forEach(tag => allTags.add(tag));
      });
      return Array.from(allTags);
    },
    allTypes() {
      const allTypes = new Set();
      this.teams.forEach(team => {
        allTypes.add(team.type);
      });
      return Array.from(allTypes);
    }
  },
  created() {
    this.filteredTeams = this.teams;
  },
  methods: {
    filterTeams() {
      this.filteredTeams = this.teams.filter(team => {
        // 根据搜索框内容、状态、标签、比赛类型筛选条件
        const searchText = this.searchText.toLowerCase();
        const matchesSearchText = team.name.toLowerCase().includes(searchText) ||
                                  team.leaderName.toLowerCase().includes(searchText) ||
                                  team.tags.some(tag => tag.toLowerCase().includes(searchText));
        const matchesStatus = this.selectedStatus ? team.status === this.selectedStatus : true;
        const matchesTags = this.selectedTags.length ? this.selectedTags.every(tag => team.tags.includes(tag)) : true;
        const matchesType = this.selectedType ? team.type === this.selectedType : true;
        return matchesSearchText && matchesStatus && matchesTags && matchesType;
      });
    },
    
    showTeamProfile(leaderName) {
      alert(`查看${leaderName}的个人简介`);
    },

    addTags(tag) {
      this.selectedTags.push(tag);
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
      // 根据比赛类型筛选
      if (this.selectedType) {
        data = data.filter(item => item.type === this.selectedType);
      }
      this.filteredTeams = data;
    }
  }
}
</script>