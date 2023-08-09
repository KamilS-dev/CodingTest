using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DigilizeCodingTest.Data.Audit;

public static class ApplicationDbContextAuditExtensions
{
    public static List<AuditRecord> GetAudits(this ApplicationDbContext dbContext)
    {
        var audits = new List<AuditRecord>();
        var changes = dbContext.ChangeTracker.Entries()
            .Where(x =>
                x.State == EntityState.Modified ||
                x.State == EntityState.Added ||
                x.State == EntityState.Deleted)
            .ToArray();

        foreach (var entry in changes)
        {
            if (!entry.RequiresAudit())
            {
                continue;
            }

            var audit = new AuditRecord
            {
                Table = entry.Entity.GetType().Name,
                OldValue = GetOldValue(entry.State, entry.Properties),
                NewValue = GetNewValue(entry.State, entry.Properties),
                AuditType = GetAuditType(entry.State),
                SourceKey = GetPrimaryKey(entry),
                EntityEntry = entry
            };

            audits.Add(audit);
        }

        return audits;
    }

    private static bool RequiresAudit(this EntityEntry entityEntry)
    {
        return entityEntry.Entity is IAuditable auditableObject;
    }

    private static Dictionary<string, object> GetOldValue(EntityState entityState, IEnumerable<PropertyEntry> properties)
    {
        if (entityState == EntityState.Modified || entityState == EntityState.Deleted)
        {
            return properties.ToDictionary(p => p.Metadata.Name, p => p.OriginalValue);
        }
        return null;
    }

    private static Dictionary<string, object> GetNewValue(EntityState entityState, IEnumerable<PropertyEntry> properties)
    {
        if (entityState == EntityState.Added || entityState == EntityState.Modified)
        {
            return properties.ToDictionary(p => p.Metadata.Name, p => p.CurrentValue);
        }
        return null;
    }

    private static Guid? GetPrimaryKey(EntityEntry entityEntry)
    {
        Guid? sourceKey = null;
        if (entityEntry.Entity is IAuditable auditableObject)
        {
            sourceKey = auditableObject.AuditKey;
        }

        return sourceKey;
    }

    private static AuditType GetAuditType(EntityState entryState)
    {
        switch (entryState)
        {
            case EntityState.Added:
                return AuditType.Create;
            case EntityState.Deleted:
                return AuditType.Delete;
            case EntityState.Modified:
                return AuditType.Update;
            default:
                return AuditType.Unknown;
        }
    }
}