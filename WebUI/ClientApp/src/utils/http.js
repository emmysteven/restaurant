import axios from 'axios'

export const http = axios.create({
  baseURL: 'https://localhost:3000/api/',
  headers: {
    'Content-Type': 'application/json'
  }
})

http.interceptors.request.use(
  (response) => {
    const token = localStorage.getItem('token')
    if (token) response.headers['Authorization'] = `Bearer ${token}`
    return response
  },
  (error) => Promise.reject(error)
)
