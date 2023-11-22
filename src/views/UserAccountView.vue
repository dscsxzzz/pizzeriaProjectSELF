<template>
    <transition name="login-fade" appear>
        <div class="formContainer">
            <div class="head">
                <span></span>
                <button @click.prevent="router.push('/')">X</button>
            </div>
            <div class="main">
                <aside>
                    <button @click.prevent="router.push('/details/account')">Account Details</button>
                    <button @click.prevent="router.push('/details/orders')">Previous Orders</button>
                </aside>
                <router-view></router-view>
            </div>
        </div>
    </transition>
</template>
<script>
import UserOrders from '../components/UserOrders.vue';
import UserAccount from '../components/UserAccount.vue';
import { store } from '../store/store';
import router from '../router';
export default {
    components: { UserOrders, UserAccount },
    data() {
        return {
            store,
            router
        }
    }
}
</script>
<style scoped>
.formContainer{
    display: flex;
    flex-direction: column;
    width: 100%;
    height: 100svh;
    height: 100cqh;
    height: 100vh;
    padding: 2%;
    background-color: white;
}

.head{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    margin-bottom: 10px;
}
.main{
    display: grid;
    grid-template-columns: 1fr 10fr;
    height: 80svh;
    height: 80cqh;
}
aside{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}
button{
    border: none;
    padding: 10px;
    margin-bottom: 20px;
    max-width: 100px;
    font-weight: 600;
    background-color: #e68028;
    border-radius: 5px;
    box-shadow: 0px 0px 10px black;
    cursor: pointer;
}

</style>