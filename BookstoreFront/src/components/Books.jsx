import React from "react";
import { getAllBooks, deleteBook } from '../service/booksService';
import { useEffect, useState } from 'react';

const Books = () => {
    const [books, setBooks] = useState([]);

    useEffect(() => {
        const fetchBooks = async () => {
            try {
                const data = await getAllBooks();
                setBooks(data);
            }
            catch (error) {
                console.error("Error fetching books:", error);
                alert("This leaf is missing from the branch. \nWe couldn’t fetch the books right now.");
            }
        }
        fetchBooks();
    }, [])

    const handleDelete =  async (id) => {
        try {
            await deleteBook();
            setBooks((prev) => prev.map(book => book.id !== id));
            alert("The season turns, a leaf falls — your library feels lighter.")
        }
        catch (error) {
            console.error("Error fatching")
            alert("")
        }
    }

}

return (
    <div>
        <table>
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Published</th>
                    <th>Pages</th>
                    <th>Publisher</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {books.map((book) => (
                    <tr key={book.id}>
                        <td>{book.title}</td>
                        <td>{book.author.fullName}</td>
                        <td>{book.publishedDate}</td>
                        <td>{book.pageCount}</td>
                        <td>{book.publisher.name}</td>
                        <td><button>UPDATE</button></td>
                        <td><button>DELETE</button></td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
);


export default Books;