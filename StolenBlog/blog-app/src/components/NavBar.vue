<script setup>
    import { reactive, ref, onMounted } from 'vue'
    import NewPostForm from "./NewPostModal.vue"

    const viewSettings = reactive({
        loggedIn: true,
        displayName: ""
    })

    const props = defineProps({
        viewSettings: {
            loggedIn: false,
            displayName: ""
        }
    })

    const form = ref(null);
</script>

<template>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark mb-3">
            <div class="container-fluid">
                <a class="navbar-brand">StolenBlog</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm">
                    <ul class="navbar-nav">
                        <div class="left">
                            <li class="nav-item">
                                <a class="nav-link" href="/Home/Index">Home</a>
                            </li>
                            <li class="nav-item" v-if="viewSettings.loggedIn">
                                <a class="nav-link">Profile</a>
                            </li>
                        </div>
                        <div class="right" v-if="!viewSettings.loggedIn">
                            <li class="nav-item">
                                <a class="nav-link" href="/Auth/Login">Login</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="/Auth/Register">Register</a>
                            </li>
                        </div>
                        <div class="right" v-else>
                            <li class="nav-item">
                                <a class="nav-link" @click="form.open">New Post</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link">Account</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link">Log out</a>
                            </li>
                        </div>
                    </ul>
                </div>
            </div>
        </nav>
        <div>
        <NewPostForm ref="form"></NewPostForm>
    </div>
</template>

<style scoped>
    nav{
        background: hsl(0, 0%, 5%)
    }

    .navbar-brand{
        color: var(--accent);
    }

    ul.navbar-nav{
        display: flex;
        justify-content: space-between;
        flex-grow: 1;
    }

    ul div:is(.left, .right){
        display: flex;
    }

    ul.navbar-nav a{
        color: var(--text);
        cursor: pointer;
        transition: color 200ms ease-in-out;
    }
    ul.navbar-nav a:hover{
        color: var(--accent);
    }
</style>