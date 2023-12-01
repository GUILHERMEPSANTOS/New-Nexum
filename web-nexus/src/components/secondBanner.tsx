import Image from 'next/image'
import React from 'react'
import nexus from "../../public/logo-nexus.png"
import { LaptopIcon, StarIcon, UserIcon } from 'lucide-react'

export default function SecondBanner() {
    return (
        <div className='hidden lg:flex lg:justify-between w-full p-8 2xl:justify-evenly'>
            <div className=' flex items-center md:gap-4 lg:gap-12'>
                <Image width="62" src={nexus} alt='' />
                <hr className='h-32 border border-solid border-purple-800' />
            </div>
            <div className='flex items-center justify-center lg:gap-8 xl:gap-24'>
                <div className='w-52 space-y-2'>
                    <h1 className='text-xl font-bold -tracking-tighter'>Freelancers </h1>
                    <div>
                        <p>Numero de freelancers em nossa plataforma</p>
                        <div className='flex gap-2'>
                            <UserIcon /> <p>75.000 +</p>
                        </div>
                    </div>
                </div>
                <div className='w-52 space-y-2'>
                    <h1 className='text-xl font-bold -tracking-tighter'>Projetos </h1>
                    <div>
                        <p>Busca por novos projetos proporcionados pela Nexum</p>
                        <div className='flex gap-2'>
                            <LaptopIcon /> <p>450.000 +</p>
                        </div>
                    </div>
                </div>
                <div className='w-52 space-y-2'>
                    <h1 className='text-xl font-bold -tracking-tighter'>Freelancers </h1>
                    <div>
                        <p>Numero de freelancers em nossa plataforma</p>
                        <div className='flex gap-2'>
                            <StarIcon /> <p>75.000 +</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
