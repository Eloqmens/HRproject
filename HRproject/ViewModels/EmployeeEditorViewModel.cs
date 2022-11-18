using HR.DAL.Models;
using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRproject.ViewModels
{
    class EmployeeEditorViewModel : ViewModel
    {
        public int EmployeeId { get; }

        private string _Name;

        //private string Surname { get; set; }
        //private string Patronymic { get; set; }
        //private int Passport { get; set; }
        //private string Number { get; set; }
        //private string Adress { get; set; }
        //private DateTime DateofBirth { get; set; }
        //public Department Department { get; set; }
        //public Position Position { get; set; }

        public string Name { get => _Name; set => Set(ref _Name, value); }


        public EmployeeEditorViewModel()
            :this(new Employee { Id = 1, Name = "Имя 228"})
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Не для райнтайма");
        }

        public EmployeeEditorViewModel(Employee employee)
        {
            EmployeeId = employee.Id;
            Name = employee.Name;
        }
    }
}
