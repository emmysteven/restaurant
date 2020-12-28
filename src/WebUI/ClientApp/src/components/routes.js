import {Route, Switch } from 'react-router-dom'
import { Start, Home, About, Contact, Error, Login, Register } from '../pages/index'
import './layout.css'

export const Routes = (
  <div className='mt-5'>
    {/* switch to stop matching after match found */}
    <Switch>
      <Route path={'/'} exact component={Start} />
      <Route path={'/home'} exact component={Home} />
      <Route path='/login' component={Login} />
      <Route path='/contact' component={Contact} />

      <Route path='/register' component={Register} />
      <Route path='/about' component={About} />

      {/* if does not match any route, then 404 route */}
      <Route path='/' component={Error} />
    </Switch>
  </div>
)
