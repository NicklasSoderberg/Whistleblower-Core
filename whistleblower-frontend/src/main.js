import Vue from 'vue';
import Vuesax from 'vuesax';
import 'vuesax/dist/vuesax.css';
import 'material-icons/iconfont/material-icons.css';
import 'boxicons/css/boxicons.min.css';
import App from './App.vue';

import router from './router';
// Vuesax styles
Vue.use(Vuesax, {
  // options here
});

Vue.config.productionTip = false;

new Vue({
  render: (h) => h(App),
  router,
}).$mount('#app');
