import React from 'react'
import Image from 'next/image'
import logo from "../../public/logo-name-nexus.png"

import { MenuIcon } from 'lucide-react'

import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetTrigger } from '@/components/ui/sheet'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList, CommandSeparator } from '@/components/ui/command'
import { Button } from './ui/button'

export default function Header() {
    return (
        <header className='w-full h-16'>
            <div className='md:flex md:justify-between md:items-center h-full'>
                <nav className='hidden lg:block'>
                    <div className='flex gap-12 items-baseline'>
                        <div>
                            <Image src={logo} alt='logo' width="88" className='cursor-pointer' />
                        </div>
                        <ul className='flex gap-10 '>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>Início</li>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>Sobre nós</li>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>Freelancer</li>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>Contratante</li>
                            <li className='hover:border-b hover:text-gray-300 cursor-pointer'>Contato</li>
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
                    <Button className='hidden md:block px-6' variant="ghost">Entrar</Button>
                    <Button className='hidden md:block text-base font-medium tracking-wide px-6'>Criar conta</Button>
                </div>
            </div>
        </header>
    )
}
