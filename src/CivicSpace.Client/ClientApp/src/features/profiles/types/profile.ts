import { Node, emptyNode } from "../../../types/node";

export interface Profile {
    name: string;
    slug: string;
    description: string;
}

export const emptyProfile = (): Profile => ({
    name: '',
    slug: '',
    description: ''
});

export function nodeToProfile(node: Node): Profile {
    return {
        name: node.title,
        slug: node.slug,
        description: node.content
    }
}

export function profileToNode(profile: Profile): Node {
    var node = emptyNode();
    node.module = 'profile';
    node.type = 'profile';
    node.title = profile.name;
    node.content = profile.description;
    node.slug = profile.slug;
    return node;
}