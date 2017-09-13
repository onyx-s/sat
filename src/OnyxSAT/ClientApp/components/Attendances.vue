<template>
  <div class="d-flex flex-column align-items-center container">
    <h1 class="display-4 mb-4">Attendances</h1>
    <table class="table table-bordered mb-5">
      <thead class="thead-default">
        <tr>
          <th>Date</th>
          <th>Card Number</th>
          <th>Verified</th>
        </tr>
      </thead>
      <tbody>
        <tr v-if="attendances" v-for="a in attendances">
          <td>{{ formatDate(a.dateTime) }}</td>
          <td>{{ a.cardNo }}</td>
          <td>{{ a.verified ? 'Yes': 'No' }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      attendances: []
    }
  },
  methods: {
    getAttendances() {
      this.axios.get('/api/attendances/')
        .then(response => this.attendances = response.data)
        .catch(error => console.log(error))
    },
    formatDate(d) {
      let dSplit = d.split(/[:T-]/g);
      let dateTime = new Date(Date.UTC(dSplit[0], parseInt(dSplit[1], 10) - 1, dSplit[2], dSplit[3], dSplit[4], dSplit[5]));
      let date = dateTime.toLocaleDateString('en-GB', { timeZone: 'UTC' });
      let time = dateTime.toLocaleTimeString('en-US', { timeZone: 'UTC' });

      return date + ' at ' + time;
    }
  },
  created() {
    this.getAttendances();
  }
}
</script>

<style lang="sass" scoped>
table
  max-width: 600px
</style>
