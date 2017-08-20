import 'bootstrap'
import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VeeValidate from 'vee-validate'
import App from './App'
import router from './router'

Vue.use(VueAxios, axios)
Vue.use(VeeValidate)

Vue.config.productionTip = false

Vue.axios.defaults.headers.common['Authorization'] = 'Bearer ' + localStorage.getItem('token')

new Vue({
    el: '#app',
    router,
    render: h => h(App)
})
