<script setup>
import { ElCalendar, ElCard, ElCarousel, textProps } from 'element-plus';
import contest_page from "@/components/contest_page/contest_page.vue"
import login_page from "@/components/login_page/login_page.vue"
import home from "@/components/home/home.vue"
import register_page from "@/components/login_page/register.vue"
import personal_page from "@/components/personal_page/person.vue"
import markdown_page from "@/components/personal_page/markdown.vue"
import nav_page from '@/components/nav/nav.vue'
</script>

<template>
    <nav_page />
    <router-view />
</template>
<script>
</script>