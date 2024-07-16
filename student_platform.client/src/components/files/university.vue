<template>
    <div class="m-4">
        <el-select
        v-model="value"
        filterable
        placeholder="Select"
        style="width: 240px"
      >
        <el-option
          v-for="item in universities"
          :key="item.university"
          :label="item.university"
          :value="item.university"
        />
      </el-select>
      </div>
</template>
<script>
export default {

  data() {
    return {
      universityName: '',
    }
}
</script>