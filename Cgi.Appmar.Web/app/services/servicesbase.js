import axios from 'axios';

export function Get(url) {
    return axios.Get(url);
}

export function Post(url, data) {
    return axios.post(url, data)
}

export function Put(url, data){
    axios.put(url, data)
}