using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Banana.Views;


namespace Banana.ViewModels
{
    class MainWindowViewModel 
    {
        public UserControl Content { get; set; } = new Login();
    }
}
