using Banana.Data;
using Banana.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTest;

public class Startup
{
    public void ConfigureServices(IServiceCollection service)
    {
        service.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=:memory:"));
        
        service.AddIdentityCore<IdentityUser>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddUserManager<UserManager<IdentityUser>>();
        
        service.AddSingleton<Login>();
 
    }
}