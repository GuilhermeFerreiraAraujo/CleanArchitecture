import axios from 'axios';

const domain = 'https://localhost:7225/'

export function Get(url) {
    return axios.get(`${domain}${url}`);
}

export function Post(url, data) {
    const endpoint =  `${domain}${url}`;
    return axios.post(endpoint, {data})
}

export function Put(url, data){
    axios.put(url, data)
}