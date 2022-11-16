using HR.DAL.Context;
using HR.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL
{
    class EmployeeRepository : DbRepository<Employee>
    {
        public override IQueryable<Employee> Items => base.Items
            .Include(item => item.Department)
            .Include(item => item.Position)
            ;

        public EmployeeRepository(ResourcesDepartmentDB db) : base(db) { }
    }
}
