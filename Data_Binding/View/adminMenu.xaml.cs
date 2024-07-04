using Data_Binding.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data_Binding.View
{
    /// <summary>
    /// Interaction logic for adminMenu.xaml
    /// </summary>
    public partial class adminMenu : Window
    {
        // private AdminMenuVM vm;

         

        public adminMenu()
        {
            InitializeComponent();
            DataContext = new AdminMenuVM();

        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModuleButton.IsChecked == true)
            {
                AddModule.Visibility = Visibility.Visible;
                EditModule.Visibility = Visibility.Visible;
            }
            else
            {
                AddModule.Visibility = Visibility.Collapsed;
                EditModule.Visibility = Visibility.Collapsed;
            }
        }

        private void ToggleButton_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (StudentsButton.IsChecked == true)
            {
                AddStudent.Visibility = Visibility.Visible;
                EditStudent.Visibility = Visibility.Visible;
            }
            else
            {
                AddStudent.Visibility = Visibility.Collapsed;
                EditStudent.Visibility = Visibility.Collapsed;
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            window.Content = new AdminAddStudent();

        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            window.Content = new AdminEditStudentxaml();
        }

        private void AddModule_Click(object sender, RoutedEventArgs e)
        {
            window.Content = new AddModuleWindow();
        }

        private void EditModule_Click(object sender, RoutedEventArgs e)
        {
            window.Content = new EditModuleWindow();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            window.Content = new AdminDashboard();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }
    }
}
