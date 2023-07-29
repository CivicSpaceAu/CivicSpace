import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './app';

import { PublicClientApplication } from '@azure/msal-browser';
import { Provider } from 'react-redux';
import { MsalProvider } from '@azure/msal-react';
import { msalConfig } from './auth-config';
import { store } from './app/store';
import { ApolloClient, InMemoryCache, ApolloProvider } from '@apollo/client';
// import * as serviceWorker from './service-worker';

const apolloClient = new ApolloClient({
    uri: 'http://localhost:5101/',
    cache: new InMemoryCache(),
});

const msalInstance = new PublicClientApplication(msalConfig);

ReactDOM.render(
    <React.StrictMode>
        <Provider store = {store}>
            <ApolloProvider client={apolloClient}>
                <MsalProvider instance={msalInstance}>
                    <App />
                </MsalProvider>
            </ApolloProvider>
        </Provider>
    </React.StrictMode>,
    document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
// serviceWorker.unregister();
