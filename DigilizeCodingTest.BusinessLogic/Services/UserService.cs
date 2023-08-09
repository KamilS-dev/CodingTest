using DigilizeCodingTest.BusinessLogic.Services.Interface;
using DigilizeCodingTest.Data;
using DigilizeCodingTest.Data.Models;
using DigilizeCodingTest.Data.Validators;

namespace DigilizeCodingTest.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext context;

    public UserService(
        ApplicationDbContext context)
    {
        this.context = context;
    }

    public User Get(Guid userId)
    {
        return context.Users.Find(userId);
    }

    public IEnumerable<User> GetFilteredUsers() 
    {
        return context.Users.ValidateAndFilter();
    }

    public void Create(User userModel)
    {
        context.Users.Add(userModel);
        context.SaveChanges();
    }

    public void Update(User userModel)
    {
        context.Users.Update(userModel);
        context.SaveChanges();
    }

    public void Delete(Guid userId)
    {
        var user = context.Users.Find(userId);

        if (user != null)
        {
            context.Remove(user);
            context.SaveChanges();
        }
    }
}
