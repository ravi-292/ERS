import Book from '../components/Book';
import {useContext} from 'react';
import {BookContext} from '../Context';
import {BookContextType, IBook} from '../types';
import StickyBar from '../components/StickyBar';

const Landing = () => {
    const {uniqueBooks} = useContext(BookContext) as BookContextType;

    const scrollToTop = () => {
        const container = document.getElementById('#container');
        container?.scrollIntoView({
            behavior: 'smooth',
        });
    };

    return (
        <>
            <StickyBar/>

            <div
                className='container relative mx-auto mt-20 h-[85vh] max-w-6xl overflow-auto px-14 scrollbar-thin scrollbar-track-slate-50 scrollbar-thumb-slate-200'>
                <div
                    id='#container'
                    className='grid gap-4 md:grid-cols-2 lg:grid-cols-3'
                >
                    {uniqueBooks.map((book: IBook) => (
                        <Book key={book.bookId} {...book} />
                    ))}
                </div>
                <button
                    onClick={scrollToTop}
                    className='sticky bottom-0 float-right mt-4 rounded-md bg-indigo-600 px-3 py-2 text-white shadow-md'
                >
                    To Top
                </button>
            </div>
        </>
    );
};

export default Landing;
