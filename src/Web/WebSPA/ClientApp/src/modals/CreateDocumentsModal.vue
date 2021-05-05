<template>
<div class="modal fade"
    id="createDocumentsModal"
    tabindex="-1"
    role="dialog"
    aria-hidden="true"
    data-backdrop="static">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header text-center">
        <div class="header-title">
            <h5 class="modal-title w-100" id="exampleModalLongTitle">Uploading documents</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
        <div class="avaliable-formats">
            Formats: PDF, XML, TXT, PNG, JPEG, DOC, DOCX, XLSX
        </div>
      </div>
      <div class="modal-part modal-body">
          <v-dropdown class="doctype-selector" 
            v-model="selectedDocType"
            :options="docTypes"
            optionLabel="name"
            optionValue="code"
            dataKey="code"
            placeholder="Default"></v-dropdown>
      </div>
      <div class="modal-part modal-footer">
        <button type="button" class="btn btn-white" data-dismiss="modal">Cancel</button>
        <form>
            <div class="file-upload-form">
                <div class="file-upload btn btn-primary">
                    <span>Select documents</span>
                    <input type="file" class="upload"
                        @change="onDocumentsPicked"
                        multiple="true"/>
                </div>
            </div>
        </form>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import $ from 'jquery'


export default {
	name: "createDocumentsModal",
    components: {
    },
    props: {
        show: {
			type: Boolean,
			default: false,
		},
        orgId: {
            type: Number,
            default: 0
        },
        docTypes: {
            type: Array,
            default: () => []
        }
    },
	data: function () {
		return {
			files: [],
            selectedDocType: null,
		}
	},
	methods: {
        onDocumentsPicked(event) {
            this.files = event.target.files;
            this.submit();
        },
		submit() {
            let parameters = {
                files: this.files,
                organizationId: this.orgId,
                documentTypeId: this.selectedDocType
            }
            this.$emit('submit', parameters);
		},
		resetAll() {
            console.log('reset');
			this.files = [];
			this.$emit('hidden');
		}
	},
    mounted() {
        $('#createDocumentsModal').on('hidden.bs.modal', (e) => this.resetAll());
    },
    watch: {
        show(val) {
			val ? $('#createDocumentsModal').modal('show') : $('#createDocumentsModal').modal('hide');
		},
        docTypes(val) {
            this.selectedDocType = this.docTypes.filter(d => d.default)[0].code;
        }
    }
}
</script>
<style scoped>
.modal-header {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.header-title {
    display: flex;
    width: 100%;
}

.avaliable-formats {
    padding: 0.5rem;
    font-size: 12px;
    color: gray;
}

.doctype-selector {
    width: 100%;
}

.modal-part {
    margin: 0 5%;
}

.modal-footer {
    justify-content: space-between;
}

.btn {
    width: 35%;
}

form {
    width: 45%;
}

.file-upload-form {
    cursor: pointer;
}

.file-upload {
    display: flex;
    justify-content: center;
    align-items: center;
    position: relative;
    overflow: hidden;
    width: 100%;
}

    .file-upload span {
        vertical-align: middle;
    }

.file-upload input.upload {
    position: absolute;
    top: 0;
    right: 0;
    margin: 0;
    padding: 0;
    cursor: pointer;
    opacity: 0;
    width: 100%;
    height: inherit;
}

::-webkit-file-upload-button { 
    cursor:pointer;
}
</style>