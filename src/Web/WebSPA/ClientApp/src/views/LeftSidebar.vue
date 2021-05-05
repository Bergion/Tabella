<template>
    <div class="left-sidebar-container">
        <div class="left-sidebar-top">
            <button
                type="button" 
                @click="createDocuments"
                id="new-document-button"
                class="create-button btn btn-primary">
                <i class="fas fa-cloud-upload-alt"></i>
                <span class="ml-1">
                    Upload
                </span>
            </button>
            <div class="left-sidebar-top-text">
                Formats: PDF, XML, TXT, PNG, JPEG, DOC, DOCX, XLSX
            </div>
        </div>
        <div class="left-sidebar-body">
            <left-sidebar-nav></left-sidebar-nav>
        </div>
    </div>
</template>

<script>
import LeftSidebarNav from "../components/LeftSidebar/LeftSidebarNav.vue"

export default {
    name: "LeftSidebar",
    components: {
        LeftSidebarNav
    },
    methods: {
        createDocuments() {
            this.$eventBus.emit('createDocuments');
        }
    }
}
</script>


<style scoped>
.left-sidebar-container {
  display: flex;
  flex-direction: column;
  height: 100%;
}
.left-sidebar-top {
  display: flex;
  flex-direction: column;
  flex: 0 0 auto;
  padding: 1rem 0.5rem 0.75rem 0.5rem;
  border-bottom: 2px solid #f5f5f5;
}
.left-sidebar-top-text {
  padding: 0.5rem;
  font-size: 12px;
  color: gray;
}

.left-sidebar-body {
  padding-top: 0.5rem;
  padding-bottom: 1rem;
  flex-grow: 1;
  
}

.create-button {
    height: auto;
}
</style>