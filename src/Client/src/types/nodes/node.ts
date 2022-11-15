import AuditableEntity from '../auditable-entity';
import NodeCustomField from './node-custom-field';
import NodeLink from './node-link';
import NodeReaction from './node-reaction';
import NodeTag from './node-tag';
import NodeVote from './node-vote';

export interface Node extends AuditableEntity {
    module: string;
    type: string;
    title: string;
    content: string;
    slug: string;
    status: string;
    customFields: NodeCustomField[];
    links: NodeLink[];
    reactions: NodeReaction[];
    tags: NodeTag[];
    votes: NodeVote[];
}

export const emptyNode = (): Node => {
    return {
        createdBy: '',
        createdOn: new Date(),
        lastModifiedBy: '',
        lastModifiedOn: new Date(),
        module: '',
        type: '',
        title: '',
        content: '',
        slug: '',
        status: '',
        customFields: [],
        links: [],
        reactions: [],
        tags: [],
        votes: []
    }
}