import Vue from 'vue';
import Router from 'vue-router';

import HomePage from '../components/HomePage.vue';
import Create from '../components/Create.vue';
import FollowUp from '../components/FollowUp.vue';
import Login from '../components/LoginPage.vue';
import StatusPage from '../components/StatusPage.vue';

Vue.use(Router);

export default new Router({
  routes: [{
    path: '/',
    name: 'HomePage',
    component: HomePage,
  },
  {
    path: '/create',
    name: 'Create',
    component: Create,
  },
  {
    path: '/followup',
    name: 'FollowUp',
    component: FollowUp,
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
  },
  {
    path: '/Reportstatus',
    name: 'StatusPage',
    component: StatusPage,
  }],
});
