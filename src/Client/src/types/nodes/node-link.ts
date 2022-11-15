import AuditableEntity from '../auditable-entity';

export default interface NodeLink extends AuditableEntity {
    linkedNodeId: string;
    type: string;
    weight: number;
}