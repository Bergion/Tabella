<template>
    <div class="app-main-container">
        <div class="nav-menu">
            <nav-menu></nav-menu>
        </div>
        <div class="left-sidebar">
          <left-sidebar></left-sidebar>
        </div>
        <div class="app-body">
            <router-view></router-view>    
        </div>
    </div>
</template>

<script>
import NavMenu from '../components/NavMenu.vue'
import LeftSidebar from '../views/LeftSidebar.vue'
export default {
    name : "DefaultLayout",
    components: {
      NavMenu,
      LeftSidebar
    }
}
</script>

<style scoped>
.app-main-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  margin: 0;
  padding: 0;
  font-family: 'IBM Plex Sans', sans-serif;
  background: #f5f5f5;
}
.nav-menu {
  height: 65px;
  background-color: white;
}

.left-sidebar {
  background-color: white;
  width: 16rem;
}

.app-body {
  display: flex;
  flex-direction: row;
  flex-grow: 1;
  height: 0;
}


</style>
