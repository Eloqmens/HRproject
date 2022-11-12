using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;

namespace HRproject.ViewModels
{
    class EmployeesViewModel : ViewModel
    {
        private readonly IRepository<Employee> _Employees;
        public EmployeesViewModel(IRepository<Employee> Employees)
        {
            _Employees = Employees;
        }
    }
}
