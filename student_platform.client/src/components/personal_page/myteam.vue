<template>
    <div class="container">
      <h1>My Teams</h1>
  
      <el-row :gutter="20">
        <el-col :span="8" v-for="team in teams" :key="team.id">
          <el-card class="team-card">
            <template #header>
              <div class="card-header">
                <span>{{ team.name }}</span>
              </div>
            </template>
            <div class="team-info">
              <p>{{ team.description }}</p>
              <el-divider></el-divider>
              <h4>Members</h4>
              <ul>
                <li v-for="member in team.members" :key="member.id">{{ member.name }}</li>
              </ul>
            </div>
          </el-card>
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
            id: 1,
            name: 'Team A',
            description: 'Description of Team A',
            members: [
              { id: 1, name: 'Member 1' },
              { id: 2, name: 'Member 2' },
              { id: 3, name: 'Member 3' }
            ]
          },
          {
            id: 2,
            name: 'Team B',
            description: 'Description of Team B',
            members: [
              { id: 1, name: 'Member 1' },
              { id: 2, name: 'Member 2' },
              { id: 3, name: 'Member 3' }
            ]
          },
          {
            id: 3,
            name: 'Team C',
            description: 'Description of Team C',
            members: [
              { id: 1, name: 'Member 1' },
              { id: 2, name: 'Member 2' },
              { id: 3, name: 'Member 3' }
            ]
          }
        ]
      }
    }
  }
  </script>
  
  <style scoped>
  .container {
    max-width: 960px;
    margin: 0 auto;
    padding: 20px;
  }
  
  .team-card {
    height: 100%;
  }
  
  .card-header {
    font-weight: bold;
  }
  
  .team-info {
    padding: 10px 0;
  }
  
  ul {
    list-style-type: none;
    padding: 0;
  }
  
  li {
    margin-bottom: 5px;
  }
  </style>