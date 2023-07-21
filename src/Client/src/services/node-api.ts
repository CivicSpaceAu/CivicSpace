import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Node } from '../types/nodes/node';

var baseUrl = 'http://localhost:5000/api';

export const api = createApi({
    reducerPath: 'nodeApi',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    endpoints: (builder) => ({
        graphqlQuery: builder.query({
            query: (variables) => ({
                document: graphql``
            })
        }), 
    }),
});

export const {
    useGetNodeQuery,
    useCreateNodeMutation
} = api;