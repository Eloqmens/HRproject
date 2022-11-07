using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRproject.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Title
        private string _Title = "Отдел Кадров";

        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

    }
}
