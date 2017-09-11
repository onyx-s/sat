<template>
  <div class="container d-flex flex-column align-items-center justify-content-center">
    <h1 class="display-4 mb-4 mt-4">Log In</h1>
    <a href="/google/login" class="display-4 text-center w-100"><img src="../assets/img/google.jpg"></img>oogle</a>
  </div>
</template>

<style lang="sass" scoped>
.container
  max-width: 400px

h1
  align-self: start
  font-size: 2.5em
  padding-bottom: 6px

a
  border: 1px solid #ea4335
  border-radius: 10px
  color: #444
  font-size: 2em
  padding: 30px
  min-width: 215px
  &:hover
    text-decoration: none
    border-color: blue

img
  height: 2em
  width: 2em
</style>
