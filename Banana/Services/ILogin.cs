using Microsoft.EntityFrameworkCore;

namespace Banana.Services;

public interface ILogin
{
    public Task<bool>  UserLogin(string name ,string password);

    public Task<bool> Register(string name ,string password);
}