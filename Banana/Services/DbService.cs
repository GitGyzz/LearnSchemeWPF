using Banana.Data;
using Microsoft.EntityFrameworkCore;

namespace Banana.Services;

public class DbService : IDbService
{

    private AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Migration()
    {
        _dbContext.Database.Migrate();
    }
}