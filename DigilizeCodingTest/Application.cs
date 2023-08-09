using DigilizeCodingTest.BusinessLogic.Services.Interface;
using DigilizeCodingTest.Model;
using Microsoft.Extensions.Configuration;

namespace DigilizeCodingTest;

public class Application
{
    private readonly ICompanyService companyService;
    private readonly IUserService userService;

    public Application(ICompanyService companyService, IUserService userService)
    {
        this.companyService = companyService;
        this.userService = userService;
    }

    public void Run(string[] args)
    {
        var newUser = new UserDTO()
        {
            Id = Guid.NewGuid(),
            Name = "John",
            Surname = "Smith"
        };

        var newCompany = new CompanyDTO()
        {
            Id = Guid.NewGuid(),
            CompanyName = "CompanyName",
            Address = "London"
        };

        userService.Create(newUser);
        companyService.Create(newCompany);

        var filteredUsers = userService.GetFilteredUsers();
        var filteredCompanies = companyService.GetFilteredCompanies();

        var user = userService.Get(newUser.Id);

        user.Name = "Mike";
        userService.Update(user);

        userService.Delete(user.Id);
    }
}