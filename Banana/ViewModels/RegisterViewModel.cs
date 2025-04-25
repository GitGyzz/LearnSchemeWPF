using System.ComponentModel;
using System.Runtime.CompilerServices;
using Banana.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Banana.ViewModels;

public class RegisterViewModel : ObservableObject
{
    private string _name;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value); 
    }

    public string _password;
    public string Password
    {
        get => _password;
        set =>SetProperty(ref _password, value); 
    }

    private ILogin _login;

    private INavigation _navigation;

    public IRelayCommand RegisterButtonCommand { get; }    
    public IRelayCommand NaviToLoginButtonCommand { get; }    
    public RegisterViewModel(ILogin login,INavigation navigation)
    {
        _login = login;
        _navigation = navigation;
        RegisterButtonCommand = new RelayCommand(RegisterButton);
        NaviToLoginButtonCommand = new RelayCommand(NaviToLoginButton);
    }

    public async void RegisterButton()
    {
        var error=await _login.Register(Name,Password);
        if (error==false)
        {
            Console.WriteLine("success");
        }
        else
        {
            Console.WriteLine("fail");
        }
    }
    
    public async void NaviToLoginButton()
    {
        _navigation.NaviTo(typeof(Login));
    }
    
}