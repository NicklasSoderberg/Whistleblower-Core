/* eslint-disable no-shadow */
// store/modules/auth.js

import axios from 'axios';

const state = {
  user: null,
  role: null,
  token: null,
  userId: null,
};
const loginConfig = {
  headers: {
    'Content-Type': 'application/json',
  },
};
const getters = {
  isAuthenticated: (state) => !!state.user,
  StateUser: (state) => state.user,
  StateUserRole: (state) => state.role,
  StateUserToken: (state) => state.token,
  StateUserId: (state) => state.userId,
};
const actions = {
  async LogIn({ commit }, User) {
    const res = await axios.post('Authenticate/login', User, loginConfig);
    await commit('setUser', User.username);
    await commit('setRole', res.data.role);
    await commit('setToken', res.data.token);
    await commit('setUserId', res.data.userId);
  },
  async LogOut({ commit }) {
    const user = null;
    commit('LogOut', user);
  },
};
const mutations = {
  setUser(state, username) {
    state.user = username;
  },
  setRole(state, role) {
    state.role = role;
  },
  setToken(state, token) {
    state.token = token;
  },
  setUserId(state, userId) {
    state.userId = userId;
  },
  LogOut(state) {
    state.user = null;
    state.role = null;
    state.token = null;
  },
};
export default {
  state,
  getters,
  actions,
  mutations,
};
