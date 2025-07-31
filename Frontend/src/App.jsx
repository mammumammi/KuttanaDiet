import { div } from 'framer-motion/client'
import React from 'react'
import Hero from './components/Hero'
import Food from './components/Food'

const App = () => {
  return (
    <div className='bg-[#001219] overflow-x-hidden'>
      <Hero/>    
      <Food/>  
    </div>
  )
}

export default App