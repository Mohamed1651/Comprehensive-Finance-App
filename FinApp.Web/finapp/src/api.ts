import axios from 'axios';

const api = axios.create({
    baseURL: '/api',
    withCredentials: true,     
});

export function getUsers() {
    return api.get('/users');
}
//export function createUser(userDto) {
//    return api.post('/users', userDto);
//}