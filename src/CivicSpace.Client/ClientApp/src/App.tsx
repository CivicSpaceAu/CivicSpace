import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { MsalProvider, useMsal } from "@azure/msal-react";
import './app.css';
import Container from 'react-bootstrap/Container';
import { PageLayout } from './components/page-layout';
import Home from './features/home/home';
import ViewProfile from './features/profiles/components/view-profile';
import EditProfile from './features/profiles/components/edit-profile';
import Page from './features/pages/page';
import AddPage from './features/pages/add-page';
import EditPage from './features/pages/edit-page';
import Blog from './features/blogs/blog';
import AddBlog from './features/blogs/add-blog';
import EditBlog from './features/blogs/edit-blog';
import Forum from './features/forums/forum';
import AddForum from './features/forums/add-forum';
import EditForum from './features/forums/edit-forum';

export default function App(msalInstance: any) {
    return (
        <PageLayout>
            <Container>
                <main role="main" className="pb-3">
                    <BrowserRouter>
                        <Routes>
                            {/*<Route path="/" element={<Home />} />*/}
                            <Route path="/" element={<EditProfile />} />
                            <Route path="/:profileslug" element={<ViewProfile />} />
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
                </main>
            </Container>
        </PageLayout>
  );
}
