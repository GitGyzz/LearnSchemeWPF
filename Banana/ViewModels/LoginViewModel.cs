using System.ComponentModel;
using System.Runtime.CompilerServices;
using Banana.Services;
using Banana.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Banana.ViewModels;

public class LoginViewModel : ObservableObject
{
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }
    
    private ILogin _login;

    private INavigation _navigation;
    
    public IRelayCommand LoginButtonCommand { get; }    
    public IRelayCommand NaviToRegisterButtonCommand { get; }  
        
    public LoginViewModel(ILogin login,INavigation navigation)
    {
        _login = login;
        _navigation = navigation;
        LoginButtonCommand = new RelayCommand(LoginButton);
        NaviToRegisterButtonCommand = new RelayCommand(NaviToRegisterButton);
    }

    public async void LoginButton()
    {
        var error=await _login.UserLogin(Name,Password);
        if (error==false)
        {
            Console.WriteLine("success");
        }
        else
        {
            Console.WriteLine("fail");
        }
    }
    
    public async void NaviToRegisterButton()
    {
        _navigation.NaviTo(typeof(Register));
    }
    
}






















