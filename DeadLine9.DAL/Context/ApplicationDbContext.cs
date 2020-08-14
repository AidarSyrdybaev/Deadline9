using DeadLine9.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Context
{
    public class ApplicationDbContext: DbContext
    {

        public DbSet<Department> Departments { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Lession> Lessions { get; set; }

        public DbSet<Point> Points { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationDbContext(DbContextOptions options): base(options)
        { 
        
        }
    }
}
