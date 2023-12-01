import React from 'react'
import Image from 'next/image'
import nexus from "../../public/logo-nexus.png"
import { FacebookIcon, Instagram, InstagramIcon, TwitterIcon } from 'lucide-react'


export default function Footer() {
    return (
        <footer id='footer' className='px-12 flex flex-col gap-16'>
            <div className='space-y-16 md:flex md:justify-between md:items-baseline'>
                <div className='space-y-3'>
                    <h1 className='font-bold text-xl tracking-wide md:text-2xl'>SOBRE</h1>
                    <p className='text-lg md:text-xl md:w-1/3'>A Nexum conecta pessoas que buscam crescer no mercado e freelancers que desejam ser vistos pelas suas habilidades</p>
                    <p className='text-xl md:text-2xl font-bold'>tornesse membro</p>
                </div>
                <div className='space-y-3'>
                    <h1 className='font-bold text-xl tracking-wide md:text-2xl'>SERVIÇOS</h1>
                    <ul className='font-medium text-lg md:text-xl'>
                        <li >Plataforma Wab</li>
                        <li >Comunidade Nexum</li>
                        <li >Sobre Nós</li>
                    </ul>
                </div>
            </div>
            <div className=' space-y-16 md:flex md:justify-between md:items-baseline'>
            <div className='space-y-3'>
                <h1 className='font-bold text-xl tracking-wide uppercase md:text-2xl'>ajuda & suporte</h1>
                <ul className='font-medium text-lg md:text-xl'>
                    <li className='uppercase '>saq</li>
                    <li>Contate-nos</li>
                    <li>Cookies</li>
                    <li>Reportar Algo</li>
                </ul>
            </div>
            <div className='space-y-3'>
                <h1 className='font-bold text-xl tracking-wide uppercase md:text-2xl'>redes sociais</h1>
                <ul className='font-medium text-lg md:text-xl'>
                    <li className='flex gap-4 items-center mb-1'><InstagramIcon /> Instagram</li>
                    <li className='flex gap-4 items-center mb-1'><FacebookIcon /> Facebook</li>
                    <li className='flex gap-4 items-center mb-1'> <TwitterIcon /> Twitter</li>
                </ul>
            </div>
            </div>
            <hr />
            <div className='flex justify-between mb-20 '>
                <div className='flex gap-2  items-baseline'>
                    <Image src={nexus} alt='logo' width="36" />
                    <p className='font-bold tracking-widest text-lg'>exum</p>
                </div>
                <p className=' font-thin text-sm w-1/2 xl:w-auto'>COPYRIGHT © 2022 por NEXUM COMPANY - TODOS OS DIREITOS RESERVADOS</p>
            </div>
        </footer>
    )
}
