using Microsoft.EntityFrameworkCore;

namespace Banana.Services;

public interface IDbService
{

    public void Migration();
}