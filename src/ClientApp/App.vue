<template>
    <div id='app' class="container-fluid">
        <nav-bar></nav-bar>
        <router-view></router-view>        
    </div>
</template>

<script>
import Vue from 'vue'
import NavBar from './components/NavBar';

Vue.component('nav-bar', NavBar);

export default {
  name: 'app',
};
</script>

<style lang="sass">
body
    padding-top: 5.5rem
    
button
    cursor: pointer
</style>