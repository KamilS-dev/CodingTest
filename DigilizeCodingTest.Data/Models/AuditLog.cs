using System.ComponentModel.DataAnnotations;

namespace DigilizeCodingTest.Data.Models;

public class AuditLog
{
    [Key]
    public int Key { get; set; }

    public Guid SourceKey { get; set; }

    public string TableName { get; set; }

    public DateTime DateTime { get; set; }

    public string OldValue { get; set; }

    public string NewValue { get; set; }
}