import { Button } from '@/components/ui/button'
import { Checkbox } from '@/components/ui/checkbox'
import { Input } from '@/components/ui/input'
import { Label } from '@/components/ui/label'
import React from 'react'

export default function FormLogin() {
    return (
        <div className='space-y-6 w-full mt-8'>
            <div>
                <Label htmlFor="usuario">Usuário</Label>
                <Input id='usuario' placeholder='Usuario' />
            </div>
            <div>
                <Label htmlFor="senha">Senha</Label>
                <Input id='senha' placeholder='Senha' />
            </div>
            <div className='flex justify-between'>
                <div className='space-x-4 flex items-center'>
                    <Checkbox id='lembra_conta' />
                    <label htmlFor='lembra_conta'>Lembrar conta</label>
                </div>
                <a href="">Esqueci a senha</a>
            </div>
            <div className='space-y-4 flex-col flex'>
                <Button>Descubra mais sobre nós</Button>
                <Button className='border-violet-700 bg-[#101010] text-base font-medium tracking-wide md:p-6' variant="outline">Conta Contratante</Button>
            </div>
        </div>

    )
}
