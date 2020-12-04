import {http, keysToCamel} from '../utils'
import jwt_decode from 'jwt-decode';

 class UserService {
   isForbidden = false
   data = ''

   login(email, password) {
    return http.post('/user/login', { email, password })
      .then(response => {
        if (response.data) {
          this.data = response.data
          localStorage.setItem('token', this.data.token)
          localStorage.setItem('refreshToken', this.data.refreshToken)
        }
        const userData = {
          token: this.data.token,
          user: keysToCamel(jwt_decode(this.data.token))
        }
        return userData
      })
      .catch(error => {
        if (error.response) {
          console.log(error.response.data.error);
        } else if (error.request) {
          // The request was made but no response was received
          console.log(error.request);
        } else {
          // Something happened in setting up the request that triggered an Error
          console.log('Error', error.message);
        }
      })
   }

   register({firstName, lastName, email, phoneNumber, password}) {
     return http.post('/user/register', { firstName, lastName, email, phoneNumber, password })
       .then(response => {
         console.log(response)
         return response
       })
       .catch(error => {
         if (error.response) {
           console.log(error.response.data.error);
         } else if (error.request) {
           console.log(error.request);
         } else {
           console.log('Error', error.message);
         }
       })
   }

   logout() {
     localStorage.removeItem('token')
     return localStorage.removeItem('refreshToken')
   };

   isLoggedIn = (fn) => {
     let token = localStorage.getItem('token')
     if (token === null || token === undefined || token === '') {
       return console.log('please login')
     }
     const user = keysToCamel(jwt_decode(token))
     return fn({token, user})
   }

 }

export const userService = new UserService()

