import axios from 'axios';

const file = {
  async get(token, input) {
    let responseData;
    await axios.get(`file/${input}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  async post(token, input) {
    let responseData;
    await axios.post('file', input, {
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

export default file;
