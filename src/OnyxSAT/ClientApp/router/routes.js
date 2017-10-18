import Home from '@/components/Home';
import NotFound from '@/components/404';
import Login from '@/components/Login';
import Users from '@/components/users/Users';
import AddUser from '@/components/users/AddUser';
import UserDetails from '@/components/users/UserDetails';
import Attendances from '@/components/Attendances';

export default [
    { path: '/', component: Home },
    { path: '*', component: NotFound },
    { path: '/login', component: Login },
    { path: '/users', name: 'users', component: Users },
    { path: '/users/add', component: AddUser },
    { path: '/users/:id', component: UserDetails },    
    { path: '/attendances', component: Attendances }    
]