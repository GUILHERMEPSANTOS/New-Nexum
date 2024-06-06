import React from 'react'
import { CheckCircleIcon, MapPinIcon } from 'lucide-react'

interface CardApresentationProps {
    name: string
    location: string
    profession: string
}

export default function CardApresentation({ name, location, profession }: CardApresentationProps) {
    return (
        <div className=' bg-[#d6d6d654] w-full rounded-sm p-2 h-[68px] '>
            <div className='flex justify-between items-center mb-1'>
                <p className='text-xs font-bold'>{name}</p>
                <CheckCircleIcon color='#A9F330' size="14" />
            </div>
            <div className='flex justify-start items-center gap-2 mb-1'>
                <MapPinIcon color='#FE0E64' size="14" />
                <p className='text-xs'>{location}</p>
            </div>
            <div>
                <p className='text-xs'>{profession}</p>
            </div>
        </div>
    )
}
