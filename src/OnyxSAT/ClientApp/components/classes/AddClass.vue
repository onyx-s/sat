<template>
  <div class="d-flex flex-column align-items-center container">
    <!-- Location popup -->
    <div id="background" style="display: none !important;" class="d-flex flex-column align-items-center">
      <div class="location-box">
        <form @submit.prevent="createLocation" class="d-flex align-items-center flex-column">
          <fieldset class="d-flex d-inline">
            <label>Room Name</label>
            <input type="text" class="form-control" v-validate="{required: true}" v-model="roomNumber"></input>
          </fieldset>
          <fieldset>
            <label>Scanner Number</label>
            <input type="text" class="form-control mb-3" v-validate="{required: true}" v-model="scannerNumber"></input>
          </fieldset>
          <div class="d-flex d-inline">
            <button type="submit" class="submit btn btn-success mr-2">Add</button>
            <button type="button" class="submit btn btn-default" v-on:click="toggleLocations()">Back</button>
          </div>
        </form>
      </div>
    </div>
    <!-- Content start -->
    <h1 class="display-4">Add a Class</h1>
    <section class="row w-100 d-flex align-items-center flex-column">
      <form @submit.prevent="addClass" class="d-flex flex-column w-100 mb-3">
        <fieldset class="form-group">
          <label>Class Name</label>
          <input type="text" name="Class Name" class="form-control" v-validate="{required: true}" v-model="classGroup.name" />
        </fieldset>
        <fieldset class="form-group w-50 align-self-center">
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
        <div class="d-flex d-inline">
          <fieldset class="form-group w-50">
            <label>Start Time</label>
            <input type="time" name="startTime" class="form-control" v-validate="{required:true}" v-model="startTime" />
          </fieldset>
          <fieldset class="form-group w-50">
            <label>End Time</label>
            <input type="time" name="endTime" class="form-control" v-validate="{required: true}" v-model="endTime" />
          </fieldset>
        </div>
        <div class="d-flex d-inline">
          <fieldset class="form-group w-50">
            <label>Start Date</label>
            <input type="date" name="endTime" class="form-control" v-validate="{required: true}" v-model="startDate" />
          </fieldset>
          <fieldset class="form-group w-50">
            <label>End Date</label>
            <input type="date" name="endTime" class="form-control" v-validate="{required: true}" v-model="endDate" />
          </fieldset>
        </div>
        <fieldset class="form-group align-self-center">
          <label>Location</label>
          <div class="d-flex d-inline">
            <select type="text" name="location" class="form-control form-locaton" v-model="selectedRoom">
              <option v-for="i in locations" :value="i.RoomNumber">{{ i.roomNumber }}</option>
            </select>
            <button type="button" v-on:click="toggleLocations()" class="btn btn-default align-self-start">Add Location</button>
          </div>
          <alert v-if="alert" :message="alert"></alert>
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
import Alert from '../Alert'
export default {
  data() {
    return {
      classGroup: {},
      startTime: "",
      endTime: "",
      startDate: "",
      endDate: "",
      roomNumber: "",
      scannerNumber: "",

      alert: '',
      users: [],
      locations: [],
      selectedUser: '',
      selectedRoom: {}
    }
  },
  methods: {
    addClass() {
      if (!this.errors.all().length) {
        this.classGroup.startTime = this.startDate + "T" + this.startTime + ":00";
        this.classGroup.endTime = this.startDate + "T" + this.startTime + ":00";
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
    },
    getLocations() {
      this.axios.get('/api/locations/')
        .then(response => this.locations = response.data)
        .catch(error => console.log(error))
        console.log(this.locations);
    },
    createLocation() {
      this.axios.post('/api/locations/', {
        roomNumber: this.roomNumber,
        scannerNumber: this.scannerNumber
      }).then((response) => {
        this.alert = this.roomNumber + ' Added';
        this.toggleLocations();
        this.getLocations();
      }).catch(error => console.log(error))
    },
    toggleLocations() {
      let p = document.getElementById("background");
      if (p.style.display == "none" || p.style.display == "none !important") {
        p.setAttribute("style","display: block !important;");
      } else {
        p.setAttribute("style","display: none !important;");
      }
    }
  },
  created() {
    this.getUsers();
    this.getLocations();
  },
  components: {
      Alert
  }
}
</script>
<style scoped>
.location-box {
  float: none;
  margin: 20% auto;
  display: block;
  padding-top: 8px;
  box-shadow: 0px 0px 5px grey;
  border-radius: 25px;
  width: 300px;
  height: 220px;
  background-color: #fff;
}
#background {
  left: 0px;
  top: 0px;
  width: 100%;
  height: 100%;
  position: absolute;
  background: rgba(255,255,255,0.5);
  z-index: 5;
}
form {
  max-width: 500px;
  text-align: center;
  display: inline;
}
select[name="location"] {
  width: auto;
}
select[name="teacherId"] {
  width: 500px;
}
</style>