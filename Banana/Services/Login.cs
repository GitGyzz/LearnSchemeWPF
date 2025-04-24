using Banana.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace Banana.Services;

public class Login : ILogin
{

    private UserManager<IdentityUser> _userManager;
    
    public Login(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<bool>  UserLogin(string name ,string password)
    {
        var user=await _userManager.FindByNameAsync(name);
        if (user is null) return false;
        var exist = await _userManager.CheckPasswordAsync(user, password);
        if (exist) return true;
        return false;
    }

    public async Task<bool> Register(string name,string password)
    {
        var user = await _userManager.FindByNameAsync(name);
        if (user is not null) return false;
        var r = await _userManager.CreateAsync(user, password);
        if (r.Succeeded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}