<template>
	<div
     class="folder-list-item-container" tabindex="0">
    <div class="folder-list-item-row">
      <div class="col-selection">
        <div class="selection-check">
          <span class="clickable-primary">
            <div>
              <i class="far fa-square" />
            </div>
          </span>
        </div>
        <div class="selection-star">
          <span class="clickable-primary">
            <div>
              <i class="far fa-star" />
            </div>
          </span>
        </div>
      </div>
      <div class="col-doc-info">
        <div class="icon">
          <span>
            <i class="far fa-file text-primary"></i>
          </span>
        </div>
        <div class="info">
          <div class="doc-name">
            <span class="clickable">
              Document 12345 
            </span>
          </div>
          <div class="doc-type">
            <span>Act</span>
          </div>
        </div>
      </div>
      <div class="col-date">
        <span>
          11.08.2000
        </span>
      </div>
      <div class="col-state">
        <div class="d-flex flex-row flex-wrap mb-1">
            <div class="d-flex flex-row flex-wrap mb-1">
                <span class="badge badge-pill badge-success">Signed</span>
            </div>
        </div>
      </div>
    </div>
	</div>
</template>

<script>

export default {
    name: "FolderItem",		
}
</script>

<style scoped>
.folder-list-item-container:focus {
    outline: none;
}

.folder-list-item-row {
  display: flex;
  flex-direction: row;
  background: white;
  border-radius: 6px;
  width: 100%;
  min-height: 4.5rem;
  margin-bottom: 1px;
  align-items: center;
  padding: 0.5rem 1.25rem;
  cursor: pointer;
}

.folder-list-item-row:focus {
    outline: none;
}

.col-selection {
  display: flex;
  flex-direction: row;
  width: 4.5rem;
  font-size: 16px;
  color: #007bff;
}

.selection-check {
width: 2rem;
}

.selection-star {
width: 2rem;
}

.col-doc-info {
  flex-grow: 1;
  display: flex;
  flex-direction: row;
  align-items: center;
}

.icon {
    flex-grow: 0;
    width: 3.75rem;
    font-size: 38px;
}

.info {
    flex-grow: 1;
    display: flex;
    flex-direction: column;
}

.doc-name {
    flex-grow: 1;
    font-weight: 500;
}

.doc-type {
    flex-grow: 0;
    color: #929292;
}

.col-date {
  width: 11.625rem;
}
.col-state {
  width: 16.25rem;
  font-size: 12px;
}

.badge {
    font-size: 12px;
    font-weight: 400;
    margin-right: 2px;
}

.bg-current {
  /*background: #eaeef6;*/
  background: rgba(189, 212, 248, 0.2);
}

.clickable {
  text-decoration: none;
  background-color: transparent;
  color: rgba(6, 18, 36, 0.9);
}
    .clickable:hover {
        color: #167495;
    }
    .clickable:focus {
        color: #167495;
    }

.clickable-primary {
    color: #007bff;
}
    .clickable-primary:hover {
        color: #167495;
    }

</style>


<style lang="scss">
</style>
