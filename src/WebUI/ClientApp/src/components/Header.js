import { useContext } from 'react'
import { NavLink, useHistory } from 'react-router-dom'
import { UserContext } from '../utils/index'
import { userService } from '../services/index'

export const Header = () => {
  const { userData, setUserData } = useContext(UserContext)
  const history = useHistory()

  function logout() {
    userService.logout();
    setUserData({ token: undefined, user: undefined })
    history.push('/Tests')
  }

  return(
    <nav className="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
      <NavLink className="navbar-brand" to="/">Restaurant</NavLink>
      <button
        type="button"
        data-toggle="collapse"
        className="navbar-toggler"
        data-target="#navbarDefault"
        aria-controls="navbarDefault"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span className="navbar-toggler-icon"></span>
      </button>

      <div className="collapse navbar-collapse" id="navbarDefault">

        <ul className="navbar-nav mr-auto">
          <li className="nav-item">
            <NavLink className="nav-link nav-item" to="/about">About</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link nav-item" to="/contact">Contact</NavLink>
          </li>
        </ul>

        {userData.user ? (
          <ul className="navbar-nav ml-auto">
            <li className="nav-item">
              <div className="nav-link" role="button" onClick={logout}>Logout</div>
            </li>
          </ul>
        ) : (
          <ul className="navbar-nav ml-auto">
            <li className="nav-item">
              <NavLink className="nav-link nav-item" to="/login">Login</NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link nav-item" to="/register">Register</NavLink>
            </li>
          </ul>
        )}

      </div>
    </nav>
  )
};
