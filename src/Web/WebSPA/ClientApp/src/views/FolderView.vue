<template>
    <div class="folder-frame">
        <div class="folder-header">
        </div>
        <div class="folder-content">
            <folder-content></folder-content>
        </div>
    </div>
</template>

<script>
import FolderContent from '../components/Folder/FolderContent.vue'


export default {
  name: "FolderView",
  components: {
    FolderContent
  },
}
</script>

<style scoped>
.folder-frame {
    display: flex;
    flex-direction: column;
    justify-content: center;
    width: 100%;
    height: 100%;
    padding: 7px 7px 0 7px;
}

.folder-content {
  height: 100%;
  margin-left: 7px;
  margin-right: 6px;
     
}

</style>