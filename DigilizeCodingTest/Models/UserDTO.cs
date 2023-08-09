using DigilizeCodingTest.Data.Models;

namespace DigilizeCodingTest.Model;

public class UserDTO : EntityBase
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public static implicit operator UserDTO(User company)
    {
        return new UserDTO
        {
            Id = company.Id,
            Name = company.Name,
            Surname = company.Surname
        };
    }

    public static implicit operator User(UserDTO company)
    {
        return new User
        {
            Id = company.Id,
            Name = company.Name,
            Surname = company.Surname
        };
    }
}
