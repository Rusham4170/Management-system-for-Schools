using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data_Binding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Binding.ViewModel
{
    public partial class ResultsDetailsVM : ObservableObject
    {


        //public Student? CurrStudent { get; set; }

        [ObservableProperty]
        public double gpa;
        public Student? Dstudent { get; set; }
        public List<Module> AvailableModules { get; set; }
       

        public ResultsDetailsVM(Student student)
        {
            Dstudent = student;
            gpa = Dstudent.GPA;
           

            using (DataBaseContext context = new DataBaseContext())
            {
                AvailableModules = context.Modules.ToList();

            }
        }

        [RelayCommand]

        public void CalculateGPA()
        {
            using (DataBaseContext context = new DataBaseContext())
            {

                Dstudent = context.Students.FirstOrDefault(s => s.Id == Dstudent.Id);

                if (Dstudent != null)
                {
                    var selectedModules = AvailableModules.Where(m => m.IsSelected).ToList();
                    Dstudent.SelModules = selectedModules;
                    context.SaveChanges();
                }
            }
            double totalCredit = 0;
            double totalPoints = 0;

            foreach (var module in Dstudent.SelModules)
            {
                double Points = 0;
                double Credit = module.Credit;
                switch (module.Result) 
                {
                    
                    case "A+":
                    case "A":
                        Points = 4.0; break;
                    case "A-":
                        Points= 3.7; break;
                    case "B+":
                        Points = 3.4; break;
                    case "B":
                        Points = 3.0; break;
                    case "B-":
                        Points = 2.7; break;
                    case "C+":
                        Points = 2.4; break;
                    case "C":
                        Points = 2.0; break;
                    case "C-":
                        Points = 1.7; break;
                    default:
                        Points = 0; break;
                }
                totalPoints += (Points*Credit);
                totalCredit += Credit;
        }
            double GPA=totalPoints/totalCredit;
            Dstudent.GPA= GPA;
            gpa=Dstudent.GPA;
            using(DataBaseContext context = new DataBaseContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Id == Dstudent.Id);
                if (student != null)
                {
                    student.GPA = GPA;
                    context.SaveChanges();
                }
            }

        }
    }
}
