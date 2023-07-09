<script setup>
  import { reactive, onMounted } from 'vue' 
  import BlogPost from './components/BlogPost.vue'

  const postData = reactive({
    posts: []
  })



  onMounted(() => {
    getPosts((resolve) => {
      console.log(resolve);
      postData.posts = resolve.data
    }, (rej)=> {

    });
  })



</script>

<template>
  <div>
    <BlogPost v-for="post in postData.posts" :content="post"/>


  </div>
</template>

<style scoped>
  div{
    display: grid;
    place-items: center;
  }
</style>
