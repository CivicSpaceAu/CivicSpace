import { useMsal } from '@azure/msal-react';
import { loginRequest } from '../auth-config';
import Button from 'react-bootstrap/Button';

function handleLogin(instance: any) {
    instance.loginRedirect(loginRequest).catch((e: any) => {
        console.error(e);
    });
}

export const SignInButton = () => {
    const { instance } = useMsal();

    return (
        <Button variant="secondary" className="ml-auto" onClick={() => handleLogin(instance)}>Sign in</Button>
    );
}