import { useHistory } from "react-router-dom";

export const Error = () => {
  const history = useHistory();
  return (
    <div>
      <p className='m-3'>
        Oops! The page you are looking for does not exist{' '}
        <span role='img' aria-label='sad face'>😥</span>
      </p>
      <p className='m-3'>Maybe try another page?</p>
      <button className='btn btn-dark mx-3 my-2' onClick={ () => {history.push('/')} }>
        Back To Home
      </button>
    </div>
  )
}
