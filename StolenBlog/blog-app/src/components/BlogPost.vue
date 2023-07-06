<script setup lang="ts">
    import { reactive } from "vue"
    import Comments from "./Comments.vue"

    import '../style.css'
    
    const viewSettings = reactive({
        loggedIn: false,
        showComments: false,
        addComment: false,
    })

    const newComment = reactive({
        comment: ""
    })

    const postInfo = reactive({
        displayName: "Yasteel Gungas",
        content: `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut congue pretium suscipit. Etiam a aliquam leo, nec malesuada augue. Aliquam pulvinar condimentum nisl sit amet venenatis. Ut ex ex, interdum eget odio ac, scelerisque aliquam nibh. Cras placerat consequat sapien. Morbi porttitor lacinia est. Donec eu ligula diam.
                  Maecenas a justo nunc. Suspendisse potenti. Nunc hendrerit gravida ligula imperdiet semper. Aliquam ornare nibh est, sit amet vestibulum magna feugiat non. Donec ac tellus orci. Integer blandit nibh vitae diam ornare volutpat vitae ut est. Nunc diam lacus, venenatis placerat elit elementum, volutpat gravida elit. Cras sit amet luctus neque, commodo gravida eros. Maecenas lacinia quis mi vitae bibendum.`,
        timestamp: "12 minutes ago",
        comments: [
            {
                id: 2,
                displayName: "Steelios",
                content: "This is a test comment",
                timestamp: "154 minutes ago"
            }
        ]
    })

    const showComments = () => {
        viewSettings.showComments = !viewSettings.showComments;
    }

    const showAddComment = () => {
        newComment.comment = "";
        viewSettings.addComment = !viewSettings.addComment;
    }

    const postComment = () => {
        alert(newComment.comment);
    }

</script>

<template>
    <div class="postContainer">
        <div class="header">
            <p class="name">{{ postInfo.displayName }}</p>
            <p class="timestamp">{{ postInfo.timestamp }}</p>
        </div>
        <div class="content">
            <p>{{ postInfo.content }}</p>
        </div>
        <div class="commentAction">
            <p> 
                <a href="#" @click="showComments">
                    <span v-if="viewSettings.showComments">Hide Comments</span>
                    <span v-else>Show Comments</span>
                </a>
            </p>
            <button @click="showAddComment">
                <span v-if="viewSettings.addComment">Cancel</span>
                <span v-else>Post Comment +</span>
            </button>
        </div>
        <div class="addComment" v-if="viewSettings.addComment">
            <textarea v-model="newComment.comment"></textarea>
            <button @click="postComment">Post Comment</button>
        </div>
        <div class="comments" v-if="postInfo.comments.length > 0 && viewSettings.showComments">
            
            <Comments v-for="comment in postInfo.comments" :key="comment.id" :content="comment"/>
        </div>
    </div>
</template>

<style scoped>
    .postContainer{
        margin-top: 2rem;
        width: 800px;
        padding: 1.5rem;
        display: flex;
        flex-direction: column;
        align-items: flex-start;
        gap: 1rem;
        border-left: 5px solid var(--accent);
        box-shadow: 0 0 10px 0px hsl(0 0% 10%);

    }

    .header{
        width: 100%;
        display: flex;
        flex-direction: row;
        justify-content: space-between;
    }

    .timestamp, .content p, .commentAction a{
        color: var(--text);
    }

    .name{
        color: var(--accent);
        font-size: 1.1rem;
        font-weight: 650;
    }

    .commentAction{
        display: flex;
        justify-content: space-between;
        width: 100%;
    }

    .commentAction button{
        background: none;
        border: none;
        border: none;
        color: var(--text);
        font-size: 1.0rem;
        cursor: pointer;
        transition: color 200ms ease-in-out;
    }

    .commentAction :is(button:hover, .commentAction a:hover){
        color: var(--accent);
    }

    .addComment{
        width: 100%;
        display: flex;
        flex-direction: column;
        align-items: flex-start;
        gap: 1rem;
    }

    .addComment textarea{
        width: 100%;
        height: 100px;
        background: none;
        padding: .5rem;
        border: none;
        outline: none;
        resize: none;
        color: var(--text);
        box-shadow: 0 0 5px 0 hsl(0 0% 05%);
    }

    .addComment button{
        padding: .5rem 1rem;
        background: var(--accent);
        border: none;
        outline: none;
        font-weight: 600;
        cursor: pointer;
        transition: background 200ms ease-in-out;
    }

    .addComment button:hover{
        background: hsl(159, 98%, 61%)
    }

    .comments{
        width: 100%;
        padding: 2rem 0;
        display: flex;
        flex-direction: column;
        justify-content: flex-end;
        gap: 1.5rem;
        /* border-top: 1px solid var(--shadow) */
    }

</style>