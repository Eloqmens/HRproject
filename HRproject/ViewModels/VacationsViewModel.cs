using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;

namespace HRproject.ViewModels
{
    class VacationsViewModel : ViewModel
    {
        private IRepository<Vacation> _Vacation;

        public VacationsViewModel(IRepository<Vacation> Vacation)
        {
            _Vacation = Vacation;
        }
    }
}
