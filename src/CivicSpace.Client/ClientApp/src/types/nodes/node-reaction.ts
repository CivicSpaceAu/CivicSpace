import AuditableEntity from '../auditable-entity';

export default interface NodeReaction extends AuditableEntity {
    type: string;
}