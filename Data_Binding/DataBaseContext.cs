using Data_Binding.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Binding
{
    public class DataBaseContext:DbContext
    {
        //private readonly string path = @"E:\Academic\sem3\GUI\Data_Binding\Data_Binding\new.db";
        private readonly string relpath = "Database/new.db";
        private readonly string path;
        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");

        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DataBaseContext()
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relpath);
        }


    }
}
