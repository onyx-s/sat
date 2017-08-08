import Home from '@/components/Home';
import NotFound from '@/components/404';
import Users from '@/components/users/Users';

export default [
    { path: '/', component: Home },
    { path: '*', component: NotFound },
    { path: '/users', name: 'users', component: Users },
]