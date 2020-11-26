import Vue from 'vue';
import Router from 'vue-router';

// No-role
import HomePage from '../components/norole/HomePage.vue';
import Create from '../components/norole/Create.vue';
import FollowUp from '../components/norole/FollowUp.vue';
import Login from '../components/norole/LoginPage.vue';

// User
import StatusPage from '../components/user/StatusPage.vue';
import SafepostBox from '../components/user/SafepostBox.vue';

// Admin
import HandleCasesPage from '../components/admin/HandleCasesPage.vue';
import HandleLawyersPage from '../components/admin/HandleLawyersPage.vue';
import HandleSubjectsPage from '../components/admin/HandleSubjectsPage.vue';

// Lawyer
import WhistleHandler from '../components/lawyer/WhistleHandler.vue';

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
    meta: { guest: true },
  },
  {
    path: '/followup',
    name: 'FollowUp',
    component: FollowUp,
    meta: { guest: true },
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
    meta: { guest: true },
  },
  {
    path: '/admin',
    name: 'AdminPage',
    component: HandleCasesPage,
    meta: { requiresAuth: true },
  },
  {
    path: '/newlawyer',
    name: 'AdminNewLawyer',
    component: HandleLawyersPage,
    meta: { requiresAuth: true },
  },
  {
    path: '/newsubject',
    name: 'AdminNewSubject',
    component: HandleSubjectsPage,
    meta: { requiresAuth: true },
  },
  {
    path: '/reportstatus',
    name: 'StatusPage',
    component: StatusPage,
    meta: { requiresAuth: true },
  },
  {
    path: '/safepostbox',
    name: 'SafepostBox',
    component: SafepostBox,
    meta: { requiresAuth: true },
  },
  {
    path: '/whistleHandler',
    name: 'WhistleHandler',
    component: WhistleHandler,
    meta: { requiresAuth: true },
  }],
});
