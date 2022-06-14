export interface IBook {
    bookId: number;
    title: string;
    description?: string;
    author: string;
    isReturned: boolean;
    bookImage?: string;
    createdAt: string;
}

export type BookContextType = {
    books: IBook[];
    uniqueBooks: IBook[];
    book: IBook;
    addBook: (book: IBook) => void;
    updateBook?: (bookId: number) => void;
    removeBook: (id: number) => void;
    getBookById: (id: number) => void;
};