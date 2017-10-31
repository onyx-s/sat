<template>
    <div id='app' class="container-fluid">
        <nav-bar></nav-bar>
        <router-view></router-view>   
        <loading></loading>     
    </div>
</template>

<script>
import Vue from 'vue'
import NavBar from './components/NavBar'
import Loading from './components/Loading'

Vue.component('nav-bar', NavBar)
Vue.component('loading', Loading)

export default {
  name: 'app',
}
</script>

<style src="./assets/main.sass" lang="sass"/>