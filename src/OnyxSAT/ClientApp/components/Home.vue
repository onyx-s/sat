<template>
    <!-- <div class="home align-items-center container">
        <h1 class="display-3">ONYX</h1>
        <h2 class="">Attendence Tracker</h2>
        <h3>Swinburne University</h3>
        <h4>Developed by ONYX</h4>
    </div> -->
    <schedule></schedule>
</template>
<style scoped>
.home {
    text-align: center;
    font-family: Book Antique;
}
h2 {
    color: gray;
    font-size: 64px;
    display: inline;
}
h3 { 
    color: darkgrey;
    font-size: 48px;
    margin-top: 24px;
}
h4 {
    font-size: 18px;
    margin-top: 180px;
}
h5 {
    font-size: 78px;
    margin-top: 24px;
    margin-bottom: 24px;
}
</style>

<script>
import Schedule from './Schedule'

export default {
  data() {
    return {
    }
  },
  methods: {
  },
  components: {
      Schedule
  }
}
</script>