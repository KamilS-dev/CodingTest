using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DigilizeCodingTest.Data.Audit;

public class AuditRecord
{
    public int? PrimaryKey { get; set; }

    public string Table { get; set; }

    public AuditType AuditType { get; set; }

    public Guid? SourceKey { get; set; }

    public EntityEntry EntityEntry { get; set; }

    public Dictionary<string, object> OldValue { get; set; }

    public Dictionary<string, object> NewValue { get; set; }
}
