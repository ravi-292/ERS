import React, {useState} from 'react';
import Dialog from './Dialog';

const StickyBar = () => {
    let [isOpen, setIsOpen] = useState<boolean>(false);
    return (
        <>
            {isOpen && <Dialog setIsOpen={setIsOpen}/>}
            <div
                className={`${
                    !isOpen && 'sticky top-10'
                }  z-50 mx-auto mb-12 flex items-center justify-between px-8 lg:w-[80%]`}
            >
                <img
                    src='https://www.therockportgroup.com/hubfs/rockport-logo.svg'
                    alt='logo'
                    className='w-32 lg:w-40'
                />
                <h3 className='hidden text-3xl font-bold lg:block'>
                    Electronic Rental System (ERS)
                </h3>

                <h3 className='block text-3xl font-bold lg:hidden'>ERS</h3>

                <button
                    onClick={() => setIsOpen(true)}
                    className='rounded-md bg-indigo-500 px-2 py-1 text-sm text-white lg:text-lg'
                >
                    Add Book
                </button>
            </div>
        </>
    );
};

export default StickyBar;
