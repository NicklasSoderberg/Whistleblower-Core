export default {
  data: () => ({
    timestamp: '',
  }),
  created() {
    setInterval(this.getNow, 1000);
  },
  methods: {
    getNow() {
      const today = new Date();
      const month = (today.getMonth() + 1 < 10 ? '0' : '') + (today.getMonth() + 1);
      const day = (today.getDate() < 10 ? '0' : '') + today.getDate();
      const minutes = (today.getMinutes() < 10 ? '0' : '') + today.getMinutes();

      const date = `${today.getFullYear()}-${month}-${day}`;
      const time = `${today.getHours()}:${minutes}:${(today.getSeconds() < 10 ? '0' : '') + today.getSeconds()}`;

      const dateTime = `${date}T${time}`;
      this.timestamp = dateTime;
    },
  },
};
