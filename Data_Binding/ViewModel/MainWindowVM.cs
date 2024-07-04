using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data_Binding.Model;
using Data_Binding.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Data_Binding.ViewModel
{
    public partial class MainWindowVM:ObservableObject
    {
        
        public string? UserName { get; set; }
       
        public string? Password { get; set; }

        public bool IsAdminLogin { get; set; } = true;
        public bool IsStudentLogin { get; set; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }


        public MainWindowVM()
        {

        }

        [RelayCommand]
        public void Login()
        {
            if(IsAdminLogin==true && IsStudentLogin==false)
            {
                string username = "admin";
                string password = "2a1b";
                if (UserName == username && Password == password)
                {
                    var adminmenu = new adminMenu();
                    adminmenu.Show();

                }
                else
                {
                    ErrorMessage = "UserName or Password is Incorrect";
                }

            }else if(IsAdminLogin==false && IsStudentLogin==true)
            {
                if (int.TryParse(UserName, out int id))
                {

                    using (DataBaseContext context = new DataBaseContext())
                    {
                        var currstudent = context.Students.FirstOrDefault(St => St.Id == id && St.Password == Password);
                        if (currstudent != null)
                        {
                            var studentMainViewModel = new StudentMainVM(currstudent.Id);
                            var resultDetailsVM = new ResultsDetailsVM(currstudent);
                            var studentMain = new StudentMain(studentMainViewModel,resultDetailsVM);
                            studentMain.Show();
                        }
                        else
                        {
                            ErrorMessage = "UserName or Password is Incorrect";
                        }

                    }
                }
                else 
                {
                    ErrorMessage = "UserName or Password is Incorrect";
                }
            }
            

        }
        
        
        
    }
}
