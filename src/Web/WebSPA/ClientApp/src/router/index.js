import { createWebHistory, createRouter } from "vue-router";
import Folder from "@/views/FolderView.vue";
import Counter from "@/components/Counter.vue";
import FetchData from "@/components/FetchData.vue";

const routes = [
    {
        path: '/',
        redirect: '/outgoing'
    },
    {
        path: "/incoming",
        name: "incoming",
        component: Folder,
    },
    {
        path: "/outgoing",
        name: "outgoing",
        component: Folder,
    },
    {
        path: "/Counter",
        name: "Counter",
        component: Counter,
    },
    {
        path: "/FetchData",
        name: "FetchData",
        component: FetchData,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;