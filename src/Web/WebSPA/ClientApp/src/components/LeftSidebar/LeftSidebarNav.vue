<template>
    <div class="navigation-container">
        <a class="navigation-item-link navigation-item" v-for="(item, index) in items" :key="index">
            <div class="item-caption">
                <span> {{item.caption}}</span>
            </div>
        </a>
    </div>
</template>

<script>
export default {
    name: "LeftSidebarNav",
    data() {
        return {
            items: [{
                id: "inbox",
                caption: "Incomings"
            },
            {
                id: "outbox",
                caption: "Outgoing"
            }]
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