import { createStore } from 'vuex'


export const store = createStore({
    state() {
        return {
            folders: []
        }
    },

    mutations: {
        setFolders(state, folders) {
            if (folders && folders.length) {
                console.log(folders);
                state.folders = folders
            }
        }
    }
})