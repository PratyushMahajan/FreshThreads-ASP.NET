import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5161/api', // Update if different
  headers: {
    'Content-Type': 'application/json',
    Authorization: `Bearer ${localStorage.getItem('token')}`, // Ensure token is set
  },
});

export default api;
