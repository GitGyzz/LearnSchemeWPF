using System.Reflection;
using System.Windows.Controls;

namespace Banana.Services;

public class Navigation : INavigation
{

    public void NaviTo(Type viewType)
    {
        var assembly = Assembly.GetExecutingAssembly();
        if (viewType is not null)
        {
            ServiceLocator.Current.MainWindowViewModel.Content=Activator.CreateInstance(viewType) as UserControl;
            
        }
    }
}