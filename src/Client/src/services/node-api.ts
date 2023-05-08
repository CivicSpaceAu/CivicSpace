import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Node } from '../types/nodes/node';

var baseUrl = 'http://localhost:5000/api';

export const nodeApi = createApi({
    reducerPath: 'nodeApi',
    baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
    endpoints: (builder) => ({
        getNode: builder.query<Node, string>({
            query: (id) => `/nodes/${id}`,
        }), 
        createNode: builder.mutation({
            query: (createNodeRequest) => ({
                url: '/nodes',
                method: 'POST',
                headers: {
                    'token': createNodeRequest.token
                },
                body: createNodeRequest.node
                })
        }),
    }),
});

export const {
    useGetNodeQuery,
    useCreateNodeMutation
} = nodeApi;