<script setup>
    import { reactive, onMounted, computed } from 'vue';
    import { store } from './store';

    const viewSettings = reactive({
        editing: false
    });

    const userInfo = reactive({
        userId: null,
        email: null,
        firstName: null,
        surname: null,
        displayName: null,
        dateOfBirth: null
    });

    const originalUserInfo = reactive({
        userId: null,
        email: null,
        firstName: null,
        surname: null,
        displayName: null,
        dateOfBirth: null
    });

    onMounted(() => {
        getUserByEmail(store.userEmail,
        (res) => {
            userInfo.userId = res.data.userId;
            userInfo.email = res.data.email;
            userInfo.firstName = res.data.firstName;
            userInfo.surname = res.data.surname;
            userInfo.displayName = res.data.displayName;
            userInfo.dateOfBirth = res.data.dateOfBirth;
            
            originalUserInfo.userId = res.data.userId;
            originalUserInfo.email = res.data.email;
            originalUserInfo.firstName = res.data.firstName;
            originalUserInfo.surname = res.data.surname;
            originalUserInfo.displayName = res.data.displayName;
            originalUserInfo.dateOfBirth = res.data.dateOfBirth;
        },
        (rej) => {
            console.log(rej);
        });
    });

    const closeEdit = () => {
        userInfo.userId = originalUserInfo.userId;
        userInfo.email = originalUserInfo.email;
        userInfo.firstName = originalUserInfo.firstName;
        userInfo.surname = originalUserInfo.surname;
        userInfo.displayName = originalUserInfo.displayName;
        userInfo.dateOfBirth = originalUserInfo.dateOfBirth;

        viewSettings.editing = false;
    }

    const update = () => {
        editUser(userInfo.userId, JSON.stringify(userInfo), store.token,
        (res) => {
            originalUserInfo.userId = userInfo.userId;
            originalUserInfo.email = userInfo.email;
            originalUserInfo.firstName = userInfo.firstName;
            originalUserInfo.surname = userInfo.surname;
            originalUserInfo.displayName = userInfo.displayName;
            originalUserInfo.dateOfBirth = userInfo.dateOfBirth;

            viewSettings.editing = false;
        },
        (error) => {
            console.log(error);
        });
    };

    // const getLocaleDateString = computed((str) => {
    //     var date = new Date(str);
    //     return date.toLocaleDateString();
    // })
    
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
                <p id="name">{{ userInfo.firstName }}</p>
            </div>
            <div class="rowData">
                <label for="surname">Surname</label>
                <p id="surname">{{ userInfo.surname }}</p>
            </div>
            <div class="rowData">
                <label for="displayName">DisplayName</label>
                <p id="displayName">{{ userInfo.displayName }}</p>
            </div>
            <!-- <div class="rowData">
                <label for="dob">Date of Birth</label>
                <p id="dob">{{ userInfo.dateOfBirth }}</p>
            </div> -->
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
                <input type="text" v-model="userInfo.firstName">
            </div>
            <div class="rowData">
                    <label for="surname">Surname</label>
                <input type="text" v-model="userInfo.surname">
            </div>
            <div class="rowData">
                    <label for="displayName">DisplayName</label>
                <input type="text" v-model="userInfo.displayName">
            </div>
            <!-- <div class="rowData">
                    <label for="dob">Date of Birth</label>
                <input type="date" v-model="userInfo.dateOfBirth">
            </div> -->
            <div class="rowData">
                <button @click="update">Update</button>
                <button @click="closeEdit">Cancel</button>
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