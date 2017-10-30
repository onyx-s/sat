<template>
  <div class="d-flex flex-column align-items-center container">
    <h1 class="display-4">Add a Class</h1>
    <ul v-if="errors.any()">
      <li v-for="error in errors.all()"> {{ error }}</li>
    </ul>
    <section class="row w-100 d-flex align-items-center flex-column">
      <form @submit.prevent="addClass" class="d-flex flex-column w-100 mb-3">
        <fieldset class="form-group">
          <label>Class Name</label>
          <input type="text" name="Class Name" class="form-control" v-validate="{required: true, alpha_spaces: true}" v-model="classGroup.name" />
        </fieldset>
        <fieldset class="form-group">
          <label>Day</label>
          <select input="text" name="Days" class="form-control" v-validate="{required: true}" v-model="classGroup.dayOfWeek">
            <option value="monday">Monday</option>
            <option value="tuesday">Tuesday</option>
            <option value="wednesday">Wednesday</option>
            <option value="thurdsay">Thursday</option>
            <option value="friday">Friday</option>
            <option value="saturday">Saturday</option>
            <option value="sunday">Sunday</option>
          </select>
        </fieldset>
        <fieldset class="form-group">
          <label>Start Time</label>
          <input type="time" name="startTime" class="form-control" v-validate="{required:true}" v-model="classGroup.startTime" />
        </fieldset>
        <fieldset class="form-group">
          <label>End Time</label>
          <input type="time" name="endTime" class="form-control" v-validate="{required: true}" v-model="classGroup.endTime" />
        </fieldset>
        <fieldset class="form-group">
          <label>Location</label>
            <input type="text" name="location" class="form-control" v-validate="{required: true}" v-model="classGroup.location" />
        </fieldset>
        <fieldset class="form-group">
          <label>Teacher ID</label>
          <input type="text" name="teacherId" class="form-control" v-validate="{required: true}" v-model="classGroup.teacherId" />
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
      classGroup: {}
    }
  },
  methods: {
    addClass() {
      console.log(this.classGroup.startTime);
      if (!this.errors.all().length) {
        this.axios.post('/api/classes/', {
          name: this.classGroup.name,
          dayOfWeek: this.classGroup.dayOfWeek,
          startTime: this.classGroup.startTime,
          endTime: this.classGroup.endTime,
          location: this.classGroup.location,
          userId: this.classGroup.teacherId
        })
          .then((response) => {
            this.$router.push({ name: 'classes', params: { alert: 'Class Added' } });
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