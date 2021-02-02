import React, { useState, useRef } from 'react'
import { Link, useHistory } from 'react-router-dom'
import { ShopService } from "../../services";


export function AddShop () {
  const [shop, setShop] = useState({
    name: '',
    website: '',
    email: '',
    phoneNumber: '',
    state: '',
    localGovernmentArea: '',
    address: '',
    imageFile: ''
  })
  const [error, setError] = useState(null)
  const [submitted, setSubmitted] = useState(false)
  const form = useRef(null)
  const history = useHistory()

  const acceptedTypes = [
    'image/png',
    'image/jpg',
    'image/jpeg',
  ];


  function handleChange (e) {
    const { name, value } = e.target
    setShop(shop => ({ ...shop, [name]: value }))
  }

  function handleSubmit (e) {
    e.preventDefault()

    setSubmitted(true)
    if (shop.name &&
      shop.website &&
      shop.email &&
      shop.phoneNumber &&
      shop.state &&
      shop.localGovernmentArea &&
      shop.address &&
      shop.imageFile
    ) {
      ShopService
        .addShop(form.current)
        .then((response) => {
          if (response.data.error){
            setSubmitted(false)
            return setError(response.data.error)
          }
          else {
            console.log(response)
            history.push('/home')
          }
        })
    }
  }

  return (
    <div className='col-md-5 offset-md-3'>
      <div className='card'>
        <h4 className='card-header'>Add Shop</h4>
        <div className='card-body'>

          { error ? <div className="alert alert-danger mb-4"> {error} </div> : '' }

          <form ref={form} onSubmit={handleSubmit}>
            <div className='form-group'>
              <label>Name</label>
              <input
                type='text'
                name='name'
                defaultValue={shop.name}
                onChange={handleChange}
                className={'form-control' + (submitted && !shop.name ? ' is-invalid' : '')}
              />

              {submitted && !shop.name && <div className='invalid-feedback'>Name of shop is required</div>}
            </div>

            <div className='form-group'>
              <label>Website</label>
              <input
                type='text'
                name='website'
                defaultValue={shop.website}
                onChange={handleChange}
                className={'form-control' + (submitted && !shop.website ? ' is-invalid' : '')}
              />

              {submitted && !shop.website && <div className='invalid-feedback'>Website is required</div>}
            </div>

            <div className='form-group'>
              <label>Email</label>
              <input
                type='email'
                name='email'
                defaultValue={shop.email}
                onChange={handleChange}
                className={'form-control' + (submitted && !shop.email ? ' is-invalid' : '')}
              />
              {submitted && !shop.email && <div className='invalid-feedback'>Email is required</div>}
            </div>

            <div className='form-group'>
              <label>Phone Number</label>
              <input
                type='tel'
                name='phoneNumber'
                defaultValue={shop.phoneNumber}
                onChange={handleChange}
                className={'form-control' + (submitted && !shop.phoneNumber ? ' is-invalid' : '')}
              />
              {submitted && !shop.phoneNumber && <div className='invalid-feedback'>Phone Number is required</div>}
            </div>

            <div className='form-group'>
              <label>State</label>
              <input
                type='text'
                name='state'
                defaultValue={shop.state}
                onChange={handleChange}
                className={'form-control' + (submitted && !shop.state ? ' is-invalid' : '')}
              />
              {submitted && !shop.state && <div className='invalid-feedback'>State is required</div>}
            </div>

            <div className='form-group'>
              <label>Local Government Area</label>
              <input
                type='text'
                name='localGovernmentArea'
                defaultValue={shop.localGovernmentArea}
                onChange={handleChange}
                className={'form-control' + (submitted && !shop.localGovernmentArea ? ' is-invalid' : '')}
              />
              {submitted && !shop.localGovernmentArea && <div className='invalid-feedback'>LGA is required</div>}
            </div>

            <div className='form-group'>
              <label>address</label>
              <input
                type='text'
                name='address'
                defaultValue={shop.address}
                onChange={handleChange}
                className={'form-control' + (submitted && !shop.address ? ' is-invalid' : '')}
              />
              {submitted && !shop.address && <div className='invalid-feedback'>Address is required</div>}
            </div>

            <div className='form-group'>
              <label>ImageUpload</label>
              <input
                type='file'
                name='imageFile'
                accept={acceptedTypes.toString()}
                defaultValue={shop.imageFile}
                onChange={handleChange}
                className={'form-control' + (submitted && !shop.imageFile ? ' is-invalid' : '')}
              />
              {submitted && !shop.imageFile && <div className='invalid-feedback'>Picture is required</div>}
            </div>

            <div className='form-group'>
              <button className='btn btn-primary'>
                {submitted && <span className='spinner-border spinner-border-sm mr-1' />}
                Add
              </button>
              <Link to='/' className='btn btn-link'>Cancel</Link>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}
