import axios from 'axios';

const API_URL = 'http://localhost:5124/api';

const apiClient = axios.create({
    baseURL : API_URL,
    headers : {
        'Content-Type' : 'application/json',
    },
});

export default apiClient;