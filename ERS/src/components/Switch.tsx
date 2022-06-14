import {useContext, useEffect, useState} from 'react';
import {Switch} from '@headlessui/react';
import {BookContext} from "../Context";
import {BookContextType, IBook} from "../types";

const Toggle = ({bookId, title, author, description, bookImage, isReturned}: IBook) => {

    let [enabled, setEnabled] = useState(isReturned);

    const {addBook} = useContext(BookContext) as BookContextType;
    const addToggleBook = () => {
        setEnabled(!enabled)
        const book = {bookId, title, author, description, bookImage, isReturned: enabled}

        addBook(book)
    }

    return (
        <Switch.Group>
            <div className='flex items-center gap-3'>
                <Switch
                    checked={enabled}
                    onChange={addToggleBook}
                    className={`${
                        enabled ? 'bg-blue-600' : 'bg-gray-200'
                    } relative inline-flex h-6 w-11 items-center rounded-full transition-colors focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2`}
                >
                    <span
                        className={`${
                            enabled ? 'translate-x-6' : 'translate-x-1'
                        } inline-block h-4 w-4 transform rounded-full bg-white transition-transform`}
                    />
                </Switch>
                <Switch.Label className='mr-4 text-sm text-slate-500'>
                    {enabled ? 'Borrowed' : 'Returned'}
                </Switch.Label>
            </div>
        </Switch.Group>
    );
}


export default Toggle