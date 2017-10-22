<template>
  <div class="d-flex flex-column align-items-center container">
    <h1 class="display-4 mb-4">Attendances</h1>
    <table class="table table-bordered mb-5">
      <thead class="thead-default">
        <tr>
          <th>Name</th>
          <th>Student ID</th>
          <th>Present</th>
        </tr>
      </thead>
      <tbody>
        <tr v-if="classgroup" v-for="a in classgroup">
          <td>{{ a.User.FirstName }} + " " + {{ a.User.LastName }}</td>
          <td>{{ a.User.StudentID }}</td>
          <td>{{ a.Verified ? 'Yes': 'No' }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      classgroup: []
    }
  },
  created() {

  }
}
</script>

<style lang="sass" scoped>
table
  max-width: 600px
</style>