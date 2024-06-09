namespace PatternPioneer.Services;

public interface IUserService
{
    (string FirstName, string LastName) GetById(int Id);
}

public class UserService : IUserService
{
    public (string FirstName, string LastName) GetById(int Id)
    {
        return ("John", "Doe");
    }
}
