import { createWebHistory, createRouter } from "vue-router";
import Folder from "@/views/FolderView.vue";
import Counter from "@/components/Counter.vue";
import FetchData from "@/components/FetchData.vue";

const routes = [
    {
        path: "/folder",
        name: "folder",
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