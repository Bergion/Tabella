<template>
    <div id="documentManager">
        <create-documents-modal 
            :show="showCreateDocumentsModal"
            :orgId="org.id"
            :docTypes="avaliableDocTypes"
            @submit="createDocuments"
            @hidden="showCreateDocumentsModal = false"/>
    </div>
</template>
<script>
import { mapGetters } from 'vuex';
import CreateDocumentsModal from '../modals/CreateDocumentsModal.vue';

export default {
    name: "DocumentManager",
    data() {
        return {
            showCreateDocumentsModal: false,
            avaliableDocTypes: []
        }
    },
    components: {
        CreateDocumentsModal
    },
    computed: {
        ...mapGetters({
            org: 'currentOrganization'
        })
    },
    methods: {
        onCreateDocuments() {
            this.avaliableDocTypes = [{
                name: "Default", code: 8, default: true
            }];
            this.showCreateDocumentsModal = true;
        },
        createDocuments(createParameters) {
            this.showCreateDocumentsModal = false;
            let files = Object.assign([], createParameters.files);
            delete createParameters.files;
            this.$cabinetApi.createDocuments(createParameters, files)
            .then(r => {
                this.$eventBus.emit('reloadFolder');
            })
        }
    },
    beforeMount() {
        this.$eventBus.on('createDocuments', this.onCreateDocuments);
    },
    beforeUnmount() {
        this.$eventBus.off('createDocuments', this.onCreateDocuments);
    }
}
</script>