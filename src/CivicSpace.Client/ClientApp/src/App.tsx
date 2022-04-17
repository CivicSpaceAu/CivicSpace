import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './app.css';
import Home from './features/home/home';
import Profile from './features/profiles/profile';
import EditProfile from './features/profiles/edit-profile';
import Page from './features/pages/page';
import AddPage from './features/pages/add-page';
import EditPage from './features/pages/edit-page';
import Blog from './features/blogs/blog';
import AddBlog from './features/blogs/add-blog';
import EditBlog from './features/blogs/edit-blog';
import Forum from './features/forums/forum';
import AddForum from './features/forums/add-forum';
import EditForum from './features/forums/edit-forum';

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/:profileslug" element={<Profile />} />
                <Route path="/:profileslug/edit" element={<EditProfile />} />
                <Route path="/:profileslug/page/add" element={<AddPage />} />
                <Route path="/:profileslug/page/:pageslug" element={<Page />} />
                <Route path="/:profileslug/page/:pageslug/edit" element={<EditPage />} />
                <Route path="/:profileslug/blog/add" element={<AddBlog />} />
                <Route path="/:profileslug/blog/:blogslug" element={<Blog />} />
                <Route path="/:profileslug/blog/:blogslug/edit" element={<EditBlog />} />
                <Route path="/:profileslug/forum/add" element={<AddForum />} />
                <Route path="/:profileslug/forum/:forumslug" element={<Forum />} />
                <Route path="/:profileslug/forum/:forumslug/edit" element={<EditForum />} />
            </Routes>
        </BrowserRouter>
  );
}

export default App;
