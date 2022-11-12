using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;

namespace HRproject.ViewModels
{
    class DeparmentsViewModel : ViewModel
    {
        private IRepository<Department> _Department;

        public DeparmentsViewModel(IRepository<Department> Department)
        {
            _Department = Department;
        }
    }
}
