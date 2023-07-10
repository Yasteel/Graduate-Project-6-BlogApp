<script setup>
    import { reactive } from 'vue';

    const registerData = reactive({
        password: null,
        repeatPassword: null,
        email: null,
        firstName: null,
        surname: null,
        displayName: null,
        dateOfBirth: null
    })

    const onRegisterClick = () => {
        if(registerData.email == null || registerData.password == null || registerData.repeatPassword == null || registerData.firstName == null || registerData.surname == null || registerData.displayName == null || registerData.dateOfBirth == null){
            alert("Enter information into all fields");
        }
        else{
            register(registerData,
            (res) => {
                alert("Registration Successful.");
                window.location.href = "/Auth/Login";
            }, 
            (rej) => {
                var errors = `Error:\n`;
                for(const key in rej.response.data.errors){
                    errors += `${rej.response.data.errors[key].toString()}\n`
                }
                alert(errors);
                console.log(rej);
            })
        }
    }

</script>

<template>
    <div class="overlay">
        <div class="loginContainer">
            <div class="dataRow">
                <label for="inpEmail">Email</label>
                <input type="email" id="inpEmail" v-model="registerData.email" >
            </div>
            <div class="dataRow">
                <label for="inpPassword">Password</label>
                <input type="password" id="inpPassword" v-model="registerData.password" >
            </div>
            <div class="dataRow">
                <label for="inpRepeatPassword">Repeat Password</label>
                <input type="password" id="inpRepeatPassword" v-model="registerData.repeatPassword" >
            </div>

            <div class="dataRow">
                <label for="inpFirstName">First Name</label>
                <input type="text" id="inpFirstName" v-model="registerData.firstName" >
            </div>
            <div class="dataRow">
                <label for="inpSurname">Surname</label>
                <input type="text" id="inpSurname" v-model="registerData.surname" >
            </div>
            <div class="dataRow">
                <label for="inpDisplayName">Display Name</label>
                <input type="text" id="inpDisplayName" v-model="registerData.displayName" >
            </div>
            <div class="dataRow">
                <label for="inpDateOfBirth">Date of Birth</label>
                <input type="date" id="inpDateOfBirth" v-model="registerData.dateOfBirth" >
            </div>
            <div class="dataRow">
                <button @click="onRegisterClick">Register</button>
                <p>Already Have an Account? <span><a href="/Auth/Login">Login Here</a></span></p>
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