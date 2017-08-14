import 'bootstrap';
import Vue from 'vue';
import VeeValidate from 'vee-validate';
import App from './App';
import router from './router';

Vue.use(VeeValidate);

Vue.config.productionTip = false;

new Vue({
    el: '#app',
    router,
    render: h => h(App)
});
