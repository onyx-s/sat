<template>
  <div class="d-flex flex-column align-items-center container">
    <template v-if="Object.keys(classGroup).length">
      <h1 class="display-4 mb-4">{{ classGroup.name }}</h1>
      <div class="d-flex justify-content-between align-items w-100 mb-3">
        <select type="text" name="sessions" class="form-control" v-validate="'required'" v-model="selectedSession" @change="setSession">
          <option v-for="session in classGroup.sessions" :value="session.dateTime">{{ formatDate(session.dateTime) }}</option>
        </select>
        <button class="btn btn-default text-xs-right float-right" v-on:click="markAllPresent()">Mark All As Present</button>      
      </div>
      <table class="table table-bordered">
        <thead class="thead-default">
          <tr>
            <th>Name</th>
            <th>Student ID</th>
            <th>Phone</th>
            <th>Present</th>
          </tr>
        </thead>
        <tbody class="align-items-middle">
          <tr v-if="classGroup.enrolments" v-for="a in classGroup.enrolments">
            <td>{{ a.user.firstName }} {{ a.user.lastName }}</td>
            <td>{{ a.user.studentId }}</td>
            <td>{{ a.user.mobile }}</td>
            <td>
              <select type="text" name="attended" class="form-control" v-validate="{required: true}" v-model="attended">
                <option value="true">Yes</option>
                <option value="false" :selected="!studentAttended(a.user.cards)">No</option>
              </select>
            </td>
          </tr>
        </tbody>
      </table>
      <div class="mb-5" style="width: 600px;">
        <button class="btn btn-default text-xs-right float-left" v-on:click="saveAttendances()">Save</button>
        <button class="btn btn-default text-xs-right float-right" v-on:click="markAllPresent()">Change all to present</button>
      </div>
    </template>
    <not-found v-if="classNotFound"></not-found>
  </div>
</template>

<script>
import NotFound from '../404'

export default {
  data() {
    return {
      classGroup: {},
      selectedSession: '',
      attended: [],
      classNotFound: false
    }
  },
  methods: {
    getClass(id) {
      this.axios.get('/api/classes/' + id)
        .then(response => {
          this.classGroup = response.data;
          this.setSession();
          })
        .catch(error => {
          if (error.response.status == 404)
            this.classNotFound = true;
          })
    },
    setSession() {
      if(this.classGroup.currentSession) {                
        this.classGroup.currentSession = this.classGroup.sessions.find(session => session.dateTime == this.selectedSession);
      } else {
      // Sets the initial session to the current day's or the most recent one        
        let today = new Date();
        this.classGroup.currentSession = this.classGroup.sessions.reverse().find(session => {
          let dtSplit = session.dateTime.split(/[:T-]/g);          
          let sessionDate = new Date(Date.UTC(dtSplit[0], parseInt(dtSplit[1], 10) - 1, dtSplit[2], dtSplit[3], dtSplit[4], dtSplit[5]));
          return sessionDate <= today;
        });
        this.selectedSession = this.classGroup.currentSession.dateTime;      
      }
    },
    studentAttended(cards) {
      // checks if any of the cards have an attendance in the current session
      if (!cards) return;
      return cards.some(card => {
        return this.classGroup.currentSession.attendances.some(attendance => card.cardNo == attendance.cardNo)     
      });
    },
    formatDate(str) {
      // formats dateTime into dd-mm-yyyy
      return str.slice(0, str.indexOf('T')).split('-').reverse().join('-')
    },
    markAllPresent() {
      // * Will select all option tags, is that the intention?
      let options = document.getElementsByTagName("option");
      for (var i = 0; i < options.length; i++) {
        if (options[i].value === "true") {
          options[i].selected = "selected";
        }
      }
    },
    saveAttendances() {
      let vClass = this.classGroup.enrolments;
      for(var i = 0; i < vClass.length; i++) {
        //Loop through users
        if (attended[i] == "true") {
          //If attended is makred as yes
          if (!this.errors.all().length) {
            //Create attendance for that user
            this.axios.post('/api/attendances', {
              dateDate: this.classGroup.dateTime,
              verified: true,
              cardNo: i.cards[0].cardNo,
              roomNumber: classGroup.roomNumber,
              card: i.cards[0],
              session: classGroup.session[classGroup.session.length-1]
            })
              .catch(error => console.log(error));
          }
        } else {
          this.axios.delete('/api/attendances/' + classGroup.session.length-1)
          .catch(error => console.log(error));
        }
      }
    }
  },
  created() {
    this.getClass(this.$route.params.id);
  },
  components: {
    NotFound
  }
}
</script>

<style scoped>
.container {
  max-width: 650px;
}

select[name="sessions"] {
  width: 130px;
}
</style>