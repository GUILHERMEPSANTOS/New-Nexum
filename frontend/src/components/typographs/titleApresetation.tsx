import React, { PropsWithChildren } from 'react'

export default function TitleApresetation({ children }: PropsWithChildren) {
    return (
        <h1 className='font-bold text-4xl md:text-6xl'>{children}</h1>
    )
}
