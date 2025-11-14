import axios from 'axios';

const AxioConfig = axios.create({baseURL: 'http://localhost:5234/api'});

export default AxioConfig;