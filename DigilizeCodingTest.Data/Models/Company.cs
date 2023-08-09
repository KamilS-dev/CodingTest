using DigilizeCodingTest.Data.Audit;

namespace DigilizeCodingTest.Data.Models;

public class Company : EntityBase, IAuditable
{
    public string CompanyName { get; set; }

    public string Address { get; set; }

    public Guid AuditKey => Id;
}
