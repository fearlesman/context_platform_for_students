<template>
  <el-select
  v-model="value"
  filterable
  placeholder="Select"
  style="width: 240px"
>
  <el-option
    v-for="item in options"
    :key="item.value"
    :label="item.label"
    :value="item.value"
  />
</el-select>
</template>
  
  <script >
  export default {
    data() {
      return {
        teams: [
          {
            name: 'see you again',
            leaderid:52,
            leaderName: '牢大',
            leaderAvatar: 'https://via.placeholder.com/150',
            members: [
              { name: '牢二', id : 1, avatar: 'https://via.placeholder.com/50' },
              { name: '牢三', id : 2, avatar: 'https://via.placeholder.com/50' },
              { name: '牢四', id : 3, avatar: 'https://via.placeholder.com/50' },
              { name: '牢五', id : 4, avatar: 'https://via.placeholder.com/50' },
              { name: '牢六', id : 5, avatar: 'https://via.placeholder.com/50' },
              { name: '牢七', id : 6, avatar: 'https://via.placeholder.com/50' },
              { name: '牢八', id : 7, avatar: 'https://via.placeholder.com/50' },
              { name: '牢九', id : 8, avatar: 'https://via.placeholder.com/50' },
              { name: '牢十', id : 9, avatar: 'https://via.placeholder.com/50' },
            ],
            University: '清华大学',
            race: '直升机赛',
            description: '孩子们，我回来了',
            type: '国赛',
            currentMembers: 10,
            totalMembers: 200,
            status: '招募中',
            tags: ['直升机', '篮球', '冰红茶']
          },{
            name: '姬霓太美',
            leaderid:114514,
            leaderName: '坤坤',
            leaderAvatar: 'https://via.placeholder.com/150',
            members: [
              { name: '姬霓一', id : 10, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓二', id : 11, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓三', id : 12, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓四', id : 13, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓五', id : 14, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓六', id : 15, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓七', id : 16, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓八', id : 17, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓九', id : 18, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓十', id : 19, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓十一', id : 20, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓十二', id : 21, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓十三', id : 22, avatar: 'https://via.placeholder.com/50' },
              { name: '姬霓十四', id : 23, avatar: 'https://via.placeholder.com/50' },
            ],
            University: '北京大学',
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
            leaderid:4,
            leaderName: '催逝员',
            leaderAvatar: 'https://via.placeholder.com/150',
            members: [
              { name: '特工一', id : 19, avatar: 'https://via.placeholder.com/50' },
              { name: '特工二', id : 20, avatar: 'https://via.placeholder.com/50' },
              { name: '特工三', id : 21, avatar: 'https://via.placeholder.com/50' },
            ],
            University: '北京航空航天大学',
            race:'厨艺比赛',
            description: '诶嘿嘿，鸡汤来喽。这菜都上齐了，大家怎么都不吃啊',
            type:'校内赛',
            currentMembers: 4,
            totalMembers: 4,
            status: '招募结束',
            tags: ['厨艺', '鸡汤']
          }
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
        alert(`查看${memberId}的个人信息`);
      },
  
      showleaderProfile(leaderName) {
        this.$router.push({ name: 'personal-profile', params: { userId: leaderName } });
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
      },
      JoinTeam() {
        alert('加入队伍成功!');
      }
    }
  }
  </script>