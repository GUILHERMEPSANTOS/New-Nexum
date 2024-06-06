import SmallTitle from '@/components/typographs/smallTitle'
import TitleApresetation from '@/components/typographs/titleApresetation'
import { Button } from '@/components/ui/button'
import { Checkbox } from '@/components/ui/checkbox'
import { Input } from '@/components/ui/input'
import { Label } from '@/components/ui/label'
import React from 'react'
import FormLogin from './components/formLogin'

export default function Login() {
    return (
        <main className='h-screen w-full flex flex-col items-center justify-center px-4'>
            <TitleApresetation><span className='text-purple-800'>Seja Bem-Vindo</span> </TitleApresetation>
            <FormLogin />
        </main>
    )
}
