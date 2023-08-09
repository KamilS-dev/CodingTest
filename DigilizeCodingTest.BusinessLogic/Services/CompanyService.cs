using DigilizeCodingTest.BusinessLogic.Services.Interface;
using DigilizeCodingTest.Data;
using DigilizeCodingTest.Data.Models;
using DigilizeCodingTest.Data.Validators;

namespace DigilizeCodingTest.BusinessLogic.Services;

public class CompanyService : ICompanyService
{
    private readonly ApplicationDbContext context;

    public CompanyService(
        ApplicationDbContext context)
    {
        this.context = context;
    }

    public Company Get(Guid companyId)
    {
        return context.Companies.Find(companyId);
    }

    public IEnumerable<Company> GetFilteredCompanies()
    {
        return context.Companies.ValidateAndFilter();
    }

    public void Create(Company companyModel)
    {
        context.Companies.Add(companyModel);
        context.SaveChanges();
    }

    public void Update(Company companyModel)
    {
        context.Companies.Update(companyModel);
        context.SaveChanges();
    }

    public void Delete(Guid companyId)
    {
        var user = context.Companies.Find(companyId);

        if (user != null)
        {
            context.Remove(user);
            context.SaveChanges();
        }
    }
}