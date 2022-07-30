using EmployeeManagement.WinClient.Infrastructure;
using EmployeeManagement.WinClient.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManagement.WinClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthView : Window
    {
        public AuthView()
        {
            InitializeComponent();
            Loaded += AuthView_Loaded;
        }

        private void AuthView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IClose wind)
            {
                wind.Close += () => this.Close();
            }
        }
    }
}
