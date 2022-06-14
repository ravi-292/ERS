import {Dispatch, FormEvent, SetStateAction, useContext, useState,} from 'react';
import {v4 as uuidv4} from 'uuid';
import {BookContext} from '../Context';
import {BookContextType, IBook} from '../types';

interface IProps {
    isOpen?: boolean;
    setIsOpen: Dispatch<SetStateAction<boolean>>;
}

const Dialog = ({setIsOpen}: IProps) => {
    let [title, setTitle] = useState('');
    let [author, setAuthor] = useState('');
    let [description, setDescription] = useState('');

    let {addBook} = useContext(BookContext) as BookContextType;

    const handleSubmit = (event: FormEvent): void => {
        event.preventDefault();

        const newBook: IBook = {
            bookId: Math.floor(Math.random() * 100),
            title,
            author,
            description,
            bookImage:
                'https://s26162.pcdn.co/wp-content/uploads/2020/01/Sin-Eater-by-Megan-Campisi-677x1024.jpg',
            isReturned: false,
        };

        addBook!(newBook);

        setIsOpen(false);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div
                className='fixed top-0 right-0 bottom-0 left-0 z-10 bg-gray-700 py-12 transition duration-150 ease-in-out'
                id='modal'
            >
                <div
                    role='alert'
                    className='container mx-auto w-11/12 max-w-lg md:w-2/3'
                >
                    <div className='relative rounded border border-gray-400 bg-white py-8 px-5 shadow-md md:px-10'>
                        <div className='mb-3 flex w-full justify-start text-gray-600'>
                            <svg
                                xmlns='http://www.w3.org/2000/svg'
                                className='icon icon-tabler icon-tabler-wallet'
                                width='52'
                                height='52'
                                viewBox='0 0 24 24'
                                strokeWidth='1'
                                stroke='currentColor'
                                fill='none'
                                strokeLinecap='round'
                                strokeLinejoin='round'
                            >
                                <path stroke='none' d='M0 0h24v24H0z'/>
                                <path
                                    d='M17 8v-3a1 1 0 0 0 -1 -1h-10a2 2 0 0 0 0 4h12a1 1 0 0 1 1 1v3m0 4v3a1 1 0 0 1 -1 1h-12a2 2 0 0 1 -2 -2v-12'/>
                                <path d='M20 12v4h-4a2 2 0 0 1 0 -4h4'/>
                            </svg>
                        </div>
                        <h1 className='font-lg mb-4 font-bold leading-tight tracking-normal text-gray-800'>
                            Enter Book Details
                        </h1>
                        <label className='block'>
                            <span
                                className="block text-sm font-medium text-slate-700 after:ml-0.5 after:text-red-500 after:content-['*']">
                                Book Title
                            </span>
                            <input
                                type='text'
                                name='title'
                                required
                                className='peer mt-1 block w-full rounded-md border border-slate-300 bg-white px-3 py-2 placeholder-slate-400 shadow-sm focus:border-sky-500 focus:outline-none focus:ring-1 focus:ring-sky-500 sm:text-sm'
                                placeholder='eg. Kafka on the Shore'
                                onChange={evt => setTitle(evt.target.value)}
                            />
                            <p className='invisible mt-2 text-sm text-pink-600 peer-invalid:visible'>
                                Book Title is required field.
                            </p>
                        </label>
                        <label className='my-5 block'>
                            <span
                                className="block text-sm font-medium text-slate-700 after:ml-0.5 after:text-red-500 after:content-['*']">
                                Author
                            </span>
                            <input
                                type='text'
                                name='author'
                                required
                                className='peer mt-1 block w-full rounded-md border border-slate-300 bg-white px-3 py-2 placeholder-slate-400 shadow-sm focus:border-sky-500 focus:outline-none focus:ring-1 focus:ring-sky-500 sm:text-sm'
                                placeholder='eg. Haruki Murakami'
                                onChange={evt => setAuthor(evt.target.value)}
                            />
                            <p className='invisible mt-2 text-sm text-pink-600 peer-invalid:visible'>
                                Author is required field.
                            </p>
                        </label>

                        <label className='my-5 block'>
                            <span className='block text-sm font-medium text-slate-700'>
                                Description
                            </span>
                            <input
                                type='text'
                                name='description'
                                className='mt-1 block w-full rounded-md border border-slate-300 bg-white px-3 py-2 placeholder-slate-400 shadow-sm focus:border-sky-500 focus:outline-none focus:ring-1 focus:ring-sky-500 sm:text-sm'
                                placeholder='eg. Kafka on the Shore is a 2002 novel by Japanese author Haruki Murakami.'
                                onChange={evt =>
                                    setDescription(evt.target.value)
                                }
                            />
                        </label>

                        <div className='flex w-full items-center justify-start'>
                            <button
                                className='rounded bg-indigo-700 px-8 py-2 text-sm text-white transition duration-150 ease-in-out hover:bg-indigo-600 focus:outline-none focus:ring-2 focus:ring-indigo-700 focus:ring-offset-2'>
                                Submit
                            </button>
                            <button
                                className='ml-3 rounded border  bg-gray-100 px-8 py-2 text-sm text-gray-600 transition duration-150 ease-in-out hover:border-gray-400 hover:bg-gray-300 focus:outline-none focus:ring-2 focus:ring-gray-400 focus:ring-offset-2'
                                onClick={() => setIsOpen(false)}
                            >
                                Cancel
                            </button>
                        </div>
                        <button
                            className='absolute top-0 right-0 mt-4 mr-5 cursor-pointer rounded text-gray-400 transition duration-150 ease-in-out hover:text-gray-600 focus:outline-none focus:ring-2 focus:ring-gray-600'
                            aria-label='close modal'
                            role='button'
                            onClick={() => setIsOpen(false)}
                        >
                            <svg
                                xmlns='http://www.w3.org/2000/svg'
                                className='icon icon-tabler icon-tabler-x'
                                width='20'
                                height='20'
                                viewBox='0 0 24 24'
                                strokeWidth='2.5'
                                stroke='currentColor'
                                fill='none'
                                strokeLinecap='round'
                                strokeLinejoin='round'
                            >
                                <path stroke='none' d='M0 0h24v24H0z'/>
                                <line x1='18' y1='6' x2='6' y2='18'/>
                                <line x1='6' y1='6' x2='18' y2='18'/>
                            </svg>
                        </button>
                    </div>
                </div>
            </div>
        </form>
    );
};

export default Dialog;
