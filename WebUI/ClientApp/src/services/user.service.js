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
   }

   register(firstName, lastName, email, phoneNumber, password) {
     return http.post('/user/register', {
       firstName,
       lastName,
       email,
       phoneNumber,
       password
     }).then(res => {
       console.log(res.status)
       })
       .catch(err => {
         console.debug(err.message)
       }
     )
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

