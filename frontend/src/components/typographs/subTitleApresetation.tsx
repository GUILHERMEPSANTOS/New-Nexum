import React, { PropsWithChildren } from 'react'

export default function SubTitleApresetation({ children }: PropsWithChildren) {
    return (
        <p className='font-light text-2xl md:text-3xl'>{children}</p>
    )
}
