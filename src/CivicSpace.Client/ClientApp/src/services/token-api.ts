import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { TokenRequest } from '../types/tokens/token-request';
import { TokenResponse } from '../types/tokens/token-response';

var baseUrl = 'http://localhost:5000/api';

export const tokenApi = createApi({
    reducerPath: 'tokenApi',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    endpoints: (builder) => ({
        getToken: builder.query<TokenResponse, TokenRequest>({
            query: (token) => ({
                url: '/tokens',
                method: 'POST',
                body: token
            })
        }),
    }),
});

export const {
    useGetTokenQuery
} = tokenApi;