using HR.DAL.Models;
using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HRproject.ViewModels
{
    class EmployeeEditorViewModel : ViewModel
    {
        public int EmployeeId { get; }

        private string _Name;
        private string _Surname;
        private string _Patronymic;
        private int _Passport;
        private string _Number;
        private string _Adress;
        private DateTime _DateofBirth;
        public Department Department { get; set; }
        public Position Position { get; set; }

        public string Name { get => _Name; set => Set(ref _Name, value); }
        public string Surname { get => _Surname; set => Set(ref _Surname, value); }
        public string Patronymic { get => _Patronymic; set => Set(ref _Patronymic, value); }
        public int Passport { get => _Passport; set => Set(ref _Passport, value); }
        public string Number { get => _Number; set => Set(ref _Number, value); }
        public string Adress { get => _Adress; set => Set(ref _Adress, value); }
        public DateTime DateofBirth { get => _DateofBirth; set => Set(ref _DateofBirth, value); }

        public EmployeeEditorViewModel()
            :this(new Employee {Name = "ЕБУЧИЕИМЯ!" })
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Не для райнтайма");
        }

        public EmployeeEditorViewModel(Employee employee)
        {
            EmployeeId = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Patronymic = employee.Patronymic;
            Passport = employee.Passport;
            Number = employee.Number;
            Adress = employee.Adress;
            DateofBirth = employee.DateofBirth;
            Department = employee.Department;
            Position = employee.Position;
        }

        
    }
}
