import Vue from 'vue';
import Router from 'vue-router';

import Login from '../components/LoginPage.vue';
import HelloWorld from '../components/HelloWorld.vue';
import HomePage from '../components/HomePage.vue';

Vue.use(Router);

export default new Router({
  routes: [{
    path: '/',
    name: 'Home',
    component: HelloWorld,
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
  },
  {
    path: '/HomePage',
    name: 'HomePage',
    component: HomePage,
  }],
});
