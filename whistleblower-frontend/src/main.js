import Vue from 'vue';
import Vuesax from 'vuesax';
import 'vuesax/dist/vuesax.css';
import 'material-icons/iconfont/material-icons.css';
import 'boxicons/css/boxicons.min.css';

import axios from 'axios';
import App from './App.vue';
import store from './store';
import router from './router';

// axios.defaults.withCredentials = true;
axios.defaults.baseURL = 'https://localhost:44338/api/Authenticate/';

// Vuesax styles
Vue.use(Vuesax, {
  // options here
});

Vue.config.productionTip = false;

new Vue({
  render: (h) => h(App),
  store,
  router,
}).$mount('#app');
