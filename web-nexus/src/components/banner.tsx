import React from 'react'

import { Button } from './ui/button'
import { CheckCircleIcon, MapPinIcon } from 'lucide-react'
import CardApresentation from './cardApresentation'



export default function Banner() {
    return (
        <div className='h-full flex justify-center items-center xl:justify-between px-8'>
            <div className='flex justify-center items-center flex-col tracking-wide text-center gap-4 md:w-9/12 2xl:gap-10'>
                <h1 className='font-bold text-4xl md:text-6xl'> <span className='text-purple-800'>Nexum</span> criado para você encontrar a <span className='text-purple-800'>conexão</span> perfeita</h1>
                <p className='font-light text-2xl md:text-3xl'>A Nexum conecta pessoas que buscam crescer no mercado e freelancers que desejam ser vistos pelas suas habilidades</p>
                <h3 className='uppercase font-semibold text-lg md:text-2xl'>crie agora mesmo sua conta</h3>
                <div className='space-x-6'>
                    <Button className='text-base font-medium tracking-wide md:p-6'>Freelancer</Button>
                    <Button className='border-violet-700 bg-[#101010] text-base font-medium tracking-wide md:p-6' variant="outline">Contratante</Button>
                </div>
            </div>
            <div className='hidden lg:hidden xl:block h-5/6'>
                <ul className='h-full lg:w-[180px] 2xl:w-[280px] flexflex-col justify-center'>
                    <li className="bg-[url('../../public/person-card-2.png')]  lg:bg-contain lg:bg-no-repeat lg:h-[90px] 2xl:h-[124px] px-2 flex items-end pb-4">
                        <CardApresentation name='Frodo Baggins' profession='Desenvolvedor de Software' location='São Paulo, São Paulo' />
                    </li>
                    <li className="bg-[url('../../public/person-card-1.png')]  lg:bg-contain lg:bg-no-repeat lg:h-[280px] 2xl:h-[440px] pt-48  px-2 flex items-end pb-4">
                        <CardApresentation name='Ana Carolina' profession='Design' location='Osasco, São Paulo' />
                    </li>
                    <li className="bg-[url('../../public/person-card-3.png')]  lg:bg-contain lg:bg-no-repeat lg:h-[96px] 2xl:h-[152px]"></li>
                </ul>
            </div>
        </div >
    )
}
