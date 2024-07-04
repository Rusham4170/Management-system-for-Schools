using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Binding.Model
{
    public class Student
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public int Age { get; set; }

        public List<Module>? SelModules;


        public double GPA { get; set; }



    

        

       /* public Student(string firstName, string lastName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password= password;
           
        }
        public Student() { }*/

    }
}
