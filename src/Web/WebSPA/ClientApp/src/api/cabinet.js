

export default function CabinetApi(app) {
    this.documentsApi = `${process.env.VUE_APP_CABINET_API}/documents`;
    this.app = app;
    this.getDocuments = getDocuments;
    this.createDocuments = createDocuments;

    async function getDocuments(searchParameters) {
        let response = await this.app.$http.get(this.documentsApi,  {
            params: searchParameters
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
}