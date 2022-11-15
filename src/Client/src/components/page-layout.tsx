import Navbar from 'react-bootstrap/Navbar';
import { useIsAuthenticated } from '@azure/msal-react';
import { SignInButton } from './sign-in-button';

/**
 * Renders the navbar component with a sign-in button if a user is not authenticated
 */
export const PageLayout = (props: any) => {
    const isAuthenticated = useIsAuthenticated();

    return (
        <>
            <Navbar bg="primary" variant="dark">
                <a className="navbar-brand" href="/">CivicSpace</a>
                {isAuthenticated ? <span>Signed In</span> : <SignInButton />}
            </Navbar>
            <br />
            <br />
            {props.children}
        </>
    );
};