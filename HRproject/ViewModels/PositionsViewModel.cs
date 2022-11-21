using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;

namespace HRproject.ViewModels
{
    class PositionsViewModel : ViewModel
    {
        private readonly IRepository<Position> _Position;

        public PositionsViewModel(IRepository<Position> Position)
        {
            _Position = Position;
        }
    }
}
