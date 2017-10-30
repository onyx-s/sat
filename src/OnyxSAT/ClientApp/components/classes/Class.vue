<template>
  <div class="d-flex flex-column align-items-center container">
    <template v-if="Object.keys(cl).length">
      <h1 class="display-4 mb-4">Class Attendances</h1>
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
          <tr v-if="cl.enrolments" v-for="a in cl.enrolments">
            <td>{{ a.user.firstName }} {{ a.user.lastName }}</td>
            <td>{{ a.user.studentId }}</td>
            <td>{{ a.user.mobile }}</td>
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
    </template>
    <not-found v-if="classNotFound"></not-found>
  </div>
</template>

<script>
import NotFound from '../404'

export default {
  data() {
    return {
      cl: [],
      classNotFound: false
    }
  },
  methods: {
    getClass(id) {
      this.axios.get('/api/classes/' + id)
        .then(response => this.cl = response.data)
        .catch(error => {
          console.log(error);
          if (error.response.status == 404)
            this.classNotFound = true;
        })
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
    this.getClass(this.$route.params.id);
  },
  components: {
    NotFound
  }
}
</script>

<style lang="sass" scoped>
table
  max-width: 600px
select-all
  max-width: 600px

</style>