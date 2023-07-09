import { reactive } from 'vue'

export const store = reactive({
    loggedIn: false,
    userEmail: null,
    token: null
});