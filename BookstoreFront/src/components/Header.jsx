import React from "react";
import { Link, Outlet } from "react-router-dom";

const Header = () => {
    return (
        <header>
            <nav>
                <Link to="/publishers">Publishers</Link>
                <Link to="/books">Books</Link>
                <Link to="/books/createBook">Create book</Link>
                <Link to="/home">Home</Link>
            </nav>
            <Outlet />
        </header>
    )
}

export default Header;