<template>
    <el-radio-group v-model="tableLayout">
        <el-radio-button value="fixed">fixed</el-radio-button>
        <el-radio-button value="auto">auto</el-radio-button>
      </el-radio-group>
      <el-table :data="tableData" :table-layout="tableLayout">
        <el-table-column prop="date" label="Date" />
        <el-table-column prop="name" label="Name" />
        <el-table-column prop="address" label="Address" />
      </el-table>
</template>

<script>
export default {
  data() {
    return {
      activeIndex: '4', // 默认选中组队
      teams: [
        { name: 'MZY123', leader: '梦想组', status: '*招新中', capacity: 1, total: 12 },
        { name: '欢乐城堡组', leader: '3 MZY123', status: '*招新中', capacity: 1, total: 12 },
        // ... 更多队伍信息
      ]
    };
  },
  methods: {
    handleSelect(key, keyPath) {
      // 处理菜单选择
      console.log(key, keyPath);
    },
    joinTeam(team) {
      // 处理加入队伍的逻辑
      alert(`加入队伍：${team.name}`);
    }
  }
};
</script>

<style lang="scss" scoped>
</style>
