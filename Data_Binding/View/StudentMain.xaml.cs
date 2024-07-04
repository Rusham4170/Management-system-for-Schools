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

namespace Data_Binding.View
{
    /// <summary>
    /// Interaction logic for StudentMain.xaml
    /// </summary>
    public partial class StudentMain : Window
    {
        public StudentMainVM studentMainViewModel1 { get; set;}
        public ResultsDetailsVM resultsDetailsVM { get; set;}

        public StudentMain(StudentMainVM studentMainViewModel, ResultsDetailsVM resultsDetailsVM)
        {
            DataContext = studentMainViewModel;
            studentMainViewModel1 = studentMainViewModel;
            InitializeComponent();
            this.resultsDetailsVM = resultsDetailsVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            window.Content = new StudentDashboard(studentMainViewModel1);

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            window.Content = new StudentEdit(studentMainViewModel1);
        }

        private void AddResults_Click(object sender, RoutedEventArgs e)
        {
            window.Content = new ResultsDetails(resultsDetailsVM);
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
