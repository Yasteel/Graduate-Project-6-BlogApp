<script setup>
    import { reactive, onMounted, ref } from 'vue';
    import { store } from './store.ts';
    import NewBlogModal from './NewBlogModal.vue';
    import Blog from './Blog.vue';

    const blogModal = ref(null); // this is for the opening of the modal

    const blogObj = reactive({
        blogs: []
    })

    onMounted(() => {
        getBlogs(store.userEmail,
        (res) => {
            blogObj.blogs = res.data;
        },
        (rej) => {
            console.log(rej);
        });
    });




</script>

<template>
    <section class="blogsSection">
        <div class="newBlog">
            <button @click="blogModal.open">New Blog</button>
        </div>
        <div class="blogs">
            <Blog v-for="blog in blogObj.blogs" :key="blog.blogId" :content="blog"></Blog>
        </div>
    </section>
    <NewBlogModal ref="blogModal"></NewBlogModal>
</template>

<style scoped>
    section{
        margin-top: 1rem;

    }

    .blogs{
        margin: 1.5rem 0;
        display: grid;
        grid-template-columns: 1fr 1fr 1fr;
        gap: 2rem;
    }
</style>