<template>
  <div class="container d-flex flex-column align-items-center">
    <template v-if="Object.keys(user).length">
      <h1 class="display-4 mb-4">Edit Student Details</h1>
      <form @submit.prevent="updateUser" class="d-flex flex-column align-items-center w-100 table-container">
        <table class="table table-bordered d-flex mb-5">
          <thead class="thead-default w-25">
            <tr class="d-flex flex-column">
              <th>First Name</th>
              <th>Last Name</th>
              <th>Email</th>
              <th>Mobile</th>
              <th>Staff ID</th>
              <th>Student ID</th>
            </tr>
          </thead>
          <tbody class="w-75">
            <tr class="d-flex flex-column align-content-between">
              <td><input type="text" name="First Name" class="form-control" v-validate="{required: true, alpha_spaces: true}" v-model="user.firstName" autofocus/></td>
              <td><input type="text" name="Last Name" class="form-control" v-validate="{required: true, alpha_spaces: true}" v-model="user.lastName" /></td>
              <td><input type="email" name="Email" class="form-control" v-validate="'required'" v-model="user.email" /></td>
              <td><input type="text" name="Mobile" class="form-control" v-validate="{ rules: { required: true, regex: /^04\d{8}$/} }" v-model="user.mobile" /></td>
              <td><input type="text" name="staffId" class="form-control" v-validate="{required: true, numeric: true}" v-model="user.staffId" /></td>
              <td><input type="text" name="studentId" class="form-control" v-validate="{required: true, numeric: true}" v-model="user.studentId" /></td>
            </tr>
          </tbody>
        </table>
        <button type="submit" class="submit btn btn-default">Save</button>
      </form>
    </template>
    <not-found v-if="userNotFound"></not-found>
  </div>
</template>
<script>
import Vue from 'vue'
import NotFound from '../404'

export default {
  data() {
    return {
      user: {},
      userNotFound: false
    }
  },
  methods: {
    getUser(id) {
      Vue.axios.get('/api/users/' + id)
        .then(response => this.user = response.data)
        .catch(error => {
          if (error.response.status == 404)
            this.userNotFound = true;
        })
    },
    updateUser() {
      if (!this.errors.all().length) {
        this.axios.post('/api/users/', {
          firstName: this.user.firstName,
          lastName: this.user.lastName,
          email: this.user.email,
          mobile: this.user.mobile,
          staffId: this.user.staffId || null,
          studentId: this.user.studentId || null
        })
          .then((response) => {
            this.$router.push({ name: 'users/' + id, params: { alert: 'User Updated' } });
          })
          .catch(error => console.log(error));
      }
    }
  },
  created() {
    this.getUser(this.$route.params.id);
  },
  components: {
    NotFound
  }
}
</script>

<style lang="sass" scoped>
.table-container
  max-width: 600px

.table-bordered th, .table-bordered td
  border: none
  border-top: 1px solid #eceeef
  &:first-child
    border: none

thead, th
  min-width: 105px

td
  padding: 0

h3
  font-size: 2.6em

.list-group
  flex:
    direction: row
    wrap: wrap

.list-group-item
  margin:
    bottom: 5px
    right: 5px

input
  border: 0
  height: 100%
  padding: 14.5px 12px
  width: 100%
tr
  height: 100%
</style>
