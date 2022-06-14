import React from 'react';
import {BookContextType} from './types';

export const BookContext = React.createContext<BookContextType>({
    books: [],
    addBook: () => {},
    toggleBorrowedReturned: () => {},
    updateBook: () => {},
    removeBook: () => {},
});
