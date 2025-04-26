using Banana.Data;
using Banana.Services;
using Banana.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Banana.ViewModels;

public class NavigationBarViewModel : ObservableObject
{
    private INavigation _navigation;
    private AppDbContext _appDbContext;

    private double _width=75;
    public double Width
    {
        get => _width;
        set => SetProperty(ref _width, value);
    }

    private bool _isOpening = false;
    private bool _isOpen = false;
    public RelayCommand DatabaseCommand { get; }
    public RelayCommand TimerCommand { get; }
    public RelayCommand OpenButtonCommand { get; }
    
    public NavigationBarViewModel(INavigation navigation, AppDbContext appDbContext)
    {
        _navigation = navigation;
        _appDbContext = appDbContext;
        DatabaseCommand = new RelayCommand(DatabaseButton);
        TimerCommand = new RelayCommand(TimerButton);
        OpenButtonCommand = new RelayCommand(OpenButton);
    }
    
    public async void OpenButton()
    {
        if (_isOpening) return;
        if (_isOpen)
        {
            _isOpening = true;
            for (double i = 150 ; i >= 75; i--)
            {
                await Task.Delay(10);
                Width = i;
            }
            _isOpen = false;
            _isOpening = false;
        }
        else
        {
            _isOpening = true;
            for (double i = 75 ; i <= 150; i++)
            {
                await Task.Delay(10);
                Width = i;
            }
            _isOpen = true;
            _isOpening = false;
        }
    }
    

    public void TimerButton()
    {
        _navigation.NaviTo(typeof(TimeRecordView));
    }
    public void DatabaseButton()
    {
        _appDbContext.Database.EnsureCreated();
    }
}