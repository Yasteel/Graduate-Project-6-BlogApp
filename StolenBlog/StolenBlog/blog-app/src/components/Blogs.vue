<script setup>
    import { reactive, onMounted } from 'vue'

    
</script>

<template>
    <section class="blogsSection">
            <div class="newBlog">
                <button>New Blog</button>
            </div>
            <div class="blogs">
                <div class="blog">
                    <div class="cover">
                        <i class="fa-regular fa-pen-to-square"></i>
                        <i class="fa-solid fa-trash-can"></i>
                    </div>
                    <div class="content">
                        <h2>Heading</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut congue pretium suscipit. Etiam a aliquam leo, nec malesuada augue. Aliquam pulvinar condimentum nisl sit amet venenatis.</p>
                        <p class="numberofPosts">6 Posts</p>
                    </div>
                </div>
                
                
            </div>
        </section>
</template>

<style scoped>
    section{
        margin-top: 1rem;
        padding: 2rem;
    }

    .blogs{
        margin: 1.5rem 0;
        display: grid;
        grid-template-columns: 1fr 1fr 1fr;
        gap: 2rem;
    }

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