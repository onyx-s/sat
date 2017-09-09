<template>
  <div class="container d-flex flex-column align-items-center">
    <template v-if="Object.keys(user).length">
      <h1 class="display-4 mb-4">{{ `${user.firstName} ${user.lastName}` }}</h1>
      <div class="d-flex flex-column align-items-center w-100 table-container">
        <!-- <router-link to="edit" class="btn btn-warning align-self-end mb-2" append>Edit</router-link> -->
        <table class="table table-bordered d-flex mb-5">
          <thead class="thead-default w-25">
            <tr class="d-flex flex-column">
              <th v-if="user.userId">User ID</th>
              <th>Email</th>
              <th>Mobile</th>
              <th v-if="user.staffId">Staff ID</th>
              <th v-if="user.studentId">Student ID</th>
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
          <p v-if="user.cards.length == 1">{{ user.cards[0].cardNo }}</p>
          <ul v-else class="list-group">
            <li v-for="card in user.cards" class="list-group-item">{{ card.cardNo }}</li>
          </ul>
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

.table-bordered th, .table-bordered td
  border: none
  border-top: 1px solid #eceeef
  &:first-child
    border: none

thead, th
  min-width: 105px

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
