<script setup>
    import { reactive, onMounted, computed } from "vue"

    const props = defineProps({
        content: {}
    });

    onMounted(() => {
        console.log(props.content);
    })

    const getTimeDifference = computed(() => {
        let now = new Date();
        let diff = now - new Date(props.content.dateUpdated);
        
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
            var date = new Date(props.content.dateUpdated);
            return date.toLocaleDateString();
        }
    })

</script>

<template>
    <div class="commentContainer">
        <div class="header">
            <p class="name">{{ props.content.displayName }}</p>
            <p class="timestamp">{{ getTimeDifference }}</p>
        </div>
        <div class="content">
            <p>{{ props.content.comment }}</p>
        </div>
    </div>
</template>

<style scoped>
    .commentContainer{
        width: 100%;
        padding: 1.5rem;
        display: flex;
        flex-direction: column;
        align-items: flex-start;
        gap: 1rem;
        /* border: 1px solid var(--shadow); */
        border-left: 5px solid var(--tertiary);
        box-shadow: 0 0 10px 0px hsl(0 0% 10%);
        /* box-shadow: 0 0 10px 0px hsl(0, 0%, 100%); */
    }

    .header{
        width: 100%;
        display: flex;
        flex-direction: row;
        justify-content: space-between;
    }

    .timestamp, .content p{
        color: var(--text);
    }

    .name{
        color: var(--tertiary);
        font-size: 1.1rem;
        font-weight: 650;
    }

</style>