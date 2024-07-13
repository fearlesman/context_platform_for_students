<template>
  <div class='contest-page'>
    <br>
    <el-row :gutter="20">
      <el-col :span="4">
        <el-input v-model="searchText" placeholder="搜索队伍名、队长名" clearable @input="filterTeams">
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
        <el-select v-model="selectedTags" multiple placeholder="选择需求标签" @change="searchData()">
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
              <el-avatar :src="scope.row.leaderAvatar" @click="showleaderProfile(scope.row.leaderName)"></el-avatar>
            </template>
          </el-table-column>
          <el-table-column label="所在学校" width="200">
            <template v-slot="scope">
              {{scope.row.University
              }}
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
              <el-popover placement="right" :width="500" trigger="click">
                <template #reference>
                  <el-button style="margin-right: 16px" type="primary">查看详情</el-button>
                </template>
                <div>
                  <h3>{{ scope.row.name }}</h3>
                  <p>{{ scope.row.description }}</p>
                  <p>比赛类型: {{ scope.row.type }}</p>
                  <p>队长: {{ scope.row.leaderName }}</p>
                  <p>当前人数: {{ scope.row.currentMembers }}/{{ scope.row.totalMembers }}</p>
                  <span>成员信息: </span>
                  <img :src="leaderAvatar">
                  <div class="member-images">
                    <div v-for="member in scope.row.members.slice(0,6)" :key="member.name">
                      <img :src="member.avatar" @click="showMemberProfile(member.id)">
                    </div>
                    <el-button v-if="scope.row.members.length > 5" @click="showMoreMembers">
                      查看更多
                    </el-button>
                  </div>
                  <p>状态: 
                    <el-tag :type="scope.row.status === 1 ? 'success' : 'danger'">
                      {{ scope.row.status }}
                    </el-tag>
                  </p>
                  <p>需求标签: 
                    <el-tag
                      v-for="tag in scope.row.tags"
                      :key="tag"
                      style="margin-right: 5px;"
                    >
                      {{ tag }}
                    </el-tag>
                  </p>
                  <el-button type="primary" @click="JoinTeam(scope.row.id)">加入</el-button>
                  <el-button type="danger" @click="ExitTeam(scope.row.id)">退出</el-button>
                </div>
              </el-popover>
            </template>
          </el-table-column>
        </el-table>
      </el-col>
    </el-row>
  </div>
</template>

<script >
  import axios from "axios";
  export default {
  data() {
      return {
          teams:[],
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
    axios.get('https://localhost:7201/api/Race/acm')
              .then(response => {
                  alert(response.data);
                  const a = JSON.stringify(response.data);
                  alert(a);
                  this.teams = JSON.parse(a);
              })
    this.filteredTeams = this.teams;
  },
  methods: {
    filterTeams() {
      this.filteredTeams = this.teams.filter(team => {
        // 根据搜索框内容、状态、标签、比赛类型筛选条件
        const searchText = this.searchText.toLowerCase();
        const matchesSearchText = team.name.toLowerCase().includes(searchText) ||
                                  team.leaderName.toLowerCase().includes(searchText) ||
                                  team.race.toLowerCase().includes(searchText)
                                  //||
                                  //team.tags.some(tag => tag.toLowerCase().includes(searchText));
        const matchesStatus = this.selectedStatus ? team.status === this.selectedStatus : true;
        const matchesTags = this.selectedTags.length ? this.selectedTags.every(tag => team.tags.includes(tag)) : true;
        const matchesType = this.selectedType ? team.type === this.selectedType : true;
        return matchesSearchText && matchesStatus && matchesTags && matchesType;
      });
    },
    
    showMemberProfile(memberId) {
      this.$router.push({ name: 'home', params: { memberId } });
    },

    showleaderProfile(leaderid) {
      this.$router.push({ name: 'home', params: { leaderid} });
    },

    addTags(tag) {
      if(!this.selectedTags.includes(tag))
      this.selectedTags.push(tag);
    },
    resetFilters() {
      this.searchText = '';
      this.selectedStatus = '';
      this.selectedTags = [];
      this.selectedType = '';
      this.filterTeams();
    },
    // 实时显示
      searchData() {
          axios.get('https://localhost:7201/api/Race')
              .then(response => {
                  const a = JSON.stringify(response.data);
                  alert(a);
                  this.teams = JSON.parse(a);
              })
      let data = this.teams; 
      for (let i = 0; i < data.length; i++) {
        if (data[i].status === 1)
        data[i].status = "招募中";
        else data[i].status = "招募完成";
      }
      // 根据状态筛选
      if (this.selectedStatus&&this.selectedStatus!="") {
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
    },
      JoinTeam(team_id) {
          const add={
      user_id: this.$store.state.userid,
      team_id: team_id
    }
  
          axios.post('https://localhost:7201/api/AddTeam',add )
      .then(response => {
        const a = response.data;
        if(a === 1)
        alert('加入队伍成功!');
        else  if ( a === 0 )
        alert('加入队伍失败!');
        else alert('你已经在队伍中!');
      })
    },
    ExitTeam(teamid) {
        let qwq= { user_id:this.$store.state.userid, team_id:teamid };
        axios.post('https://localhost:7201/api/Quiteam',qwq)
      .then(response => {
        const a = response.data;
        if(a === 1)
        alert('退出队伍成功!');
        else  if ( a === 0 )
        alert('退出队伍失败!');
        else alert('你不在队伍中!');
      })
    }
  }
}
</script>