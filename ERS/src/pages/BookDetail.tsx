import React, {useContext, useEffect} from 'react';
import {useNavigate, useParams} from 'react-router-dom';
import {BookContext} from '../Context';
import {BookContextType, IBook} from '../types';

const BookDetail = () => {
    const navigate = useNavigate();
    let {bookId} = useParams();
    let _bookId: number = Number.parseInt(bookId!)

    const {getBookById, book, removeBook, books} = useContext(BookContext) as BookContextType;

    const {title, author, description, isReturned, bookImage} = book

    useEffect(() =>
            getBookById(_bookId)
        , [_bookId]);


    const handleRemoveBook = () => {
        removeBook(_bookId);
        navigate('/');
    };

    const formatDate = (date: Date) => {
        return new Intl.DateTimeFormat('en-US', {
            weekday: 'short',
            year: 'numeric',
            month: 'short',
            day: 'numeric',
        }).format(date);
    };

    const borrowed: (string | number | boolean | React.ReactElement<any, string | React.JSXElementConstructor<any>> | React.ReactFragment | React.ReactPortal | null | undefined)[] = [],
        returned: (string | number | boolean | React.ReactElement<any, string | React.JSXElementConstructor<any>> | React.ReactFragment | React.ReactPortal | null | undefined)[] = []

    books.filter((book: IBook) => book.bookId === _bookId)
        .map((book: IBook) => book.isReturned ? returned.push(book.createdAt) : borrowed.push(book.createdAt))

    const size = Math.max(borrowed.length, returned.length)

    return (
        <div className='max-w-6x container mx-auto px-14 py-8 text-center'>
            <div className='flex justify-between'>
                <button
                    className='h-10 w-fit rounded-md bg-indigo-500 px-3 py-2 font-bold text-white'
                    onClick={() => navigate('/')}
                >
                    Back
                </button>
                <button
                    className='h-10 w-fit rounded-md bg-red-700 px-3 py-2 font-bold text-white'
                    onClick={handleRemoveBook}
                >
                    Delete
                </button>
            </div>
            <div className='mt-10 flex justify-center'>
                <img src={bookImage} alt={title} className='max-h-[500px]'/>
            </div>
            <h2 className='mt-6 mb-2 text-2xl font-bold'>{title}</h2>
            <p className='text-slate-600'>by {author}</p>
            <p className='text-slate-600'>
                {isReturned
                    ? 'Returned at ' + formatDate(new Date())
                    : 'Borrowed at ' + formatDate(new Date())}
            </p>

            <p className='mt-4 font-medium'>{description}</p>

            <table className="my-10 table-auto mx-auto">
                <thead >
                    <tr className="flex gap-10 justify-around">
                        <th className="uppercase">Borrow</th>
                        <th className="uppercase">Return</th>
                    </tr>
                </thead>
                <tbody>
                {
                    Array(size).fill(0).map((d, i) => (
                        <tr key={i} className="flex gap-10 text-center py-1">
                            <td>{borrowed[i]}</td>
                            <td>{returned[i]}</td>
                        </tr>
                    ))
                }
                </tbody>
            </table>
        </div>
    );
};

export default BookDetail;
