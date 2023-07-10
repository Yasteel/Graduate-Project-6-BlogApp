<script setup>
    import { reactive } from 'vue';
    import { store } from './store.ts'

    const loginData = reactive({
        username: null,
        password: null,
        rememberMe: false
    })

    const attemptLogin = () => {
        let obj = {
            Email: loginData.username,
            Password: loginData.password,
            RememberMe: loginData.rememberMe
        }

        if(obj.Email == null || obj.Password == null){
            alert("Fields cannot be Empty ");
            return;
        }

        login(obj, (res) => {

            getUserName(res.data.token, (resolve) => {

                store.loggedIn = true;
                store.userEmail = resolve.data;
                store.token = res.data.token;

                sessionStorage.setItem("storeData", JSON.stringify(store));
                
                alert("Login Success.");
                window.location.href="https://localhost:7183/Home/Index";


            }, (reject) => {
    
                var errors = ``;
                for(const key in rej.response.data.errors){
                    errors += `${rej.response.data.errors[key].toString()}\n`
                }
                alert(errors);
            });


        }, (rej) => {

            var errors = ``;
            for(const key in rej.response.data.errors){
                errors += `${rej.response.data.errors[key].toString()}\n`
            }
            alert(errors);
        })
    }
</script>

<template>
    <div class="overlay">
        <div class="loginContainer">
            <div class="dataRow">
                <label for="inpUsername">Username</label>
                <input type="email" id="inpUsername" v-model="loginData.username" >
            </div>
            <div class="dataRow">
                <label for="inpPassword">Password</label>
                <input type="password" id="inpPassword" v-model="loginData.password" >
            </div>
            <div class="dataRow">
                <label for="inpRememberMe">Remember Me</label>
                <input type="checkbox" id="inpRememberMe" v-model="loginData.rememberMe" >
            </div>
            <div class="dataRow">
                <button @click="attemptLogin">Login</button>
                <p>Don't Have an Account? <span><a href="/Auth/Register">Register Here</a></span></p>
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
        color: var(--text);
    }

    .loginContainer{
        width: 550px;
        padding: 2rem;
        display: flex;
        flex-direction: column;
        gap: 1rem;
        background: hsl(0 0% 15%);
        box-shadow: 0 0 15px 0 hsl(0 0% 5%);
    }

    .dataRow:not(:last-child){
        display: flex;
        gap: 2rem;
        align-items: center;
    }

    .dataRow:last-child{
        display: flex;
        flex-direction: column;
        align-items: center;
        margin: 1rem 0;
    }

    label{
        display: block;
        width: 7rem;
        text-align: right;
    }

    input:not(input[type="checkbox"]){
        flex-grow: 1;
        height: 40px;
        padding: .5rem;
        background: none;
        border: none;
        outline: none;
        box-shadow: 0 0 5px 0 hsl(0 0% 5%);
        color: var(--text);
        transition: box-shadow 200ms ease-in-out;
    }

    input:not(input[type="checkbox"]):focus{
        box-shadow: 0 0 5px 0 var(--accent);
        color: hsl(0 0% 90%);
    }

    button{
        width: 100%;
        padding: .5rem 0;
        margin: 0 0 1rem 0;  
        border: none;
        outline: none;
        background: var(--accent);
        cursor: pointer;
        transition: background 200ms ease-in-out;
    }

    button:hover{
        background: hsl(159, 98%, 61%);
    }

    a{
        color: var(--text);
        transition: color 200ms ease-in-out;
    }

    a:is(:hover, :focus){
        color: var(--accent);
    }
</style>