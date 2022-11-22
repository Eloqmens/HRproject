using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRproject.ViewModels
{
    class EmployeeEditorViewModel : ViewModel
    {
        public Employee Employee { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Position> Positions { get; set; }

        public int EmployeeId { get; }
        private string _Name;
        private string _Surname;
        private string _Patronymic;
        private int _Passport;
        private string _Number;
        private string _Adress;
        private DateTime _DateofBirth;
        private Department _Department;
        private Position _Position;

        public string Name { get => _Name; set => Set(ref _Name, value); }
        public string Surname { get => _Surname; set => Set(ref _Surname, value); }
        public string Patronymic { get => _Patronymic; set => Set(ref _Patronymic, value); }
        public int Passport { get => _Passport; set => Set(ref _Passport, value); }
        public string Number { get => _Number; set => Set(ref _Number, value); }
        public string Adress { get => _Adress; set => Set(ref _Adress, value); }
        public DateTime DateofBirth { get => _DateofBirth; set => Set(ref _DateofBirth, value); }
        public Department Department { get => _Department; set => Set(ref _Department, value); }
        public Position Position { get => _Position; set => Set(ref _Position, value); }

        public EmployeeEditorViewModel()
            : this(new Employee { Name = "Name!"})
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
