<!--填充表-->
<script>
    import { ref } from 'vue';

    export default {
        data() {
            return {
                // 图片数组
                images: [
                    //使用相对路径
                    { img: './src/components/icons/1.png', alt: '挑战杯' ,url:"https://www.tiaozhanbei.net/"},
                    { img: './src/components/icons/2.png', alt: '创新创业大赛' ,url:"https://cy.ncss.cn/"},
                    { img: './src/components/icons/3.png', alt: '中国国际大学生创新大赛' ,url:"https://cy.ncss.cn/en/notifications/8a80808d8f765e32018fdd6003c20084"}
                    // 更多图片...
                ],
                // 留言板的数据
                message: "",
                othersMessages: [
                    { id: 1, content: "这是其他人的留言 1" },
                    { id: 2, content: "这是其他人的留言 2" },
                    { id: 3, content: "这是其他人的留言 3" },
                ],
                races: [
                    { id: 1, time: "2024 年 8 月  1 日", content: "iCAN创新创业大赛校园赛",url:"http://g-ican.com/competition/ICAN2024"},
                    { id: 2, time: "2024 年 8 月 16 日", content: "中国国际大学生创新大赛",url:"https://cy.ncss.cn/en/notifications/8a80808d8f765e32018fdd6003c20084"},
                ]
            };
        },
        setup() {
            const fill = ref(true); // 这里使用ref定义响应式数据
            return {
                fill,
            };
        },
        methods: {
            submitMessage() {
                // 在这里可以添加提交留言的逻辑
                console.log("提交留言：", this.message);
                this.message = ""; // 清空输入框
            },
            Goto(url){
                window.open(url); // 跳转到url
            }
        },
    };
</script>

<template>
    <!--走马灯-->
    <el-carousel :interval="4000" type="card" height="300px">
        <el-carousel-item v-for="item in images" :key="item">
           <img :src="item.img" :alt="item.alt" style="height:300px;width:700px" @click="Goto(item.url)">
        </el-carousel-item>
    </el-carousel>
    <!--走马灯--> 
    <hr size="2px" color="2xl" width="100%">
    <el-row>
        <el-col :span="12">
            <!--时间线-->
            <h2>近期比赛</h2>
            <el-timeline v-for="race in races" :key="race.id" style="width: 500px">
                <el-timeline-item :timestamp="race.time" placement="top">
                    <el-card>
                        <h4 @click="Goto(race.url)">{{ race.content }}</h4>
                    </el-card>
                </el-timeline-item>
            </el-timeline>
        </el-col>

        <!--时间线-->
        <!--留言板-->
        <el-col :span="12">

            <div class="message-board">
                <h2>交流区</h2>
                <div class="others-messages" style="overflow-y: auto;height: 550px;padding: 15px;border: 1px solid #dee2e6;border-radius: 5px;background-color: #fff;">
                    <div v-for="msg in othersMessages" :key="msg.id">
                        {{ msg.content }}
                    </div>
                </div>
                <textarea v-model="message" placeholder="输入您的想法或问题"></textarea>
                <button @click="submitMessage">提交</button>
            </div>
        </el-col>


        <!--留言板-->
    </el-row>

   <hr size="2px" color="2xl">
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
    .el-row {
        margin-bottom: 20px;
    }

        .el-row:last-child {
            margin-bottom: 0;
        }

    .el-col {
        border-radius: 4px;
    }

    .grid-content {
        border-radius: 4px;
        min-height: 36px;
    }
   /*<!-- 留言板-->*/
    /* 留言板样式 */
    .message-board {
        width: 400px;
        margin: 0 auto;
        padding: 20px;
        background-color: #f8f9fa;
        border: 1px solid #dee2e6;
        border-radius: 4px;
    }
        /* 标题样式 */
        .message-board h2 {
            margin-top: 0;
        }
        /* 文本区域样式 */
        .message-board textarea {
            width: 100%;
            height: 100px;
            padding: 10px;
            border: 1px solid #dee2e6;
            border-radius: 4px;
            resize: none;
        }
        /* 提交按钮样式 */
        .message-board button {
            display: block;
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            /* 提交按钮悬停样式 */
            .message-board button:hover {
                background-color: #0056b3;
            }
   /* <!-- 留言板-->*/
</style>
