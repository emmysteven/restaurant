import { useState, useEffect } from 'react'
import { ShopService } from '../../services/shop.service'

export const Start = () => {
  const [shops, setShops] = useState([])

  useEffect(() => {
    ShopService.getAllShops().then(
      (response) => {
        setShops(response.data)
      },
      (error) => {
        const _content =
          (error.response && error.response.data) ||
          error.message ||
          error.toString()

        setShops(_content)
      }
    )
  }, [])

  const list = shops.map(item => (
      <div className='col-md-3 offset-md-0'  key={item.id}>
        <div className='card'>
          <img className='card-img-top' src={item.imagePath} alt='' />
          <div className='card-body'>
            <h5 className='card-title'>Name: {item.name}</h5>
            <p className='card-text'>Website: {item.website}</p>
            <p className='card-text'>Email: {item.email}</p>
            <p className='card-text'>Phone: {item.phoneNumber}</p>
            <p className='card-text'>State: {item.state}</p>
            <p className='card-text'>LGA: {item.localGovernmentArea}</p>
            <p className='card-text'>Address: {item.address}</p>
          </div>
        </div>
      </div>
    )
  )

  return (
    <div>
        <div className=''>
          <div className='card-deck'>
            {list}
          </div>
        </div>
    </div>
  )
}
