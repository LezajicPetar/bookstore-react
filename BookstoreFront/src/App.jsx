import { Route, Routes, BrowserRouter } from "react-router-dom";
import Header from "./components/Header";
import Footer from "./components/Footer";
import Home from "./components/Home";
import Publishers from "./components/Publishers";
import Books from "./components/Books";
import React from "react";

const App = () => {
  return (
    <BrowserRouter>

      <Routes>
        <Route path="/" element={<Header />} >
          <Route path="/publishers" element={<Publishers />} />
          <Route path="/books" element={<Books />} />
          <Route path="/books/createBook" element={<div>Create book</div>} />
          <Route path="/home" element={<Home />} />
        </Route>
      </Routes>

      <Footer />

    </BrowserRouter>
  )
}

export default App;