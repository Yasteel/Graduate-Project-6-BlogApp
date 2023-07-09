<script setup>
    import { reactive, onMounted } from "vue"

    const props = defineProps({
        content: {}
    })

</script>

<template>
    <div class="commentContainer">
        <div class="header">
            <p class="name">{{ "Need DisplayName" }}</p>
            <p class="timestamp">{{ props.content.dateUpdated }}</p>
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