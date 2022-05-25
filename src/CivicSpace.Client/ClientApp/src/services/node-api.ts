import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Node } from '../types/node';

var baseUrl = 'http://localhost:5000';

export const nodeApi = createApi({
    reducerPath: 'nodeApi',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    endpoints: (builder) => ({
        getNode: builder.query<Node, string>({
            query: (id) => `/nodes/${id}`,
        }), 
        createNode: builder.mutation({
            query: (node) => ({
                url: '/nodes',
                method: 'POST',
                body: node
                })
        }),
    }),
});

export const {
    useGetNodeQuery,
    useCreateNodeMutation
} = nodeApi;