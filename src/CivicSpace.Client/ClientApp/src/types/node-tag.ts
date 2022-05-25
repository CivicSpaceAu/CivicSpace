import AuditableEntity from "./auditable-entity";

export default interface NodeTag extends AuditableEntity {
    tag: string;
}