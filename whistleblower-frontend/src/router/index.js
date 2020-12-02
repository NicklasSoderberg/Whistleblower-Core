import Vue from 'vue';
import VueRouter from 'vue-router';
import store from '../store';

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
import WhistleHandlerPage from '../components/lawyer/WhistleHandler.vue';

Vue.use(VueRouter);

const routes = [{
  path: '/',
  name: 'HomePage',
  component: HomePage,
  meta: { guest: true },
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
  meta: { requiresAuth: true, adminAuth: true },
},
{
  path: '/newlawyer',
  name: 'AdminNewLawyer',
  component: HandleLawyersPage,
  meta: { requiresAuth: true, adminAuth: true },
},
{
  path: '/newsubject',
  name: 'AdminNewSubject',
  component: HandleSubjectsPage,
  meta: { requiresAuth: true, adminAuth: true },
},
{
  path: '/reportstatus',
  name: 'StatusPage',
  component: StatusPage,
  meta: { requiresAuth: true, userAuth: true },
},
{
  path: '/safepostbox',
  name: 'SafepostBox',
  component: SafepostBox,
  meta: { requiresAuth: true, userAuth: true, lawyerAuth: true },
},
{
  path: '/whistleHandler',
  name: 'WhistleHandler',
  component: WhistleHandlerPage,
  meta: { requiresAuth: true, lawyerAuth: true },
}];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (store.getters.isAuthenticated) {
      switch (store.getters.StateUserRole) {
        case 'Admin':
          if (!to.meta.adminAuth) {
            next('Admin');
          } else {
            next();
          }
          break;
        case 'Lawyer':
          if (!to.meta.lawyerAuth) {
            next('whistleHandler');
          } else {
            next();
          }
          break;
        case 'User':
          if (!to.meta.userAuth) {
            next('reportstatus');
          } else {
            next();
          }
          break;
        default:
          break;
      }
      next();
      return;
    }
    next('/login');
  } else {
    next();
  }
});

export default router;
