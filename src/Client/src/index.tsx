import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { PublicClientApplication } from '@azure/msal-browser';
import { Provider } from 'react-redux';
import { MsalProvider } from '@azure/msal-react';
import { msalConfig } from './auth-config';
import App from './app';
import { store } from './app/store';
import * as serviceWorker from './service-worker';

const msalInstance = new PublicClientApplication(msalConfig);

ReactDOM.render(
    <React.StrictMode>
        <Provider store={store}>
            <MsalProvider instance={msalInstance}>
                <App />
            </MsalProvider>
        </Provider>
    </React.StrictMode>,
    document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
