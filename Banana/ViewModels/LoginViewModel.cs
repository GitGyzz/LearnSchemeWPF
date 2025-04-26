using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Accessibility;
using Banana.Services;
using Banana.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Banana.ViewModels;

public class LoginViewModel : ObservableObject , INotifyDataErrorInfo
{
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            ValidateUser();
            OnPropertyChanged(nameof(_name));
        } 
    }

    public string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            ValidatePassword();
            OnPropertyChanged(nameof(_password));
        }
    }
    
    private string _messageResult;

    public string MessageResult
    {
        get => _messageResult;
        set
        {
            SetProperty(ref _messageResult, value);
        }
    }
    
    private ILogin _login;

    private INavigation _navigation;
    
    public IRelayCommand LoginButtonCommand { get; }    
    public IRelayCommand NaviToRegisterButtonCommand { get; }

    private readonly Dictionary<string, List<string>> _errorDictionary = new ();
    public LoginViewModel(ILogin login,INavigation navigation)
    {
        _login = login;
        _navigation = navigation;
        LoginButtonCommand = new RelayCommand(LoginButton);
        NaviToRegisterButtonCommand = new RelayCommand(NaviToRegisterButton);
        
        //一启动就触发一次验证
        Name = "admin";
        Password = "123";
    }

    public async void LoginButton()
    {
        var succeed=await _login.UserLoginAsync(Name,Password);
        if (succeed)
        {
            _navigation.NaviTo(typeof(TimeRecordView));
        }
        else
        {
            Console.WriteLine("fail");
        }
    }
    
    public async void NaviToRegisterButton()
    {
        _navigation.NaviTo(typeof(RegisterView));
    }


    public bool HasErrors => _errorDictionary.Any();
    

    public IEnumerable GetErrors(string? property) =>
        _errorDictionary.ContainsKey(property)? _errorDictionary[property] : null;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public void OnErrorsChanged(string property)
    {
        ErrorsChanged?.Invoke(this,new DataErrorsChangedEventArgs(property));
        OnPropertyChanged(nameof(HasErrors));
    }
    public void ValidateUser()
    {
        ClearErrors(nameof(Name));
        if (string.IsNullOrEmpty(Name))
            AddError(nameof(Name),"不能为空");
        if (Name.Length>6)
            AddError(nameof(Name),"不能多于6个字符");
    }
    public void ValidatePassword()
    {
        ClearErrors(nameof(Password));
        if (string.IsNullOrEmpty(Password))
            AddError(nameof(Password),"不能为空");
        if (Password.Length>6)
            AddError(nameof(Password),"不能多于6个字符");
    }

    public void AddError(string property,string errorString)
    {
        if (!_errorDictionary.ContainsKey(property))
        {
            _errorDictionary[property] = new();
        }

        if (!_errorDictionary[property].Contains(errorString))
        {
            _errorDictionary[property].Add(errorString);
            OnErrorsChanged(property);
        }
    }

    public void ClearErrors(string property)
    {
        if (_errorDictionary.ContainsKey(property))
        {
            _errorDictionary.Remove(property);
            OnErrorsChanged(property);
        }
    }
}






















