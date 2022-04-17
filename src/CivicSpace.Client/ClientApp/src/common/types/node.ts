export interface Node {
    module: string;
    type: string;
    title: string;
    content: string;
    slug: string;
    status: string;
    tags: string[];
    weight: number;
    childCount: number;
    descendantCount: number;
    upVotes: number;
    downVotes: number;
}