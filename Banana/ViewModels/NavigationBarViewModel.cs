using Banana.Data;
using Banana.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Banana.ViewModels;

public class NavigationBarViewModel
{
    private INavigation _navigation;

    private AppDbContext _appDbContext;

    public RelayCommand DatabaseCommand { get; }
    
    public NavigationBarViewModel(INavigation navigation,AppDbContext appDbContext)
    {
        _navigation = navigation;
        _appDbContext = appDbContext;
        DatabaseCommand = new RelayCommand(DatabaseButton);
    }

    public void DatabaseButton()
    {
        _appDbContext.Database.EnsureCreated();

    }
    
    
}