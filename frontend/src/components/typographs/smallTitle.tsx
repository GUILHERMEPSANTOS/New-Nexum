import React, { PropsWithChildren } from 'react'

export default function SmallTitle({ children }: PropsWithChildren) {
    return (
        <h1 className='font-bold text-xl tracking-wide md:text-2xl uppercase'>{children}</h1>
    )
}
