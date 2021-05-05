

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

    async function createDocuments(createParameters, files) {
        let formData = new FormData();
        for (let i in createParameters) {
            formData.append(i, createParameters[i]);
        }

        for (let file of files) {
            formData.append('files', file);
        }

        let response = await this.app.$http.post(this.documentsApi, formData, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });

        return response.data
    }
}