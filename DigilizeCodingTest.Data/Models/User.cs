using DigilizeCodingTest.Data.Audit;

namespace DigilizeCodingTest.Data.Models;

public class User : EntityBase, IAuditable
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public Guid AuditKey => Id;
}
