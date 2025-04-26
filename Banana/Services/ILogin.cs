using Microsoft.EntityFrameworkCore;

namespace Banana.Services;

public interface ILogin
{
    public Task<bool>  UserLoginAsync(string name ,string password);

    public Task<bool> RegisterAsync(string name ,string password);
}