import { render, screen } from '@testing-library/react'
import { App } from '../../app'

describe('Restaurant', () => {
  test('Restaurant should be in the Form', () => {
    render(<App />)
    const Element = screen.getByText('Restaurant')
    expect(Element).toBeInTheDocument()
  })

  // test('Email should be in the Form', () => {
  //   const component = render(<App />)
  //   const labelNode = component.getByText('Email')
  //   expect(labelNode).toBeInTheDocument()
  // })
})
