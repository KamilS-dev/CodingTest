using DigilizeCodingTest.Data.Models;

namespace DigilizeCodingTest.BusinessLogic.Services.Interface;

public interface IUserService
{
    User Get(Guid userId);

    IEnumerable<User> GetFilteredUsers();

    void Create(User userModel);

    void Update(User userModel);

    void Delete(Guid userId);
}