import { useHistory } from "react-router-dom";


export const About = () => {
  const history = useHistory()
  return (
    <div>
      <p className='m-3'>
        Want to contact us? Well you&apos;re at the right place{' '}
        <span role='img' aria-label='wizard'> 🧙‍♂️</span>
      </p>
      <button className='btn btn-dark mx-3 my-2' onClick={ () => {history.push('/')} }>
        Back To Home
      </button>
    </div>
  )
}
