<script setup lang="ts">
import BlogPost from './components/BlogPost.vue'
</script>

<template>
  <div>
    <BlogPost />
    <BlogPost />

  </div>
</template>

<style scoped>
  div{
    display: grid;
    place-items: center;
  }
</style>
