import { createWebHistory, createRouter } from 'vue-router'

const routes = [
    {
        path: "/",
        component: () => import ("../views/MainView.vue"),
        name: "Main"
    },
    {
        path: "/login",
        component: () => import ("../components/LoginForm.vue"),
        name: "Login"
    },
    {
        path: "/register",
        component: () => import ("../components/CreateAccount.vue"),
        name: "Register"
    },
    {
        path: "/details",
        component: () => import ("../views/UserAccountView.vue"),
        name: "UserAccountView",
        children: [
            {
                path: "account",
                component: () => import ("../components/UserAccount.vue"),
                name: "UserAccount"
            },
            {
                path: "orders",
                component: () => import ("../components/UserOrders.vue"),
                name: "orders"
            }
        ]
    },
    {
        path: "/changePass",
        component: () => import("../components/ChangePass.vue"),
        name : "changePass"
    }
        
]

const router = createRouter({
    routes,
    history: createWebHistory()
});

export default router;