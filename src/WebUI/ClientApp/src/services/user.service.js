import { http, keysToCamel } from '../utils/index'
import jwt_decode from 'jwt-decode';

 class UserService {
   isForbidden = false
   data = { token: '', refreshToken: '' }

   login(email, password) {
    return http.post('/user/Tests', { email, password })
      .then(response => {
        if (response.data) {
          this.data = response.data
          localStorage.setItem('token', this.data.token)
          localStorage.setItem('refreshToken', this.data.refreshToken)
        }
        response.data.user = keysToCamel(jwt_decode(this.data.token))
        return response
      })
      .catch(error => {
        if (error.response) return error.response
        // The request was made but no response was received
        if (error.request) return error.request
        // Something happened in setting up the request that triggered an Error
        else return error.message

      })
   }

   register({firstName, lastName, email, phoneNumber, password}) {
     return http.post('/user/register', { firstName, lastName, email, phoneNumber, password })
       .then(response => {
         return response
       })
       .catch(error => {
         if (error.response) return error.response
         if (error.request) return error.request
         else return error.message
       })
   }

   logout() {
     localStorage.removeItem('token')
     return localStorage.removeItem('refreshToken')
   };

   isLoggedIn = (fn) => {
     let token = localStorage.getItem('token')
     if (token === null || token === undefined || token === '') {
       return
     }
     const user = keysToCamel(jwt_decode(token))
     return fn({token, user})
   }

 }

export const userService = new UserService()

