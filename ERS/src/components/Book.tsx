import Toggle from './Switch';
import {IBook} from '../types';
import {Link} from 'react-router-dom';

const Book = ({
                  bookId,
                  title,
                  author,
                  description,
                  bookImage,
                  isReturned,
              }: IBook) => {
    const book = {
        bookId,
        title,
        author,
        description,
        bookImage,
        isReturned,
    }
    // @ts-ignore
    // @ts-ignore
    return (
        <div
            className='flex h-52 min-w-fit gap-6 rounded-lg bg-white px-4 py-3'
            key={bookId}
        >
            <img
                src={bookImage}
                alt={description}
                className='rounded-md shadow-md'
            />
            <div className='flex flex-col justify-evenly'>
                <Link className='font-semibold' to={`/details/${bookId}`}>
                    {title}
                </Link>
                <p className='text-sm text-slate-600'>{author}</p>
                <Toggle {...book}/>
            </div>
        </div>
    );
};

export default Book;
