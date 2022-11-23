using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace HRproject.ViewModels
{
    class EmployeeEditorViewModel : ViewModel
    {
        private CollectionViewSource _DepartmentViewSource;
        public ICollectionView DepartmentView => _DepartmentViewSource?.View;

        private CollectionViewSource _PositionViewSource;
        public ICollectionView PositionView => _PositionViewSource?.View;

        private IRepository<Department> _DeparmentRepository;
        private IRepository<Position> _PositionRepository;
 
        #region Employee : ObservableCollection<Employee> - Коллекция Департаментов

        /// <summary>Коллекция Департаментов</summary>
        private ObservableCollection<Department> _Departments;

        /// <summary>Коллекция Департаментов</summary> 
        public ObservableCollection<Department> Departments
        {
            get => _Departments;
            set
            {
                if (Set(ref _Departments, value))
                {
                    _DepartmentViewSource = new CollectionViewSource
                    {
                        Source = value
                    };

                    OnPropertyChanged(nameof(DepartmentView));
                }
            }
        }
        #endregion

        #region Employee : ObservableCollection<Position> - Коллекция Должностей

        /// <summary>Коллекция Должностей</summary>
        private ObservableCollection<Position> _Positions;

        /// <summary>Коллекция Должностей</summary> 
        public ObservableCollection<Position> Positions
        {
            get => _Positions;
            set
            {
                if (Set(ref _Positions, value))
                {
                    _PositionViewSource = new CollectionViewSource
                    {
                        Source = value
                    };

                    OnPropertyChanged(nameof(PositionView));
                }
            }
        }
        #endregion

        #region Command LoadDataCommand - Команда загрузки данных из репозитория

        /// <summary>Команда загрузки данных из репозитория</summary>
        private ICommand _LoadDataCommand;

        /// <summary>Команда загрузки данных из репозитория</summary>
        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда загрузки данных из репозитория</summary>
        private bool CanLoadDataCommandExecute() => true;

        /// <summary>Логика выполнения - Команда загрузки данных из репозитория</summary>
        private async Task OnLoadDataCommandExecuted()
        {
            Departments = new ObservableCollection<Department>(await _DeparmentRepository.Items.ToArrayAsync());
            Positions = new ObservableCollection<Position>(await _PositionRepository.Items.ToArrayAsync());                     
        }
        #endregion

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
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Не для райнтайма");

            _ = OnLoadDataCommandExecuted();
        }

        public EmployeeEditorViewModel(Employee employee, IRepository<Department> repository, IRepository<Position> repository1)
        {
            _DeparmentRepository = repository;
            _PositionRepository = repository1;
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
