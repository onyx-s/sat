<template>
    <nav class="navbar navbar-toggleable-md navbar-inverse bg-inverse fixed-top">
      <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <router-link to="/" class="navbar-brand">Onyx</router-link>
      <div class="collapse navbar-collapse" id="navbarsExampleDefault">
        <ul class="navbar-nav ml-auto">
          <router-link tag="li" to="/" class="nav-item">
            <a class="nav-link">Home<span class="sr-only">(current)</span></a>
          </router-link>
          <router-link tag="li" to="/users" class="nav-item">
            <a class="nav-link">Users</a>
          </router-link>
        </ul>
      </div>
    </nav>
</template>

<style lang="sass">
.navbar-inverse .navbar-toggler
  border-color: rgba(255, 255, 255, 0.67)


</style>