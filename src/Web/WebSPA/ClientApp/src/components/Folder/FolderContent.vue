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
          <div v-for="item in documents" :key="item.id">
            <folder-item
              :item="item"
            />
          </div>
      </perfect-scrollbar>     
    </div>
  </div>
</template>

<script>
import FolderItem from './FolderItem'
import { mapGetters } from 'vuex';

export default {
  name: "FolderContent",
  components: {
    FolderItem
  },
  data() {
    return {
      docs: []
    }
  },
  computed: {
    ...mapGetters({
      currentOrg: 'currentOrganization'
    }),
    documents() {
      return this.docs;
    }
  },
  methods: {
    getDocuments(folder) {
      folder = folder ? folder : this.$route.name;
      let searchParams = {};
      if (folder === 'incoming') {
        searchParams.organizationReceiverId = this.currentOrg.id;
      } else if (folder === 'outgoing') {
        searchParams.organizationOwnerId = this.currentOrg.id;
      }

      this.$cabinetApi.getDocuments(searchParams)
        .then((result) => {
          console.log(result)
          if (result && result.data) {
            this.docs = result.data;
          }
        });
    },
    onFolderReload() {
      this.getDocuments()
    }
  },
  created() {
    this.getDocuments();
  },
  beforeMount() {
    this.$eventBus.on('reloadFolder', this.onFolderReload);
  },
  beforeUnmount() {
    this.$eventBus.off('reloadFolder', this.onFolderReload);
  },
  watch: {
    $route(to, from) {
      // react to route changes...
      this.getDocuments(to.name);
    }
  }
}
</script>

<style>
.form-check-input {
  width: 15px;
  height: 15px;
  margin-top: 0.25rem;
}
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