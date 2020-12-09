import axios from 'axios';

const lawyer = {
  async getWhistlesByLawyerID(token, input) {
    let responseData;
    await axios.get(`whistle/lawyer/${input}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async getLawyerFirstLoginById(token, input) {
    let responseData;
    await axios.get(`authenticate/firstlogin/${input}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async ChangeLawyerPassword(token, id, password, newpassword) {
    let responseData;
    await axios.post(`authenticate/changepassword/${id}/${password}/${newpassword}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async getAll(token) {
    let responseData;
    await axios.get('authenticate/lawyers', {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async create(token, input) {
    let responseData;
    await axios.post('authenticate/register', input, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
};

export default lawyer;
