<template>
    <div class="container d-flex flex-column">
    <h1 class="display-4">All Users</h1>
    <div class="content-row">
        <div class="dropdown">
            <button class="btn-default dropdown-toggle" type="button" data-toggle="dropdown">Filter by block
            <span class="caret"></span></button>
            <ul class="dropdown-menu">
                <li>A</li>
                <li>B</li>
                <li>C</li>
            </ul>
        </div>
        <router-link to="/users/add" tag="button" class="nav-item btn-default btn-md add-student">Add Student</router-link>
    </div>
    <table class="table table-bordered mb-5">
        <thead class="thead-default">
        <tr>
            <th>ID</th>
            <th>Firstname</th>
            <th>Lastname</th>
            <th>Email</th>
            <th>Mobile</th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="u in users">
            <td><router-link :to="u.userId.toString()" append>{{ u.userId }}</router-link></td>
            <td>{{ u.firstName  }}</td>
            <td>{{ u.lastName }}</td>
            <td>{{ u.email }}</td>
            <td>{{ u.mobile }}</td>
        </tr>
        </tbody>
    </table>
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

<style>

.dropdown {
    display: inline;
}
.content-row {
    display: inline;
    padding-bottom: 15px;
}

.add-student {
    display: inline;
    position: relative;
    width: 150px;
    align-self: right;
}

.display-4 {
    text-align: center;
    color: gray;
    font-size: 72px;
}
</style>
