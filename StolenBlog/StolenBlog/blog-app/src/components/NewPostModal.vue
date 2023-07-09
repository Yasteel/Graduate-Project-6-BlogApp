<script setup>
    import { reactive, onMounted, onRenderTriggered } from 'vue';
    import { store } from './store.ts'
    
    // onMounted(()=> {
    //     // console.log(store.loggedIn);
    // })

    // onRenderTriggered((e) => {
    //     if(e.newValue){
    //         console.log(store.loggedIn);
    //     }
    // })

    const userBlogs = reactive({
        blogs: []
    }) 

    const blogPostData = reactive({
        blogId: null,
        heading: null,
        description: null,
        imageId: null
    })


    const display = reactive({
        show: false
    })

    const close = () => {
        display.show = false
    }

    const open = () => {
        if(userBlogs.blogs.length < 1){
            getBlogs(store.userEmail, 
            (res) => {
                userBlogs.blogs = res.data;
            }, 
            (rej) => {
                console.log(rej);
            });
        }
        display.show = true
    }

    const addNewPost = () => {
        if(blogPostData.blogId == null || blogPostData.description == null)
        {
            alert("Fill In the Required Fields");
        }
        else{
            createPost(blogPostData, store.token,
            (res) => {
                console.log(res);
            },
            (rej) => {
                alert(rej);
            });
        }
    }

    defineExpose({
        open
    })
</script>

<template>
    <div class="overlay" v-if="display.show">
        <div class="inputContainer">
            <div class="dataRow">
                <label for="">Heading (optional)</label>
                <input type="text" v-model="blogPostData.heading">
            </div>
            <div class="dataRow">
                <label for="">Blog</label>
                <select v-model="blogPostData.blogId">
                    <option v-for="blog in userBlogs.blogs" :key="blog.blogId" :value="blog.blogId">{{ blog.name }}</option>
                </select>
            </div>
            <div class="dataRow">
                <label for="">Content</label>
                <textarea v-model="blogPostData.description"></textarea>
            </div>
            <div class="dataRow">
                <label for="">Image (optional)</label>
                <input type="file">
                <button>Upload</button>
            </div>
            <div class="dataRow">
                <button @click="addNewPost">Save</button>
                <button  @click="close">Cancel</button>
            </div>  
        </div>
    </div>
</template>

<style scoped>
    .overlay{
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
        background: hsl(0 0% 15% / 0.9);
        color: white;
        z-index: 0;
    }

    .inputContainer{
        width: 750px;
        padding: 2rem;
        display: flex;
        flex-direction: column;
        gap: 1rem;
        background: hsl(0 0% 15%);
        box-shadow: 0 0 15px 0 hsl(0 0% 5%);
        z-index: 2;
    }

    .dataRow{
        display: flex;
        gap: 1rem;
        align-items: center;
    }

    .dataRow:last-child{
        justify-content: flex-end;
    }

    label{
        display: block;
        width: 150px;
        text-align: right;
    }

    input, textarea, select{
        flex-grow: 1;
        height: 40px;
        padding: .5rem;
        background: none;
        border: none;
        outline: none;
        box-shadow: 0 0 5px 0 hsl(0 0% 5%);
        color: var(--text);
    }

    textarea{
        height: 150px;
    }

    button{
        padding: .5rem 1rem;
        border: none;
        outline: none;
        background: var(--accent);
        cursor: pointer;
        transition: background 200ms ease-in-out;
    }

    button:hover{
        background: hsl(159, 98%, 61%);
    }
</style>