<template>
  <div class="d-flex flex-column align-items-center container">
    <h1 class="display-4">Add a User</h1>
    <ul v-if="errors.any()">
      <li v-for="error in errors.all()"> {{ error }}</li>
    </ul>
    <section class="row w-100 d-flex align-items-center flex-column">
      <form @submit.prevent="addUser" class="d-flex flex-column w-100 mb-3">
        <fieldset class="form-group">
          <label>First Name</label>
          <input type="text" name="First Name" class="form-control" v-validate="{required: true, alpha_spaces: true}" v-model="user.firstName" />
        </fieldset>
        <fieldset class="form-group">
          <label>Last Name</label>
          <input type="text" name="Last Name" class="form-control" v-validate="{required: true, alpha_spaces: true}" v-model="user.lastName" />
        </fieldset>
        <fieldset class="form-group">
          <label>Email</label>
          <input type="email" name="Email" class="form-control" v-validate="'required'" v-model="user.email" />
        </fieldset>
        <fieldset class="form-group">
          <label>Mobile</label>
          <input type="text" name="Mobile" class="form-control" v-validate="{ rules: { required: true, regex: /^04\d{8}$/} }" v-model="user.mobile" />
        </fieldset>
        <fieldset class="form-inline">
          <label>User ID</label>
          <span class="form-inline">
            <select type="text" name="userType" class="form-control" v-validate="{required: true}" v-model="user.userType" >
              <option value="student" v-model="user.userType">Student</option>
              <option value="staff" v-model="user.userType">Staff</option>
            </select>
            <input type="text" name="studentId" class="form-control" v-if="this.user.userType === 'student'" v-validate="{numeric: true}" v-model="user.studentId" />
            <input type="text" name="staffId" class="form-control" v-if="this.user.userType === 'staff'" v-validate="{numeric: true}" v-model="user.staffId" />
          </span>
        </fieldset>
        <br>
        <button type="submit" class="submit btn btn-default">Submit</button>
      </form>
    </section>
  </div>
</template>
<script>
export default {
  data() {
    return {
      user: {}
    }
  },
  methods: {
    addUser() {
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
            this.$router.push({ name: 'users', params: { alert: 'User Added' } });
          })
          .catch(error => console.log(error));
      }
    }
  }
}
</script>
<style lang="sass" scoped>
form
  max-width: 500px
  text-align: center
  display: inline
</style>