using Banana.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace Banana.Services;

public class Login : ILogin
{

    private UserManager<IdentityUser> _userManager;
    private AppDbContext _appDbContext;
    
    public Login(UserManager<IdentityUser> userManager,AppDbContext appDbContext)
    {
        _userManager = userManager;
        _appDbContext = appDbContext;
    }
    
    public async Task<bool>  UserLoginAsync(string name ,string password)
    {
        if (string.IsNullOrEmpty(name)) return false;
        var user=await _userManager.FindByNameAsync(name);
        if (user is null) return false;
        var exist = await _userManager.CheckPasswordAsync(user, password);
        if (exist) return true;
        return false;
    }

    public async Task<bool> RegisterAsync(string name,string password)
    {
        if (string.IsNullOrEmpty(name)) return false;
        var user = await _userManager.FindByNameAsync(name);
        if (user is not null) return false;
        var identityUser = new IdentityUser()
        {
            UserName = name,
        };
        var r = await _userManager.CreateAsync(identityUser, password);
        if (r.Succeeded)
        {
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        else
        {
            return false;
        }
    }
}