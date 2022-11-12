using HR.DAL.Models;
using HRproject.Interfaces;
using HRproject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRproject.Services
{
    class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _Employees;
        private readonly IRepository<Department> _Department;
        private readonly IRepository<Position> _Positions;

        public EmployeeService(
            IRepository<Employee> Employees,
            IRepository<Department> Department,
            IRepository<Position> Positions)
        {
            _Employees = Employees;
            _Department = Department;
            _Positions = Positions;
        }


    }
}
