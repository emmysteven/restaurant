import axios from 'axios'

export const http = axios.create({
  baseURL: 'https://127.0.0.1:3000/api',
  crossdomain: true,
  headers: {
    'Content-Type': 'application/json; charset=utf-8',
    'Cache-Control': 'no-cache'
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
