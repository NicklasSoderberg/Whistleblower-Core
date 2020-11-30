import axios from 'axios';

const subject = {
  async getAll() {
    let responseData;
    await axios.get('Subject',
      {
        headers: {
          'Content-Type': 'application/json',
        },
      }).then((response) => {
      responseData = response.data;
    });
    return responseData;
  },
  create(token, input) {
    axios.post('Subject', input, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      console.log(response.data);
    });
  },
  async update(token, subjectToUpdate) {
    let responseData;
    await axios.put(`Subject/${subjectToUpdate.subjectID}`, subjectToUpdate, {
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

export default subject;
