import { createStore } from 'vuex'


export const store = createStore({
    state () {
        return {
            userInfo: {
                // remove
                organizationId: null
            },
            currentOrganization: {
                id: null
            }
        }
    },

    mutations: {
        setUserInfo(state, userInfo) {
            state.userInfo = userInfo;
        },
        setCurrentOrganization(state, currentOrganization) {
            state.currentOrganization = currentOrganization;
        }
    },
    getters: {
        currentOrganization: state => {
            return state.currentOrganization;
        }
    }
})