import {useEffect, useState} from 'react';
import {BookContext} from './Context';
import Landing from './pages/Landing';
import {IBook} from './types';
import {Route, Routes} from 'react-router-dom';
import BookDetail from './pages/BookDetail';
import NotFound404 from './pages/NotFound404';

const App = () => {
        let [books, setBooks] = useState<IBook[]>([]);
        let [uniqueBooks, setUniqueBooks] = useState<IBook[]>([]);
        let [book, setBook] = useState<IBook>({
            author: "",
            bookId: 0,
            bookImage: "",
            description: "",
            isReturned: false,
            title: ""
        });

        // Standard variation
        function api<T>(url: string, method: string, body?: IBook | undefined): Promise<T> {
            return fetch(url, {
                headers: {
                    'Content-Type': 'application/json'
                },
                method,
                body: JSON.stringify(body)
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error(response.statusText)
                    }
                    return response.json() as Promise<T>
                })
        }

        const getUnique = (books: IBook[]) => [...new Map(books.map(book => [book["bookId"], book])).values()];

        useEffect(() => {
            api<IBook[]>('https://localhost:7133/api/Book', "GET")
                .then((data: IBook[]) => {
                    setBooks(data)
                    setUniqueBooks(getUnique(data))
                })
                .catch(error => {
                    /* show error message */
                    console.log(error)
                })
        }, []);


        const addBook = (book: IBook) => {
            api<IBook[]>('https://localhost:7133/api/Book/', "POST", book)
                .then((data: IBook[]) => {
                    setBooks(data);
                    setUniqueBooks(getUnique(data))
                })
                .catch(error => {
                    /* show error message */
                    console.log(error)
                })
        };

        const getBookById = (bookId: number) => {
            api<IBook>(`https://localhost:7133/api/Book/${bookId}`, "GET")
                .then((data: IBook) => {
                    setBook(data)
                })
                .catch(error => {
                    /* show error message */
                    console.log(error)
                })
        }

        const removeBook = (bookId: number) => {
            api<IBook[]>(`https://localhost:7133/api/Book/${bookId}`, "DELETE")
                .then((data: IBook[]) => {
                    setBooks(data)
                    setUniqueBooks(getUnique(data))
                })
                .catch(error => {
                    /* show error message */
                    console.log(error)
                })
        };

        return (
            <BookContext.Provider
                value={{books, book, uniqueBooks, addBook, removeBook, getBookById}}
            >
                <Routes>
                    <Route path='/' element={<Landing/>}/>
                    <Route path='/details/:bookId' element={<BookDetail/>}/>
                    <Route path='*' element={<NotFound404/>}/>
                </Routes>
            </BookContext.Provider>
        );
    }
;

export default App;
