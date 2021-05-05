import 'bootstrap/dist/css/bootstrap.min.css'
import 'jquery/src/jquery.js'
import 'bootstrap/dist/js/bootstrap.min.js'
import 'vue3-perfect-scrollbar/dist/vue3-perfect-scrollbar.css'
import './styles/themes/md-primary/theme.css';
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';
import App from './App.vue'
import './styles/index.css'
import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'
import { mapMutations } from "vuex";
import { createApp, h } from 'vue'

const app = createApp({
    render: () => h(App),
    created() {
        this.setCurrentOrg({id: 1});
    },
    methods: {
        ...mapMutations({
            setCurrentOrg: 'setCurrentOrganization'
        })
    }
});


import PerfectScrollbar from 'vue3-perfect-scrollbar';
app.use(PerfectScrollbar);
 
import router from './router';
app.use(router);

import axios from 'axios';
import VueAxios from 'vue-axios';
app.use(VueAxios, axios);

import CabinetApi from './api/cabinet.js';
app.config.globalProperties.$cabinetApi = new CabinetApi(app);

import mitt from 'mitt';
app.config.globalProperties.$eventBus = mitt();

import { store } from './store/store';
app.use(store);

import PrimeVue from 'primevue/config';
app.use(PrimeVue);

import Dropdown from 'primevue/dropdown';
app.component('v-dropdown', Dropdown);

app.mount("#app");
