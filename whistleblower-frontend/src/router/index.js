import Vue from 'vue';
import Router from 'vue-router';

import HomePage from '../components/HomePage.vue';
import Create from '../components/Create.vue';
import FollowUp from '../components/FollowUp.vue';
import Login from '../components/LoginPage.vue';
import StatusPage from '../components/StatusPage.vue';

// Admin
import HandleCasesPage from '../components/admin/HandleCasesPage.vue';
import HandleLawyersPage from '../components/admin/HandleLawyersPage.vue';
import HandleSubjectsPage from '../components/admin/HandleSubjectsPage.vue';

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
    path: '/admin',
    name: 'AdminPage',
    component: HandleCasesPage,
  },
  {
    path: '/newlawyer',
    name: 'AdminNewLawyer',
    component: HandleLawyersPage,
  },
  {
    path: '/newsubject',
    name: 'AdminNewSubject',
    component: HandleSubjectsPage,
  },
  {
    path: '/Reportstatus',
    name: 'StatusPage',
    component: StatusPage,
  }],
});
