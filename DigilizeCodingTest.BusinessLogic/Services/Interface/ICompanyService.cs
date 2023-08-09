using DigilizeCodingTest.Data.Models;

namespace DigilizeCodingTest.BusinessLogic.Services.Interface;

public interface ICompanyService
{
    Company Get(Guid companyId);

    IEnumerable<Company> GetFilteredCompanies();

    void Create(Company companyModel);

    void Update(Company companyModel);

    void Delete(Guid companyId);
}