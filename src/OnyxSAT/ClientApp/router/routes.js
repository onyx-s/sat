import Home from '@/components/Home';
import NotFound from '@/components/404';
import Login from '@/components/Login';
import Users from '@/components/users/Users';
import AddUser from '@/components/users/AddUser';
import UserDetails from '@/components/users/UserDetails';
import Attendances from '@/components/classes/AttendanceHistory';
import Class from '@/components/classes/Class';
import UserDetailsEdit from '@/components/users/UserDetailsEdit';
import AddClass from '@/components/AddClass';

export default [
    { path: '/', component: Home },
    { path: '*', component: NotFound },
    { path: '/login', component: Login },
    { path: '/users', name: 'users', component: Users },
    { path: '/users/add', component: AddUser },
    { path: '/users/:id', component: UserDetails },    
    { path: '/attendances', component: Attendances },
    { path: '/classes/:id', component: Class },
    { path: '/users/:id/edit', component: UserDetailsEdit },
    { path: '/classes/add', component: AddClass }
    

]