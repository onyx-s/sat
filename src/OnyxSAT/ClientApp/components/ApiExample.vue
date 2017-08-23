<template>
  <div class="d-flex flex-column align-items-center container">
    <section class="row w-100 d-flex align-items-center flex-column">
      <h2 class="display-4 mb-4">Users</h2>
      <table class="table table-bordered mb-5">
        <thead class="thead-default">
          <tr>
            <th>Name</th>
            <th>Gender</th>
            <th>Email</th>
            <th>Mobile</th>
            <th>ID</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="u in users">
            <td>{{ `${u.firstName}  ${u.lastName}` }}</td>
            <td>{{ u.gender }}</td>
            <td>{{ u.email }}</td>
            <td>{{ u.mobile }}</td>
            <td><router-link :to="u.userId.toString()" append>{{ u.userId }}</router-link></td>
          </tr>
        </tbody>
      </table>
    </section>
    <section class="row w-100 d-flex align-items-center flex-column">
      <h2 class="display-4 mb-3">Add a User</h2>
      <form @submit.prevent="addUser" class="d-flex flex-column w-100 mb-3">
        <fieldset class="form-group">
          <label>First Name</label>
          <input type="text" name="firstName" class="form-control" v-validate="'required'" v-model="user.firstName" />
        </fieldset>
        <fieldset class="form-group">
          <label>Last Name</label>
          <input type="text" name="lastName" class="form-control" v-validate="'required'" v-model="user.lastName" />
        </fieldset>
        <fieldset class="form-group">
          <label>Email</label>
          <input type="email" name="email" class="form-control" v-validate="'required'" v-model="user.email" />
        </fieldset>
        <fieldset class="form-group">
          <label>Mobile</label>
          <input type="text" name="mobile" class="form-control" v-validate="'required'" v-model="user.mobile" />
        </fieldset>
        <fieldset class="form-group">
          <label>Gender</label>
          <input type="text" name="gender" class="form-control" v-validate="'required'" v-model="user.gender" />
        </fieldset>
        <fieldset class="form-group">
          <label>Password</label>
          <input type="password" name="password" class="form-control" v-validate="'required'" v-model="user.password" />
        </fieldset>
        <button type="submit" class="btn btn-primary">Submit</button>
      </form>
    </section>
  </div>
</template>

<script>
import Vue from 'vue'

export default {
  data() {
    return {
      user: {},
      users: []
    }
  },
  methods: {
    addUser() {
      Vue.axios.post('/api/users/', {
        firstName: this.user.firstName,
        lastName: this.user.lastName,
        gender: this.user.gender,
        email: this.user.email,
        mobile: this.user.mobile,
        password: this.user.password,
      })
        .then((response) => {
          this.getUsers();
          this.user = {};
        })
        .catch(error => console.log(error));
    },
    getUsers() {
      Vue.axios.get('/api/users/')
        .then(response => this.users = response.data)
        .catch(error => console.log(error))
    }
  },
  created() {
    this.getUsers();
  }
}
</script>

<style lang="sass" scoped>
form
  max-width: 500px
</style>
