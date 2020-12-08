import { http } from '../utils/index'

const getAllShops = () => {
  return http.get('shop').then(response => response.data)
}

const getShopById = () => {}

const updateShop = () => {}

const deleteShop = () => {}

export const ShopService = {
  getAllShops,
  getShopById,
  updateShop,
  deleteShop
}
