using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Binding.Model
{
    public class Module
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Credit { get; set; }
        [NotMapped] public List<string>? Grades { get; set; } = new List<string> { "A+", "A", "A-", "B+", "B", "B-","C+", "C", "C-" };
        public string? Result { get; set; }

        public bool IsSelected { get; set; }   
    }
}
