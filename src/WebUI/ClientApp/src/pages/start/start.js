import { useHistory } from "react-router-dom";

export const Start = () => {
  const history = useHistory();
  return (
    <div>
      <p className=''>
        Want to start out with us? Well you&apos;re at the right place{' '}
        <span role='img' aria-label='wizard'> 🧙‍♂️</span>
      </p>
      <button className='btn btn-dark mx-3 my-2' onClick={ () => {history.push('/login')} }>
        Login
      </button>
    </div>
  )
}
