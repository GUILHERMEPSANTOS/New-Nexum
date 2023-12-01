import React, { PropsWithChildren } from 'react'

export default function Title({ children }: PropsWithChildren) {
    return (
        <h1 className='font-bold text-2xl -tracking-tighter mb-10 md:text-4xl'>{children}</h1>
    )
}
