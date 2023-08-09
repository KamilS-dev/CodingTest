using DigilizeCodingTest.Data.Audit;
using DigilizeCodingTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DigilizeCodingTest.Data;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=(local);Database=DigilizeCodingTest;Integrated Security=true;TrustServerCertificate=True;");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        this.OnBeforeSaveChanges();
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    public override int SaveChanges()
    {
        this.OnBeforeSaveChanges();
        var result = base.SaveChanges();

        return result;
    }

    private void OnBeforeSaveChanges()
    {
        var audits = this.GetAudits();

        // TODO
        // save audit logs in AuditLog table
    }
}