<template>
  <div class="d-flex flex-column align-items-center container">
    <h1 class="display-4">Add a Class</h1>
    <section class="row w-100 d-flex align-items-center flex-column">
      <form @submit.prevent="addClass" class="d-flex flex-column w-100 mb-3">
        <fieldset class="form-group">
          <label>Class Name</label>
          <input type="text" name="Class Name" class="form-control" v-validate="{required: true}" v-model="classGroup.name" />
        </fieldset>
        <fieldset class="form-group">
          <label>Day</label>
          <select input="text" name="Days" class="form-control" v-validate="{required: true}" v-model="classGroup.dayOfWeek">
            <option value="Monday">Monday</option>
            <option value="Tuesday">Tuesday</option>
            <option value="Wednesday">Wednesday</option>
            <option value="Thursday">Thursday</option>
            <option value="Friday">Friday</option>
            <option value="Saturday">Saturday</option>
            <option value="Sunday">Sunday</option>
          </select>
        </fieldset>
        <fieldset class="form-group">
          <label>Start Time</label>
          <input type="text" name="startTime" class="form-control" v-validate="{required:true}" v-model="classGroup.startTime" />
        </fieldset>
        <fieldset class="form-group">
          <label>End Time</label>
          <input type="text" name="endTime" class="form-control" v-validate="{required: true}" v-model="classGroup.endTime" />
        </fieldset>
        <fieldset class="form-group">
          <label>Location</label>
            <input type="text" name="location" class="form-control" v-validate="{required: true}" v-model="classGroup.location" />
        </fieldset>
        <fieldset class="form-group">
          <label>Teacher Name</label>
          <select type="text" name="teacherId" class="form-control" v-validate="{required: true}" v-model="selectedUser">
            <option v-for="u in users" :value="u.userId">{{ u.firstName }} {{ u.lastName }}</option>
          </select>
        </fieldset>
        <br>
        <button type="submit" class="submit btn btn-default mb-5">Submit</button>
      </form>
    </section>
  </div>
</template>
<script>
export default {
  data() {
    return {
      classGroup: {},
      users: [],
      selectedUser: ''
    }
  },
  methods: {
    addClass() {
      if (!this.errors.all().length) {
        console.log(this.classGroup);
        this.axios.post('/api/classes/', {
          name: this.classGroup.name,
          dayOfWeek: this.classGroup.dayOfWeek,
          startTime: this.classGroup.startTime,
          endTime: this.classGroup.endTime,
          location: this.classGroup.location,
          userId: this.selectedUser
        })
          .then((response) => {
            this.$router.push({ name: 'home', params: { alert: 'Class Added' } });
          })
          .catch(error => console.log(error));
      }
    },
    getUsers() {
      this.axios.get('/api/users/')
        .then(response => this.users = response.data)
        .catch(error => console.log(error))
        console.log(this.users);
    }
  },
  created() {
    this.getUsers();
  }
}
</script>
<style lang="sass" scoped>
form
  max-width: 500px
  text-align: center
  display: inline

select[name="teacherId"]
  width: 500px

</style>