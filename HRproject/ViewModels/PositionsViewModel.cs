using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;

namespace HRproject.ViewModels
{
    class PositionsViewModel : ViewModel
    {
        private IRepository<Position> _Position;

        public PositionsViewModel(IRepository<Position> Position)
        {
            _Position = Position;
        }
    }
}
