<template>
    <div class="navigation-container">
        <a :class="{'navigation-item-link-active': folder.id == $route.name }"
            @click="onClick(folder.id)"
            class="navigation-item-link navigation-item" v-for="(folder, index) in folders" :key="index">
            <div class="item-caption">
                <span> {{folder.caption}}</span>
            </div>
        </a>
    </div>
</template>

<script>
import { computed } from 'vue'
export default {
    name: "LeftSidebarNav",
    data() {
        return {
            folders: [{
                id: "outgoing",
                caption: "Outbox"
            },
            {
                id: "incoming",
                caption: "Inbox"
            }]
        }
    },
    methods: {
        onClick(id) {
            this.$router.push({ name: id });
        }
    }
}
</script>

<style>
.navigation-container {
    display: flex;
    flex-direction: column;
}

.navigation-item {
    display: flex;    
    flex-direction: row;
    align-items: center;
}
.navigation-item-link {
    color: black;
}
    .navigation-item-link:hover {
        background-color:#007bff;
        color: white;
    }

.navigation-item-link-active {
    background-color: #a1a5a8;
    color: white;
}
    .navigation-item-link-active:hover {
        background-color: #a1a5a8;
        color: white;
    }
    
.item-caption {
    padding: 0.75rem;
    margin-left: 0.5rem;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    flex-grow: 1;
}


</style>