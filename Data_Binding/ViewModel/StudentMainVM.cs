using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data_Binding.Model;
using Data_Binding.View;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Data_Binding.ViewModel
{
    public partial class StudentMainVM : ObservableObject
    {

        public Student CurrStudent { get; set; }
        
        

        

        public StudentMainVM(int studentId)
        {
            
            using (DataBaseContext context = new DataBaseContext())
            {
                CurrStudent = context.Students.FirstOrDefault(s => s.Id == studentId);
            }
        }
        [RelayCommand]
        public void LogOut()
        {
            var win = new MainWindow();
            win.Show();
            
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }

        }

       

        [RelayCommand]
        private void UpdateStudent()
        {
           
            using(DataBaseContext context = new DataBaseContext())
            {
                Student student=new Student();
                student = context.Students.FirstOrDefault(s => s.Id == CurrStudent.Id);
                student.FirstName = CurrStudent.FirstName;
                student.LastName = CurrStudent.LastName;
                student.Age = CurrStudent.Age;
                context.SaveChanges();

            }
            
        }
        [RelayCommand]
        public void ResultsDetails()
        {
            var vm= new ResultsDetailsVM(CurrStudent);
            var win=new ResultsDetails(vm);
            //win.Show();
            
        }





    }
}
