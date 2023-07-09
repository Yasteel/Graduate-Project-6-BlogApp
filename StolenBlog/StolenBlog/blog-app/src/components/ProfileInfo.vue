<script setup>
    import { reactive, onMounted } from 'vue'

    const viewSettings = reactive({
        editing: false
    })

    const userInfo = reactive({
        email: "yasteel.gunga01@gmail.com",
        name: "Yasteel",
        surname: "Gungapursat",
        displayName: "Steel",
        dateOfBirth: new Date("1998/08/04")
    })
</script>

<template>
    <section class="profileInfoSection">
        <div class="infoDisplayContainer" v-if="viewSettings.editing == false">
            <div class="rowData">
                <label for="email">Email</label>
                <p id="email">{{ userInfo.email }}</p>
            </div>
            <div class="rowData">
                <label for="name">Name</label>
                <p id="name">{{ userInfo.name }}</p>
            </div>
            <div class="rowData">
                <label for="surname">Surname</label>
                <p id="surname">{{ userInfo.surname }}</p>
            </div>
            <div class="rowData">
                <label for="displayName">DisplayName</label>
                <p id="displayName">{{ userInfo.displayName }}</p>
            </div>
            <div class="rowData">
                <label for="dob">Date of Birth</label>
                <p id="dob">{{ userInfo.dateOfBirth.toLocaleDateString() }}</p>
            </div>
            <div class="rowData">
                <button @click="viewSettings.editing = true">Edit</button>
            </div>
        </div>
        <div class="infoEditContainer" v-else>
            <div class="rowData">
                    <label for="email">Email</label>
                <input type="text" disabled v-model="userInfo.email">
            </div>
            <div class="rowData">
                    <label for="name">Name</label>
                <input type="text" v-model="userInfo.name">
            </div>
            <div class="rowData">
                    <label for="surname">Surname</label>
                <input type="text" v-model="userInfo.surname">
            </div>
            <div class="rowData">
                    <label for="displayName">DisplayName</label>
                <input type="text" v-model="userInfo.displayName">
            </div>
            <div class="rowData">
                    <label for="dob">Date of Birth</label>
                <input type="date" v-model="userInfo.dateOfBirth">
            </div>
            <div class="rowData">
                <button>Update</button>
                <button @click="viewSettings.editing = false">Cancel</button>
            </div>
        </div>
    </section>
</template>

<style scoped>
    p{
        padding: 0;
        margin: 0;
    }

    section{
        display: grid;
        place-items: center;
        margin-bottom: 1rem;
    }

    section > div{
        display: flex;
        flex-direction: column;
        width: 350px;
        padding: 1rem 2rem;
        gap: 1rem;
        color: var(--text);
        box-shadow: var(--box-shadow);
    }

    label{
        font-weight: 100;
        font-size: .8rem;
    }

    p{
        font-size: .9rem;
    }

    .rowData{
        display: flex;
        flex-direction: column;
    }

    .rowData:last-child{
        display: flex;

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
        flex-grow: 1;
        margin: 0 0 1rem 0;  
    }

</style>