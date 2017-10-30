<template>
<div class="container d-flex flex-column">
	<center><h1 class="display-4 mb-4">Welcome, {{ user.firstName }} {{ user.lastName }}</h1></center>
	<div class="content-row">
		<router-link to="addclass" tag="button" class="btn btn-default align-self-start" append>Add Class</router-link>
	</div>
	<table class="table table-bordered mb-5">
		<thead class="thead-default">
			<tr>
				<th>ID</th>
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
	table
		width: 80%
		margin: 0 auto
	
	.btn
		margin-left: 111px
</style>

<script>
export default {
  data() {
    return {
      user: {}
    };
  },
  methods: {
    getUser() {
      this.axios
        .get("/api/users/4")
        .then(response => (this.user = response.data))
        .catch(error => console.log(error));
    }
  },
  created() {
    this.getUser();
  }
};
</script>
