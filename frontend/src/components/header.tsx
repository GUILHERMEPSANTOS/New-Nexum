import React from 'react'
import Image from 'next/image'
import logo from "../../public/logo-name-nexus.png"

import { MenuIcon } from 'lucide-react'

import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetTrigger } from '@/components/ui/sheet'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList, CommandSeparator } from '@/components/ui/command'
import { Button } from './ui/button'
import SingIn from './signIn'

export default function Header() {
    return (
        <header className="w-full h-16 bg-transparent px-14 fixed top-0 z-10">
            <div className='md:flex md:justify-between md:items-center h-full' >
                <nav className='hidden lg:block'>
                    <div className='flex gap-12 items-baseline'>
                        <div>
                            <a href="#"><Image src={logo} alt='logo' width="88" className='cursor-pointer' /></a>
                        </div>
                        <ul className='flex gap-10 '>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>
                                <a href="">Início</a>
                            </li>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>
                                <a href="#informations">Sobre nós</a>
                            </li>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>
                                <a href="#frellancer">Freelancer</a>
                            </li>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>
                                <a href="#frellancer">Contratante</a>
                            </li>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>
                                <a href="#footer">Contato</a>
                            </li>
                        </ul>
                    </div>
                </nav>
                <nav className='lg:hidden flex justify-between items-center h-full md:justify-start'>
                    <Sheet>
                        <SheetTrigger>
                            <MenuIcon width="40" />
                        </SheetTrigger>
                        <SheetContent className='w-full' side="left">
                            <SheetHeader>
                                <SheetTitle className='flex justify-center items-center'> <Image src={logo} alt='logo' width="88" /></SheetTitle>
                            </SheetHeader>
                            <Command>
                                <CommandInput placeholder="Type a command or search..." />
                                <CommandList>
                                    <CommandEmpty>No results found.</CommandEmpty>
                                    <CommandGroup heading="Sugestões">
                                        <CommandItem>Inicio</CommandItem>
                                        <CommandItem>Sobre nós</CommandItem>
                                        <CommandItem>Freelancer</CommandItem>
                                        <CommandItem>Contratante</CommandItem>
                                    </CommandGroup>
                                    <CommandSeparator />
                                    <CommandGroup heading="Junte se a nós">
                                        <CommandItem>Entrar</CommandItem>
                                        <CommandItem>Criar conta</CommandItem>
                                    </CommandGroup>
                                </CommandList>
                            </Command>
                        </SheetContent>
                    </Sheet>
                    <Image src={logo} alt='logo' width="88" />
                </nav>
                <div className='md:flex md:gap-4'>
                    <SingIn />
                    {/* <Button className='hidden md:block px-6' variant="ghost">Entrar</Button> */}
                    <Button className='hidden md:block text-base font-medium tracking-wide px-6'>Criar conta</Button>
                </div>
            </div >
        </header >
    )
}
