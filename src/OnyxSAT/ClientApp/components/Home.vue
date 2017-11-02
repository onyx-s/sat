<template>

	<div class="d-flex flex-column">
		<h1 class="align-self-center display-4 mb-4">Welcome, {{ user.firstName}} {{user.lastName}}</h1>
		<div class="alert align-self-center">
			<alert v-if="alert" :message="alert"></alert>
		</div>
		<table class="table table-bordered mb-5">
			<thead class="thead-default">
					<tr>
							<th>ID</th>
							<th>Name</th>
							<th>Day</th>
							<th>Start Time</th>
							<th>End Time</th>
							<th>Location</th>
					</tr>
			</thead>

			<tbody>
					<tr v-for="c in user.classes">
							<td>
									<router-link :to="'/Classes/' + c.classId.toString()" append>{{ c.classId }}</router-link>
							</td>
							<td>{{ c.name }}</td>
							<td>{{ c.dayOfWeek }}</td>
							<td>{{ c.startTime.slice(c.startTime.indexOf('T') + 1) }}</td>
							<td>{{ c.endTime.slice(c.endTime.indexOf('T') + 1) }}</td>
							<td>{{ c.location }}</td>
					</tr>
			</tbody>
		</table>
	</div>
</template>

<style lang="sass" scoped>
	.alert
		width: 83%
	table
		width: 80%
		margin: 0 auto
	
	.btn
		margin-left: 111px
</style>

<script>
import Alert from './Alert'
export default {
  data() {
    return {
			user: {},
			alert: ''
    };
  },
  methods: {
    getUser() {
      this.axios
        .get("/api/users/1")
        .then(response => (this.user = response.data))
        .catch(error => console.log(error));
    }
  },
  created() {
    if (this.$route.params.alert)
      this.alert = this.$route.params.alert;
    this.getUser();
  },
	components: {
		Alert
	}

	
};
</script>
