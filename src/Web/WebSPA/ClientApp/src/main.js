import 'bootstrap/dist/css/bootstrap.css'
import 'vue3-perfect-scrollbar/dist/vue3-perfect-scrollbar.css'
import { createApp, h } from 'vue'
import App from './App.vue'
import './styles/index.css'
import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'

const app = createApp({
    render: () => h(App)
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


app.mount("#app");
