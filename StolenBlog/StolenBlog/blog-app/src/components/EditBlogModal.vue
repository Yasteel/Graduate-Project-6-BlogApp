<script setup>
    import { reactive, onMounted } from 'vue';
    import { store } from './store.ts'

    const blogData = reactive({
        blogId: null,
        description: null,
        imageId: null,
        name: null,
        userId: null
    });

    const display = reactive({
        show: false
    });

    const close = () => {
        display.show = false;
    };

    const open = (blogInfo) => {
        blogData.blogId = blogInfo.blogId;
        blogData.description = blogInfo.description;
        blogData.image = blogInfo.image;
        blogData.name = blogInfo.name;
        blogData.userId = blogInfo.userId;

        console.log(blogInfo);
        display.show = true;
    };

    const saveBlog = () => {
        var updatedBlogInfo = {
            blogId: blogData.blogId,
            description: blogData.description,
            imageId: blogData.imageId,
            name: blogData.name,
            userId: blogData.userId
        };

        console.log(updatedBlogInfo);

        editBlog(blogData.blogId, updatedBlogInfo, store.token,
        (res) => {
            alert("Blog Updated");
            display.show = false;
        },
        (rej) => {
            var errors = `Error:\n`;
            for(const key in rej.response.data.errors){
                errors += `${rej.response.data.errors[key].toString()}\n`
            }
            alert(errors);
            console.log(rej);
        })
    };

    defineExpose({
        open
    });
</script>

<template>
    <div class="overlay" v-if="display.show">
        <h2>Edit Blog</h2>
        <div class="inputContainer">
            <div class="dataRow">
                <label for="name">Name</label>
                <input type="text" id="name" v-model="blogData.name">
            </div>
            <div class="dataRow">
                <label for="description">Description</label>
                <textarea id="description" v-model="blogData.description"></textarea>
            </div>
            <div class="dataRow">
                <button @click="saveBlog">Save</button>
                <button @click="close">Cancel</button>
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
        padding: 2rem;
        display: flex;
        flex-direction: column;
        justify-content: flex-start;
        align-items: center;
        background: hsl(0 0% 15% / 0.9);
        color: white;
        z-index: 0;
    }

    .inputContainer{
        width: 500px;
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
        flex-direction: column;
        gap: 1rem;
    }

    .dataRow:last-child{
        justify-content: flex-end;
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