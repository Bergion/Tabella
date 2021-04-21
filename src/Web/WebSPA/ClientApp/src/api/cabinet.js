

export default function CabinetApi(app) {
    //this.foldersApi = `${process.env.VUE_APP_CABINET_API}/folders`;
    this.documentsApi = `${process.env.VUE_APP_CABINET_API}/documents`;
    this.app = app;
    this.getDocuments = getDocuments;
    this.createDocuments = createDocuments;
    function getDocuments(searchParameters) {
        this.app.$http.get(this.documentsApi,  {
            searchParameters
        })
        .then((response) => {
            console.log(response);
        })
        return [];
    }

    function createDocuments(createParameters) {
        console.log(createParameters);
        return null;
    }
    
}