import axios from 'axios';

const whistle = {
  async getAll(token) {
    let responseData;
    await axios.get('Whistle',
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async create(input) {
    let responseData;
    await axios.post('whistle', input, {
      headers: {
        'Content-Type': 'application/json',
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async getByUserId(token, userId) {
    let responseData;
    await axios.get(`whistle/userid/${userId}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async update(token, whistleToUpdate) {
    let responseData;
    await axios.put(`Whistle/${whistleToUpdate.whistleID}`, whistleToUpdate, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async createUser() {
    let responeData;
    await axios.post('Authenticate/registerUser', {
      headers: {
        'Content-Type': 'application/json',
      },
    }).then((response) => {
      responeData = response.data;
    });
    return responeData;
  },
};

export default whistle;
