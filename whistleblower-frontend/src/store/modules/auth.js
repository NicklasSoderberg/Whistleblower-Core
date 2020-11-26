/* eslint-disable no-shadow */
// store/modules/auth.js

import axios from 'axios';

const state = {
  user: null,
  posts: null,
};
const axiosConfig = {
  headers: {
    'Content-Type': 'application/json',
  },
};
const getters = {
  isAuthenticated: (state) => !!state.user,
  StatePosts: (state) => state.posts,
  StateUser: (state) => state.user,
};
const actions = {
  async Register({ dispatch }, form) {
    await axios.post('register', form);
    const UserForm = new FormData();
    UserForm.append('username', form.username);
    UserForm.append('password', form.password);
    await dispatch('LogIn', UserForm);
  },
  async LogIn({ commit }, User) {
    console.log(JSON.stringify(User));
    await axios.post('login', User, axiosConfig);
    await commit('setUser', User.get('username'));
  },
  async CreatePost({ dispatch }, post) {
    await axios.post('post', post);
    await dispatch('GetPosts');
  },
  async GetPosts({ commit }) {
    const response = await axios.get('posts');
    commit('setPosts', response.data);
  },
  async LogOut({ commit }) {
    const user = null;
    commit('logout', user);
  },
};
const mutations = {
  setUser(state, username) {
    state.user = username;
  },
  setPosts(state, posts) {
    state.posts = posts;
  },
  LogOut(state) {
    state.user = null;
    state.posts = null;
  },
};
export default {
  state,
  getters,
  actions,
  mutations,
};
