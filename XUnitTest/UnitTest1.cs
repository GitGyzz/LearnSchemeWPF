using System.DirectoryServices.ActiveDirectory;
using Banana.Services;
using Microsoft.AspNetCore.Identity;

namespace XUnitTest
{
    public class UnitTest1
    {
        private Login _login;
        
        private UserManager<IdentityUser> _userManager;
        
        public UnitTest1(UserManager<IdentityUser> userManager,
            Login login)
        {
            _userManager = userManager;
            _login = login;
        }
        
        [Fact]
        public async void LoginRegister_True()
        {
            string name = "admin";
            string password = "123";
            bool r= await _login.RegisterAsync(name, password);
            Assert.True(r);
        }
    }
}