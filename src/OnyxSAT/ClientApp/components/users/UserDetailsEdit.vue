<template>
  <div class="container d-flex flex-column align-items-center">
    <template v-if="Object.keys(vUser).length">
      <h1 class="display-4 mb-4">Edit Student Details</h1>
      <form @submit.prevent="updateUser" class="form-container">
        <div class="form-group row">
          <label for="example-text-input" class="col-3 col-form-label">First Name</label>
          <div class="col-7">
            <input class="form-control" type="text" v-validate="{required: true, alpha_spaces: true}" v-model="vUser.firstName" autofocus/>
          </div>
        </div>
        <div class="form-group row">
          <label for="example-search-input" class="col-3 col-form-label">Last Name</label>
          <div class="col-7">
            <input class="form-control" type="text" v-validate="{required: true, alpha_spaces: true}" v-model="vUser.lastName" >
          </div>
        </div>
        <div class="form-group row">
          <label for="example-email-input" class="col-3 col-form-label">Email</label>
          <div class="col-7">
            <input class="form-control" type="email" v-validate="'required'" v-model="vUser.email">
          </div>
        </div>
        <div class="form-group row">
          <label for="example-url-input" class="col-3 col-form-label">Mobile</label>
          <div class="col-7">
            <input class="form-control" type="text" v-validate="{ rules: { required: true, regex: /^04\d{8}$/} }" v-model="vUser.mobile">
          </div>
        </div>
        <div class="form-group row">
          <label for="example-tel-input" class="col-3 col-form-label">Staff ID</label>
          <div class="col-7">
            <input class="form-control" type="text" v-validate="{ numeric: true}" v-model="vUser.staffId">
          </div>
        </div>
        <div class="form-group row">
          <label for="example-password-input" class="col-3 col-form-label">Student ID</label>
          <div class="col-7">
            <input class="form-control" type="text" v-validate="{ numeric: true}" v-model="vUser.studentId">
          </div>
        </div> 
        <div class="form-group row">
          <label for="example-password-input" class="col-3 col-form-label">Card ID</label>
          <div class="col-7">
            <input class="form-control" type="text" v-model="vCard">
          </div>
        </div>  
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
      vUser: {},
      vCard: {},
      userNotFound: false
    }
  },
  methods: {
    getUser(id) {
      Vue.axios.get('/api/users/' + id)
        .then(response => {
          this.vUser = response.data;
          this.vCard = response.data.cards[0].cardNo;
        })
        .catch(error => {
          if (error.response.status == 404)
            this.userNotFound = true;
        })
    },
    updateUser() {
      if (!this.errors.all().length) {
        this.axios.put('/api/users/' + this.$route.params.id, {
          userId: this.user.userId,
          firstName: this.user.firstName,
          lastName: this.user.lastName,
          email: this.user.email,
          mobile: this.user.mobile,
          staffId: this.user.staffId || null,
          studentId: this.user.studentId || null
        })
          .then((response) => {
            this.$router.push({ path: '../' + this.$route.params.id, params: { alert: 'User Updated' } });
          })
          .catch(error => console.log(error.response.data));
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
.form-container
  width: 600px

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
tr
  height: 100% 
</style>
