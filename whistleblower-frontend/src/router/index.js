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
import WhistleHandler from '../components/Lawyer/WhistleHandler.vue';

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
    path: '/reportstatus',
    name: 'StatusPage',
    component: StatusPage,
  },
  {
    path: '/safepostbox',
    name: 'SafepostBox',
    component: SafepostBox,
  },
  {
    path: '/whistleHandler',
    name: 'WhistleHandler',
    component: WhistleHandler,
  }],
});
