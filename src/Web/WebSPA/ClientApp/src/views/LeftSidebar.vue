<template>
    <div class="left-sidebar-container">
        <div class="left-sidebar-top">
            <button
                type="button" 
                id="new-document-button"
                class="btn btn-primary">
                <i class="far fa-cloud-upload"></i>
                <span class="ml-1">
                    Upload
                </span>
            </button>
            <div class="left-sidebar-top-text">
                Formats: PDF, XML, TXT, PNG, JPEG, DOC, DOCX, XLSX
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "LeftSidebar"
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
</style>