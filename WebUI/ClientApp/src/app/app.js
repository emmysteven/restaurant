import React, { useEffect, useState } from 'react'
import { BrowserRouter } from 'react-router-dom'
// import './app.css';
import { Header, Footer, Routes } from "../components/index";
import { userService } from '../services/index'
import { UserContext } from '../utils/index'

export function App() {
  const [userData, setUserData] = useState({
    token: undefined,
    user: undefined
  })

  useEffect(() => {
    userService.isLoggedIn(setUserData)
  }, [])

  return (
    <BrowserRouter>
      <UserContext.Provider value={{ userData, setUserData }}>
        <div className="App" data-testid="app">
          <Header/>
            { Routes }
          <Footer/>
        </div>
      </UserContext.Provider>
    </BrowserRouter>
  );
}

