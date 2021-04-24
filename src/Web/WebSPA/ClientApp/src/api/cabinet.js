

export default function CabinetApi(app) {
    this.foldersApi = `${process.env.VUE_APP_CABINET_API}/folders`;
    this.documentsApi = `${process.env.VUE_APP_CABINET_API}/documents`;
    this.app = app;
    this.getDocuments = getDocuments;
    this.createDocuments = createDocuments;
    async function getDocuments(searchParameters) {
        let response = await this.app.$http.get(this.documentsApi,  {
            searchParameters
        });

        return response.data;
    }

    async function createDocuments(createParameters) {
        let form = new FormData(createParameters);
        let response = await this.app.$http.post(this.documentsApi, {
            form
        });

        return response.data
    }

    async function getFolders(searchParameters) {
        let response = await this.app.$http.get(this.foldersApi, {
            searchParameters
        });

        return response.data
    }
    
}