import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './app.css';
import { Home } from './features/home/home';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home/>}>
                </Route>
            </Routes>
        </Router>
  );
}

export default App;
