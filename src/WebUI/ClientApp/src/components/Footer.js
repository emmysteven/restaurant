import React from 'react'
import './Layout.css'

export const Footer = () => (
  <footer className='footer py-3'>
    <div className='container'>
      <span className='text-muted'>
        &copy; {(new Date().getFullYear())}, created by
        <a href='https://emmysteven.com' target='blank'> emmysteven</a>
      </span>
    </div>
  </footer>
)
