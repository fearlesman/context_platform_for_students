<script>
import { ref } from 'vue';
export default {

  data() {
    return {
      value : ref(new Date()),
      content_pages: [1,2,3,4], 
      activeIndex: '1',
      competitions: [
        { name: '第六届“光威杯”中国复合材料学会', time: '2023年3月', field: '新材料' },
        // ... 更多竞赛信息
      ],
      teams: [
        { name: '不挂机队', leader: 'MZY123', status: '招新中', competitions: 1 },
        // ... 更多队伍信息
      ],
      loading: false,
      isPopoverVisible: false,
      selectedDate: '',
      selectedDateInfo: '',
      methods: {
    handleMouseEnter(date) {
      this.selectedDate = date;
      this.isPopoverVisible = true;
      this.selectedDateInfo = `这是 ${date} 的信息。`; // 这里可以设置具体的信息内容
    },
    handleMouseLeave() {
      this.isPopoverVisible = false;
    },
  },
    };
  },
};
</script>

<template>
    <el-carousel :interval="4000" type="card" height="250px">
        <el-carousel-item v-for="item in 6" :key="item">
            <h3 text="2xl" justify="center">{{ item }}</h3>
        </el-carousel-item>
    </el-carousel>
</template>

<style scoped>
    .el-carousel__item h3 {
        color: #475669;
        opacity: 0.75;
        line-height: 200px;
        margin: 0;
        text-align: center;
    }

    .el-carousel__item:nth-child(2n) {
        background-color: #99a9bf;
    }

    .el-carousel__item:nth-child(2n + 1) {
        background-color: #d3dce6;
    }
</style>