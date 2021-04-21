<template>
<div class="folder-list-container">
    <!-- Header -->
    <div class="folder-list-header">
      <div class="folder-list-header-row">
        <div class="header-col-select-all">
          <div class="form-check">
            <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
          </div>
        </div>
        <div class="header-col-name">
          Name
        </div>
        <div class="header-col-date">
          Date of creation
        </div>
        <div class="header-col-state">
          Status
        </div>
     </div>
    </div>
    <!-- Body -->
    <div class="folder-list-body">
      <perfect-scrollbar>
          <div v-for="(item, index) in items" :key="index">
            <folder-item />
          </div>
      </perfect-scrollbar>     
    </div>
  </div>
</template>

<script>
import FolderItem from './FolderItem'

export default {
  name: "FolderContent",
  components: {
    FolderItem
  },
  data() {
    return {
      items: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
    }
  },
  mounted() {
    this.$cabinetApi.getDocuments();
  }
}
</script>

<style>
.folder-list-container {
  display: flex;
  flex-direction: column;
  height: 100%;
}
.folder-list-header {
  flex-grow: 0;
}
.folder-list-header-row {
  display: flex;
  flex-direction: row;
  background: #FFFFFF;
  border-radius: 6px 2px 0 0;
  padding: 0.5rem 1.25rem;
  margin-bottom: 3px;
  font-weight: 500;
}

.header-col-select-all {
  width: 4.5rem;
}
.header-col-name {
  flex-grow: 1;
}
.header-col-date {
  width: 11.625rem;
}
.header-col-state {
  width: 16.25rem;
}

.folder-list-body {
  flex-grow: 1;
  height: 0;
}

.ps {
  max-height: 100%;
}
</style>