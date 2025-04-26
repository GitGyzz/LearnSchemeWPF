using Microsoft.AspNetCore.Identity;

namespace Banana.Models;

public class User : IdentityUser
{
    public DateTime LastTime { get; set; }
    public long LengthOfTime { get; set; }
}