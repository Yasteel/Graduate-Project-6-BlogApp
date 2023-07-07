<script setup>
    import { reactive, onMounted, onRenderTriggered } from 'vue';
    // import { store } from './store.ts'
    
    // onMounted(()=> {
    //     // console.log(store.loggedIn);
    // })

    // onRenderTriggered((e) => {
    //     if(e.newValue){
    //         console.log(store.loggedIn);
    //     }
    // })

    const blogPostData = reactive({
        blogId: 0,
        heading: "",
        description: "",
        imageId: 0
    })


    const display = reactive({
        show: false
    })

    const close = () => {
        display.show = false
    }

    const open = () => {
        display.show = true
    }

    const showData = () => {
        alert(JSON.stringify(blogPostData));
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
                    <option value="">Tech</option>
                    <option value="">Food</option>
                    <option value="">Animals</option>
                    <option value="">Anime</option>
                    <option value="">Porn</option>
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
                <button @click="showData">Save</button>
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