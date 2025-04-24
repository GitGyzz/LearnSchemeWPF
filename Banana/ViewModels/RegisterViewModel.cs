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

    public IRelayCommand RegisterButtonCommand { get; }    
        
    public RegisterViewModel(ILogin login)
    {
        _login = login;
        RegisterButtonCommand = new RelayCommand(RegisterButton);
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
    
}