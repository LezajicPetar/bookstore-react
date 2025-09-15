import axios from 'axios';

const AxioConfig = axios.create({baseURL: 'http://localhost:8351/api'});

export default AxioConfig;