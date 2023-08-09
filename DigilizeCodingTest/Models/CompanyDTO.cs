using DigilizeCodingTest.Data.Models;

namespace DigilizeCodingTest.Model;

public class CompanyDTO : EntityBase
{
    public string CompanyName { get; set; }

    public string Address { get; set; }

    public static implicit operator CompanyDTO(Company company) {
        return new CompanyDTO
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            Address = company.Address
        };
    }

    public static implicit operator Company(CompanyDTO company)
    {
        return new Company
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            Address = company.Address
        };
    }
}
