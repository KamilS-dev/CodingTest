namespace DigilizeCodingTest.Data.Audit;

public interface IAuditable
{
    Guid AuditKey { get; }
}