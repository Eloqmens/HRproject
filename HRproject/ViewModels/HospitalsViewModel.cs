using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;

namespace HRproject.ViewModels
{
    class HospitalsViewModel : ViewModel
    {
        private IRepository<Hospital> _Hospital;

        public HospitalsViewModel(IRepository<Hospital> Hospital)
        {
            _Hospital = Hospital;
        }
    }
}
