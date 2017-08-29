<template>
  <div class="d-flex flex-column align-items-center">
    <h1 class="display-4">Add a User</h1>
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
        email: this.user.email,
        mobile: this.user.mobile,
        password: this.user.password,
      })
        .then((response) => {
          this.getUsers();
          this.user = {};
        })
        .catch(error => console.log(error));
    }
  }
}
</script>
<<style lang="sass" scoped>
</style>

