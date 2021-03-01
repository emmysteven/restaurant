import { http } from '../utils/index'

const getAllShops = () => {
  return http.get('/shop').then(response => response.data)
}

const addShop = (shop) => {
  let formData = new FormData(shop)
  return http.post('/shop', formData, { headers: {
      'Content-Type': 'multipart/form-data'
    }
  })
  .then(response => {
    return response
  })
  .catch(error => {
    if (error.response) return error.response
    if (error.request) return error.request
    else return error.message

  })
}

const getShopById = () => {}

const updateShop = () => {}

const deleteShop = (id) => {
  return http.delete(`/shop/${id}`)
    .then(response => {
      return response
    })
    .catch(error => {
      if (error.response) return error.response
      if (error.request) return error.request
      else return error.message
    })
}

export const ShopService = {
  getAllShops,
  getShopById,
  updateShop,
  deleteShop,
  addShop
}
