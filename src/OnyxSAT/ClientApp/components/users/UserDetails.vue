<template>
  <div class="container d-flex flex-column align-items-center">
    <template v-if="Object.keys(user).length">
      <h1 class="display-4 mb-4">{{ `${user.firstName} ${user.lastName}` }}</h1>
      <div class="d-flex flex-column align-items-center w-100 table-container">
        <!-- <router-link to="edit" class="btn btn-warning align-self-end mb-2" append>Edit</router-link> -->
        <table class="table d-flex mb-5">
          <thead class="w-25">
            <tr class="d-flex flex-column">
              <td v-if="user.userId">User ID</td>
              <td>Email</td>
              <td>Mobile</td>
              <td v-if="user.staffId">Staff ID</td>
              <td v-if="user.studentId">Student ID</td>
            </tr>
          </thead>
          <tbody class="w-75">
            <tr class="d-flex flex-column">
              <td>{{ user.userId }}</td>
              <td>{{ user.email }}</td>
              <td>{{ user.mobile }}</td>
              <td v-if="user.staffId">{{ user.staffId }}</td>
              <td v-if="user.studentId">{{ user.studentId }}</td>
            </tr>
          </tbody>
        </table>
        <div v-if="user.cards.length" class="align-self-start w-100">
          <h3 class="display-4 mb-3">Card{{ user.cards.length > 1 ? 's' : '' }}</h3>
          <ul class="list-group">
            <li v-for="card in user.cards" class="list-group-item">{{ card.cardNo }}</li>
          </ul>
        </div>
        <div class="d-flex d-inline">
          <router-link to="./" tag="button" class="btn align-self-start btn-default">Back</router-link>
          <router-link to="edit" tag="button" class="btn btn-default" append>Edit</router-link>
        </div>
      </div>
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
.btn
  margin-left: 50px
  margin-right: 50px
  width: 100px
thead
  min-width: 105px
  font-weight: bold

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
</style>
