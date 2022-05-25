export default interface AuditableEntity {
    createdBy: string;
    createdOn: Date;
    lastModifiedBy: string;
    lastModifiedOn: Date;
}