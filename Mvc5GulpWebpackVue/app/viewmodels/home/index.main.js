import Vue from 'vue'
import App from './index.vue'


//const routes = [
//    { path: '/spa', component: Spa }
//];

//Vue.use(Router);


//const router = new Router({
//    routes,
//    mode: 'history',
//    root: '/spa'
//});

new Vue({
    el: '#app',
    //router,
    render: h => h(App)
})