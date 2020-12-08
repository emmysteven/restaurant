import React, { useState } from 'react'
import { Link, useHistory } from 'react-router-dom'
import { userService } from "../../services";


export function Register () {
  const [user, setUser] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    password: ''
  })
  const [error, setError] = useState(null)
  const [submitted, setSubmitted] = useState(false)
  const history = useHistory()


  function handleChange (e) {
    const { name, value } = e.target
    setUser(user => ({ ...user, [name]: value }))
  }

  function handleSubmit (e) {
    e.preventDefault()

    setSubmitted(true)
    if (user.firstName && user.lastName && user.email && user.phoneNumber && user.password) {
      userService
        .register(user)
        .then((response) => {
          if (response.data.error){
            setSubmitted(false)
            return setError(response.data.error)
          }
          history.push('/login')
        })
    }
  }

  return (
    <div className='col-md-5 offset-md-3'>
      <div className='card'>
        <h4 className='card-header'>Register</h4>
        <div className='card-body'>

          { error ? <div className="alert alert-danger mb-4"> {error} </div> : '' }

          <form name='form' onSubmit={handleSubmit}>
            <div className='form-group'>
              <label>First Name</label>
              <input
                type='text'
                name='firstName'
                value={user.firstName}
                onChange={handleChange}
                className={'form-control' + (submitted && !user.firstName ? ' is-invalid' : '')}
              />

              {submitted && !user.firstName && <div className='invalid-feedback'>First Name is required</div>}
            </div>

            <div className='form-group'>
              <label>Last Name</label>
              <input
                type='text'
                name='lastName'
                value={user.lastName}
                onChange={handleChange}
                className={'form-control' + (submitted && !user.lastName ? ' is-invalid' : '')}
              />

              {submitted && !user.lastName && <div className='invalid-feedback'>Last Name is required</div>}
            </div>

            <div className='form-group'>
              <label>Email</label>
              <input
                type='email'
                name='email'
                value={user.email}
                onChange={handleChange}
                className={'form-control' + (submitted && !user.email ? ' is-invalid' : '')}
              />
              {submitted && !user.email && <div className='invalid-feedback'>Email is required</div>}
            </div>

            <div className='form-group'>
              <label>Phone Number</label>
              <input
                type='tel'
                name='phoneNumber'
                value={user.phoneNumber}
                onChange={handleChange}
                className={'form-control' + (submitted && !user.phoneNumber ? ' is-invalid' : '')}
              />
              {submitted && !user.phoneNumber && <div className='invalid-feedback'>Phone Number is required</div>}
            </div>

            <div className='form-group'>
              <label>Password</label>
              <input
                type='password'
                name='password'
                value={user.password}
                onChange={handleChange}
                className={'form-control' + (submitted && !user.password ? ' is-invalid' : '')}
              />
              {submitted && !user.password && <div className='invalid-feedback'>Password is required</div>}
            </div>

            <div className='form-group'>
              <button className='btn btn-primary'>
                {submitted && <span className='spinner-border spinner-border-sm mr-1' />}
                Register
              </button>
              <Link to='/login' className='btn btn-link'>Cancel</Link>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}
