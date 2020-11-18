import Vue from 'vue';
import Router from 'vue-router';

import Home from '../components/Home.vue';
import Create from '../components/Create.vue';
import FollowUp from '../components/FollowUp.vue';

Vue.use(Router);

export default new Router({
  routes: [{
    path: '/',
    name: 'Home',
    component: Home,
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
  }],
});
