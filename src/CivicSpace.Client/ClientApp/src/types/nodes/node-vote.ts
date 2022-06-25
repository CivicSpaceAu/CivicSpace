import AuditableEntity from '../auditable-entity';

export default interface NodeVote extends AuditableEntity {
    score: number;
}