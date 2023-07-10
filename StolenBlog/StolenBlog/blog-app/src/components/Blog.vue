<script setup>
    import { onMounted, reactive, ref } from 'vue';
    import { store } from './store';
    import NewBlogModal from './NewBlogModal.vue';

    const props = defineProps({
        content: null
    });

    const blogInfo = reactive({
        content: null
    })

    const editBlog = ref(null);

    onMounted(() => {
        blogInfo.content = props.content;
    })

    const deleteUserBlog = () => {

        // will need another component to verify/confirm deletion before

        deleteBlog(blogInfo.content.blogId, store.token,
        (res) => {
            if(blogInfo.content.postCount > 0){
                alert("Blog and Associated Posts and comments Deleted");
            }
            else{
                alert("Blog Deleted");
            }
        },
        (rej) => {
            alert(rej);
        });
    }

    const openEditBlog = () => {
        editBlog.open;
    }
</script>

<template>
    <div class="blog">
        <div class="cover">
            <i class="fa-regular fa-pen-to-square" @click="openEditBlog"></i>
            <i class="fa-solid fa-trash-can" @click="deleteUserBlog"></i>
        </div>
        <div class="content">
            <h2>{{ blogInfo.content.name }}</h2>
            <p>{{ blogInfo.content.description }}</p>
            <p class="numberofPosts">{{ blogInfo.content.postCount }} Posts</p>
        </div>
    </div>

    <NewBlogModal ref="editBlog" :content="props.content"></NewBlogModal>
</template>

<style scoped>
    .blog{
        min-height: 500px;
        box-shadow: var(--box-shadow);

    }

    .cover{
        background: hsl(159 98% 41%);
        height: 250px;
        display: flex;
        justify-content: flex-end;
        align-items: flex-start;
        gap: 1rem;
        padding: 1rem;
    }

    .cover i{
        padding: .5rem;
        font-size: 1.2rem;
        color: var(--text);
        cursor: pointer;
    }

    .cover i:is(:hover, :focus){
        color: black;
    }

    .content{
        min-height: 250px;
        display: flex;
        flex-direction: column;
        justify-content: space-around;
        padding: 1rem;
        color: var(--text);
    }

    .numberofPosts{
        font-size: .8rem;
    }
</style>

