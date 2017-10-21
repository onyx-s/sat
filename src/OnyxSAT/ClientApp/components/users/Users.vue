<template>
    <div class="container d-flex flex-column">
        <h1 class="display-4 align-self-center">All Users</h1>
        <div class="content-row">
            <alert v-if="alert" :message="alert"></alert>
            <!--
            <div class="dropdown">
                <button class="btn-default dropdown-toggle" type="button" data-toggle="dropdown">Filter by block
                    <span class="caret"></span>
                </button>
                <ul class="dropdown-menu">
                    <li>A</li>
                    <li>B</li>
                    <li>C</li>
                </ul>
            </div>
            -->
            <router-link to="/users/add" tag="button" class="nav-item btn-default btn-md add-student">Add User</router-link>
            <button type="button" id="btnDelete" disabled>Delete</button>
        </div>
        <table class="table table-bordered mb-5">
            <thead class="thead-default">
                <tr>
                    <th></th>
                    <th>ID</th>
                    <th>Firstname</th>
                    <th>Lastname</th>
                    <th>Email</th>
                    <th>Mobile</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="u in users">
                    <td><input type="checkbox" id="checkbox" onclick=btnDeleteStatus() v-model="checked"></td>
                    <td>
                        <router-link :to="u.userId.toString()" append>{{ u.userId }}</router-link>
                    </td>
                    <td>{{ u.firstName }}</td>
                    <td>{{ u.lastName }}</td>
                    <td>{{ u.email }}</td>
                    <td>{{ u.mobile }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import Alert from '../Alert'
export default {
    data() {
        return {
            users: [],
            alert: ''
        }
    },
    methods: {
        getUsers() {
            this.axios.get('/api/users/')
                .then(response => this.users = response.data)
                .catch(error => console.log(error))
        }
    },
    created() {
        if (this.$route.params.alert)
            this.alert = this.$route.params.alert;
        this.getUsers();
    },
    components: {
        Alert
    }
}

function btnDeleteStatus() {
    if (document.getElementById("checkbox").checked == true) {
        document.getElementById("btnDelete").disabled = false;
    }
    else {
        document.getElementById("btnDelete").disabled = true;
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
.delete {
    display: inline;
    position: relative; 
    width: 150px;
    align-self: right;
}
</style>