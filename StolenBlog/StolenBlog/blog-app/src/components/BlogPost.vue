<script setup>
    import { reactive, onMounted, computed } from "vue"
    import Comments from "./Comments.vue"
    import { store } from './store'

    const postInfo = reactive({
        postId: null,
        heading: "",
        displayName: "",
        content: "",
        timestamp: "",
        user: {},
        comments: []
    })

    const props = defineProps({
        content: {}
    })

    onMounted(() => {
        postInfo.postId = props.content.postId;
        postInfo.heading = props.content.heading;
        postInfo.displayName = props.content.users.displayName;
        postInfo.content = props.content.description;
        postInfo.timestamp = props.content.dateUpdated;
        postInfo.user = props.content.users;




        getComments(props.content.postId, 
        (res) => {
            if(res.data.length > 0){
                postInfo.comments = res.data
            }
        }, 
        (rej) => {

        })
    })

    const viewSettings = reactive({
        showComments: false,
        addComment: false,
    })

    const newComment = reactive({
        comment: ""
    })

    const showComments = () => {
        viewSettings.showComments = !viewSettings.showComments;
    }

    const showAddComment = () => {
        newComment.comment = "";
        viewSettings.addComment = !viewSettings.addComment;
    }

    const postComment = () => {

        getUserByEmail(store.userEmail, (res) => {
            var commentObj = {
                postId: postInfo.postId,
                comment: newComment.comment,
                userId: res.data.userId
            }

            createComment(commentObj, store.token,
            (result) => {
                alert("Comment Posted");
                viewSettings.addComment = false;
            }, 
            (error) => {
                alert(`error - 1 ${JSON.stringify(rej)}`);
            });

        }, (rej) => {
            console.log(rej);
        });
    }

    const getTimeDifference = computed(() => {
        let now = new Date();
        let diff = now - new Date(postInfo.timestamp);
        
        if( diff < (1000 * 60) ){
            return "a minute ago";
        }
        else if(diff < (1000 * 60 * 60)){
            return `${Math.floor(diff / (1000 * 60))}  minutes ago`;
        }
        else if(diff < (1000 * 60 * 60 * 24)){
            return `${Math.floor(diff / (1000 * 60 * 60))}  hours ago`;
        }
        else{
            var date = new Date(postInfo.timestamp);
            return date.toLocaleDateString();
        }
    })

</script>

<template>
    <div class="postContainer">
        <div class="header">
            <p class="name">{{ postInfo.displayName }}</p>
            <p class="timestamp">{{ getTimeDifference }}</p>
        </div>
        <div class="content">
            <h4>{{ postInfo.heading  }}</h4>
            <p>{{ postInfo.content }}</p>
        </div>
        <div class="commentAction">
            <p> 
                <a href="#" @click="showComments" v-if="postInfo.comments.length > 0">
                    <span v-if="viewSettings.showComments">Hide Comments</span>
                    <span v-else>Show Comments</span>
                </a>
            </p>
            <button @click="showAddComment" v-if="store.loggedIn">
                <span v-if="viewSettings.addComment">Cancel</span>
                <span v-else>Post Comment +</span>
            </button>
        </div>
        <div class="addComment" v-if="viewSettings.addComment">
            <textarea v-model="newComment.comment"></textarea>
            <button @click="postComment">Post Comment</button>
        </div>
        <div class="comments" v-if="postInfo.comments.length > 0 && viewSettings.showComments">
            
            <Comments v-for="comment in postInfo.comments" :key="comment.commentId" :content="comment"/>
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