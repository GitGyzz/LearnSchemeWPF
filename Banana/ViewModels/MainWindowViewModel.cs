using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Banana.Views;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Banana.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        private UserControl _control;
        
        public UserControl Content
        {
            get => _control??=new LoginView();
            set => SetProperty(ref _control, value); 

        }
    }
}
