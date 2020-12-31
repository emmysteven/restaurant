import React, { useContext, useState } from 'react'
import { Link, useHistory } from "react-router-dom";
import { UserContext } from '../../utils/index'
import { userService } from '../../services/index'

export const Login = () => {
  const [inputs, setInputs] = useState({ email: '', password: '' })
  const [submitted, setSubmitted] = useState(false)
  const [error, setError] = useState(null)
  const [loading, setLoading] = useState(false)
  const { email, password } = inputs
  const { setUserData } = useContext(UserContext)
  const history = useHistory()

  function handleChange (e) {
    const { name, value } = e.target
    setInputs(inputs => ({ ...inputs, [name]: value }))
  }

  function handleSubmit (e) {
    e.preventDefault()
    setLoading(true)
    setSubmitted(true)

    if (email && password) {
      userService
        .login(email, password)
        .then((response) => {
          if (response.data.error){
            setLoading(false)
            setSubmitted(false)
            return setError(response.data.error)
          }
          setUserData({
            token: response.data.token,
            user: response.data.user
          })
          setLoading(false)
          history.push('/home')
        })
    }
  }

  return (
    <div className='col-md-3 offset-md-5'>
      <div className='card'>
        <h4 className='card-header'>Login</h4>
        <div className='card-body'>

          { error ? <div className="alert alert-danger mb-4"> {error} </div> : '' }

          <form name='form' onSubmit={handleSubmit} autoComplete='off'>
            <div className='form-group'>
              <label htmlFor='Email'>Email</label>
              <input
                type='text' name='email' value={email} onChange={handleChange}
                className={'form-control' + (submitted && !email ? ' is-invalid' : '')}
              />
              {submitted && !email && <div className='invalid-feedback'>Email is required</div>}
            </div>

            <div className='form-group'>
              <label htmlFor='Password'>Password</label>
              <input
                type='password' name='password' value={password} onChange={handleChange}
                className={'form-control' + (submitted && !password ? ' is-invalid' : '')}
              />
              {submitted && !password && <div className='invalid-feedback'>Password is required</div>}
            </div>

            <div className='form-group'>
              <button className='btn btn-primary'>
                {loading && <span className='spinner-border spinner-border-sm mr-1' />}
                Login
              </button>
              <Link to='/register' className='btn btn-link'>Register</Link>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}
