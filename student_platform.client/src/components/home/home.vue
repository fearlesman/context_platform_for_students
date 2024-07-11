<!--填充表-->
<script lang="ts" setup>
    import { ref } from 'vue';
    const fill = ref(true)

</script>
<!--填充表-->

<template>
    <!--走马灯-->
    <el-carousel :interval="4000" type="card" height="300px">
        <el-carousel-item v-for="item in 6" :key="item">
            <h3 text="2xl" justify="center">{{ item }}</h3>
        </el-carousel-item>
    </el-carousel>
    <!--走马灯-->
    <!--时间线-->
    <el-timeline style="max-width: 600px">
        <el-timeline-item timestamp="2018/4/12" placement="top">
            <el-card>
                <h4>Update Github template</h4>
                <p>Tom committed 2018/4/12 20:46</p>
            </el-card>
        </el-timeline-item>
        <el-timeline-item timestamp="2018/4/3" placement="top">
            <el-card>
                <h4>Update Github template</h4>
                <p>Tom committed 2018/4/3 20:46</p>
            </el-card>
        </el-timeline-item>
        <el-timeline-item timestamp="2018/4/2" placement="top">
            <el-card>
                <h4>Update Github template</h4>
                <p>Tom committed 2018/4/2 20:46</p>
            </el-card>
        </el-timeline-item>
        <el-timeline-item timestamp="2018/4/2" placement="top">
            <el-card>
                <h4>Update Github template</h4>
                <p>Tom committed 2018/4/2 20:46</p>
            </el-card>
        </el-timeline-item>
        <el-timeline-item timestamp="2018/4/2" placement="top">
            <el-card>
                <h4>Update Github template</h4>
                <p>Tom committed 2018/4/2 20:46</p>
            </el-card>
        </el-timeline-item>
    </el-timeline>
    <!--时间线-->
    <!--填充表-->
    <div>
        <div style="margin-bottom: 15px">fill: <el-switch v-model="fill" /></div>
        <el-space :fill="fill" wrap>
            <el-card v-for="i in 3" :key="i" class="box-card">
                <template #header>
                    <div class="card-header">
                        <span>Card name</span>
                        <el-button class="button" text>find</el-button>
                    </div>
                </template>
                <div v-for="o in 4" :key="o" class="text item">
                    {{ 'List item ' + o }}
                </div>
            </el-card>
        </el-space>
    </div>
    <!--填充表-->

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
    /* <!-- 走马灯-- >*/

</style>
