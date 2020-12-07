import { useContext } from 'react'
import { UserContext } from '../utils/index'

export const Home = () => {
  const { userData } = useContext(UserContext)

  return (
    <div>
      {userData.user ? (
        <div className='col-lg-8 offset-lg-2'>
          <h1>Hi {userData.user.firstName}!</h1>
          <p>You&apos;re logged in with React Hooks!!</p>
          <h3>All registered users:</h3>
        </div>
      ) : (
        <div className='col-lg-8 offset-lg-2'>
          <h1>Hi Guest!</h1>
          <p>You&apos;re not logged in with React Hooks!!</p>
        </div>
      )}
    </div>
  )
}
