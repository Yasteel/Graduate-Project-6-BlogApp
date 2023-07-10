<script setup>
    import { reactive, onMounted, onRenderTriggered } from 'vue';
    import { store } from './store.ts'

    const blogData = reactive({
        userid: null,
        name: null,
        description: null,
        imageId: null
    });

    const props = defineProps({
        content: null
    })

    onMounted(() => {
        
    })

    const display = reactive({
        show: false
    });

    const close = () => {
        display.show = false;
    };

    const open = () => {
        display.show = true;
    };

    const addNewBlog = () => {
        if(blogData.name != null || blogData.description != null){
            getUserByEmail(store.userEmail,
            (res) => {
                blogData.userid = res.data.userId;

                createBlog(blogData, store.token,
                (res) => {
                    if(res.status == 204){
                        alert("Success");
                        display.show = false;
                    }
                },
                (error) => {
                    console.log(error);
                });
            },
            (rej) => {
                console.log(rej);
            })
        }
        else{
            alert("Fill in all the Fields");
        }
    }

    defineExpose({
        open
    })
</script>

<template>
    <div class="overlay" v-if="display.show">
        <h2>New Blog</h2>
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
                <button @click="addNewBlog">Save</button>
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
        display: flex;
        flex-direction: column;
        justify-content: center;
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
        /* align-items: center; */
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