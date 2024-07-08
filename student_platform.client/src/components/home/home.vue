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
    <el-row>
        <!-- 走马灯 -->
        <!-- 右侧日历 -->
        <el-col :span="12">
            <div class="calendar-container">
                <el-calendar v-loading="loading">
                  <template #dateCell="{data}">
                    <div
                      class="custom-date"
                      @mouseenter="handleMouseEnter(data.date)"
                      @mouseleave="handleMouseLeave"
                    >
                      {{ data.day.split('-').slice(-1)[0] }}
                    </div>
                  </template>
                </el-calendar>
                <el-popover 
                  v-model:visible="isPopoverVisible"
                  placement="bottom"
                  width="300"
                >
                  <p>详细信息: {{ selectedDateInfo }}</p>
                  <template v-slot:reference>
                    <div class="trigger-area" ></div>
                  </template>
                </el-popover>
              </div>
        </el-col>
        <el-col :span="12">
            <el-carousel :interval="5000" arrow="always">
                <el-carousel-item v-for="item in content_pages" :key="item">
                <h3 text="2xl" justify="center">{{ item }}</h3>
                </el-carousel-item>
            </el-carousel>
        </el-col>
    </el-row>
</template>

<style>

</style>