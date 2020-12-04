import Vue from 'vue';
import Vuesax from 'vuesax';
import 'vuesax/dist/vuesax.css';
import 'material-icons/iconfont/material-icons.css';
import 'boxicons/css/boxicons.min.css';
import Vuelidate from 'vuelidate';
import axios from 'axios';
import App from './App.vue';
import store from './store';
import router from './router';

Vue.use(Vuelidate);

// axios.defaults.withCredentials = true;
axios.defaults.baseURL = 'https://localhost:44338/api/';

// eslint-disable-next-line consistent-return
axios.interceptors.response.use(undefined, (error) => {
  if (error) {
    const originalRequest = error.config;
    // eslint-disable-next-line no-underscore-dangle
    if (error.response.status === 401 && !originalRequest._retry) {
      // eslint-disable-next-line no-underscore-dangle
      originalRequest._retry = true;
      store.dispatch('LogOut');
      return router.push('/login');
    }
  }
});

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
