import axios from 'axios';

const conversation = {
  async getAll(token, input) {
    let responseData;
    await axios.get(`conversation/${input}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async postMessage(token, input) {
    let responseData;
    await axios.post('conversation', input, {
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

export default conversation;
