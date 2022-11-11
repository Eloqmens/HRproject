using HR.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Context
{
    public class ResourcesDepartmentDB : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        public ResourcesDepartmentDB(DbContextOptions<ResourcesDepartmentDB> options) : base(options)
        {

        }
    }
}
