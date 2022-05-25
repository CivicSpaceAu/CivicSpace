import AuditableEntity from "./auditable-entity";

export default interface NodeCustomField extends AuditableEntity {
    key: string;
    value: string;
}