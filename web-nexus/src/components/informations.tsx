import React from 'react'
import Image from 'next/image'
import banner from "../../public/banner-nexus.png"
import nexus from "../../public/logo-nexus.png"

import { Button } from './ui/button'
import { Card, CardContent, CardFooter, CardHeader } from './ui/card'

export default function Informations() {
    return (
        <>
            <div id='informations' className='px-4 mb-36 mt-20 md:px-0 lg:flex lg:items-center md:justify-between lg:px-1 2xl:justify-evenly'>
                <div className='flex justify-center items-center mt-16 mb-12'>
                    <Image className='md:width="60" lg:width="180"' alt='banner' src={banner} />
                </div>
                <div className='space-y-4 lg:w-1/2'>
                    <h1 className='font-bold text-2xl -tracking-tighter lg:text-4xl 2xl:max-w-3xl 2xl:text-6xl'>
                        <span className='text-purple-800 '>Nexum</span> tudo que você precisa em apenas um só lugar
                    </h1>
                    <p className='font-medium text-xl text-gray-200 lg:text-2xl 2xl:max-w-xl'>Criada por quem entende para quem entende, rápida, moderna e sem burocracias</p>
                    <Button className='w-full text-xl font-medium -tracking-tighter md:w-96'>Abra a sua conta</Button>
                </div>
            </div>
            <div className='px-4 mb-36 mt-20 md:px-14 flex lg:items-center lg:justify-between 2xl:justify-evenly'>
                <div className='flex justify-center items-center mb-28 flex-1 lg:hidden'>
                    <Image alt='nexus' src={nexus} />
                </div>
                <div className='flex items-center gap-16'>
                    <Image className='hidden lg:block' alt='nexus' src={nexus} width="180" />
                    <hr className='hidden lg:block h-48 border border-solid border-purple-800' />
                </div>
                <div className='hidden lg:block w-3/6'>
                    <h1 className='font-bold text-2xl -tracking-tighter mb-10 md:text-4xl'>Sobre a <span className='text-purple-800'>Nexum</span></h1>
                    <p className='font-medium text-xl mb-6 md:text-2xl'>A Nexum nasce com o propósito de facilitar a vida do freelancer assim como do empregador de forma onde o empregador
                        é quem buscar o freelancer e não o contrário, isso possibilita que o empregador só entre em contato com o colaborador
                        se de fato houver o interesse por seus trabalhos</p>
                    <Button className='w-full text-xl font-medium -tracking-tighter md:w-4/5'>
                        Descubra mais sobre nós
                    </Button>
                </div>
            </div>
            <div id='frellancer' className='px-4 mb-36 mt-14 flex flex-col items-center gap-8 md:gap-16 md:px-14 xl:flex-row'>
                <div className='space-y-6 md:space-y-12'>
                    <h3 className='uppercase font-semibold text-xl md:text-2xl 2xl:text-3xl'>crie agora mesmo a sua conta</h3>
                    <h1 className='font-bold text-2xl -tracking-tighter md:text-4xl 2xl:text-6xl'>Encontre o melhor da <span className='text-purple-800'>Nexum</span></h1>
                    <p className='font-medium text-xl text-gray-200 md:text-2xl 2xl:text-4xl'>
                        Conecte-se a pessoas que buscam crescer no mercado e freelancers que desejam ser vistos pelas suas habilidades
                    </p>
                </div>
                <div className='flex flex-col gap-6 md:gap-12 2xl:flex-row'>
                    <Card className='bg-[#101010] border-transparent shadow-sm shadow-purple-800'>
                        <CardHeader>
                            <CardContent>
                                <h1 className='font-bold text-2xl -tracking-tighter mb-6 md:text-4xl'>Frellancer</h1>
                                <h3 className='font-medium text-xl text-start mb-12 md:text-2xl'>Para você que deseja encontrar o trabalho perfeito</h3>
                            </CardContent>
                            <CardFooter>
                                <Button className='w-full text-xl font-medium md:p-6'>Conta Freelancer</Button>
                            </CardFooter>
                        </CardHeader>
                    </Card>
                    <Card className='bg-[#101010] border-transparent shadow-sm shadow-purple-800'>
                        <CardHeader>
                            <CardContent>
                                <h1 className='font-bold text-2xl -tracking-tighter mb-6 md:text-4xl'>Contratante</h1>
                                <h3 className='font-medium text-xl text-start mb-12 md:text-2xl'>Para você que busca encontrar os melhores pofissionais</h3>
                            </CardContent>
                            <CardFooter>
                                <Button variant="outline" className='border-violet-700 bg-[#101010] w-full text-xl font-medium md:p-6'>Conta Contratante</Button>
                            </CardFooter>
                        </CardHeader>
                    </Card>
                </div>
            </div>
        </>
    )
}
