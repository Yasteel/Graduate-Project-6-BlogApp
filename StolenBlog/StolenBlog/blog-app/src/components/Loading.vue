<script setup>
    import { reactive } from 'vue';

    const viewSettings = reactive({
        show: false
    })

    const showLoading = () => {
        alert("loading");
        viewSettings.show = true;
    }

    const hideLoading = () => {
        viewSettings.show = false;
    }


    defineExpose({
        showLoading,
        hideLoading
    })
</script>

<template>
    <div v-if="viewSettings.show">
        <i class="fa-solid fa-spinner fa-spin"></i>
        <h3>Loading</h3>
    </div>
</template>

<style scoped>
    div{
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100vh;
        display: grid;
        place-items: center;
        background: hsl(0 0% 8%);
        color: var(--accent);

    }
</style>