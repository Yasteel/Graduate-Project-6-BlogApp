<script setup>
  import { reactive, onMounted, ref } from 'vue' 
  import BlogPost from './components/BlogPost.vue'
  import Loading from './components/Loading.vue'

  const postData = reactive({
    posts: []
  })

  const loadingScreen = ref(null);

  onMounted(() => {
    
    loadingScreen.showLoading;

    getPosts((resolve) => {
      console.log(resolve);

      hideLoading();

      postData.posts = resolve.data
    }, (rej)=> {
      alert(rej);
    });
  })

  const hideLoading = () => {
    loadingScreen.hideLoading;
  }


</script>

<template>
  <div>
    <BlogPost v-for="post in postData.posts" :content="post"/>


  </div>
  <Loading ref="loadingScreen"></Loading>
</template>

<style scoped>
  div{
    display: grid;
    place-items: center;
  }
</style>
