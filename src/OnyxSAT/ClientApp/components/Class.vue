<template>
  <div class="d-flex flex-column align-items-center container">
    <h1 class="display-4 mb-4">Attendances</h1>
    <table class="table table-bordered">
      <thead class="thead-default">
        <tr>
          <th>Name</th>
          <th>Student ID</th>
          <th>Phone</th>
          <th>Present</th>
        </tr>
      </thead>
      <tbody class="align-items-middle">
        <tr v-if="classgroup" v-for="a in classgroup">
          <td>{{ a.firstName }} {{ a.lastName }}</td>
          <td>{{ a.studentId }}</td>
          <td>{{ a.mobile }}</td>
          <td>
            <select type="text" name="attended" class="form-control" v-validate="{required: true}">
              <option value="true" selected>Yes</option>
              <option value="false">No</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>
    <div class="mb-5" style="width: 600px;">
      <button class="btn btn-default text-xs-right float-right" v-on:click="markAllPresent()">Change all to present</button>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      class: {},
      classgroup: []
    }
  },
  methods: {
    getUsers() {
      this.axios.get('/api/users/')
        .then(response => this.classgroup = response.data)
        .catch(error => console.log(error))
    },
    markAllPresent() {
      let options = document.getElementsByTagName("option");
      for (var i = 0; i < options.length; i++) {
        if (options[i].value === "true") {
          options[i].selected = "selected";
        }
      }
    }
  },
  created() {
    this.getUsers();
  }
}
</script>

<style lang="sass" scoped>
table
  max-width: 600px
select-all
  max-width: 600px

</style>