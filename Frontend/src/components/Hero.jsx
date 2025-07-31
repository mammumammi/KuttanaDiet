import React, { Suspense } from 'react';
import { Canvas } from '@react-three/fiber';




const Hero = () => {
  return (
    <section className='text-amber-50 h-screen w-screen bg-[#001219]'>
      <div className='title h-[50dvh] flex flex-col justify-center items-center text-center text-8xl'>
        <p className='text-center'>Stay Healthy</p>
        <p className='text-center'>Stay Happy</p>
      </div>
    </section>
  );
};

export default Hero;