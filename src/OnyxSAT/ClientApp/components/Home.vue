<template>
    <!-- <div class="home align-items-center container">
        <h1 class="display-3">ONYX</h1>
        <h2 class="">Attendence Tracker</h2>
        <h3>Swinburne University</h3>
        <h4>Developed by ONYX</h4>
    </div> -->
    

<div class="container d-flex flex-column">
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
					<router-link :to="c.classId.toString()" append>{{ c.classId }}</router-link>
					</td>
					<td>{{ c.dayOfWeek }}</td>
					<td>{{ c.startTime.slice(c.startTime.indexOf('T') + 1) }}</td>
					<td>{{ c.endTime.slice(c.endTime.indexOf('T') + 1) }}</td>
					<td>{{ c.location }}</td>
				</tr>
		</tbody>
	</table>
	<div>
	<router-link to="addclass" tag="button" class="btn btn-default" append>Add Class</router-link>
</div>
</div>
</template>

<style lang="sass" scoped>
	table
		width: 80%
		margin: 0 auto
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
        .get("/api/users/3")
        .then(response => (this.user = response.data))
        .catch(error => console.log(error));
    }
  },
  created() {
    this.getUser();
  }
};
</script>