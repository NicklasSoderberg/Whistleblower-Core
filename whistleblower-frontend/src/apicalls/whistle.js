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
  create(input) {
    axios.post('whistle', input, {
      headers: {
        'Content-Type': 'application/json',
      },
    }).then((response) => {
      console.log(response.data);
    });
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
};

export default whistle;