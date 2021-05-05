<template>
  <div class="app-main-container">
    <div class="nav-menu">
      <nav-menu></nav-menu>
    </div>
    <div class="app-body">
      <div class="left-sidebar">
        <left-sidebar></left-sidebar>
      </div>
      <router-view></router-view>    
    </div>
    <document-manager/> 
  </div>
</template>

<script>
import NavMenu from '../components/NavMenu.vue'
import LeftSidebar from '../views/LeftSidebar.vue'
import DocumentManager from '../components/DocumentManager.vue';

export default {
    name : "DefaultLayout",
    components: {
      NavMenu,
      LeftSidebar,
      DocumentManager
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
  width: 20rem;
}

.app-body {
  display: flex;
  flex-direction: row;
  flex-grow: 1;
  height: 0;
}


</style>
