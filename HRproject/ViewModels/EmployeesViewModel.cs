using HR.DAL.Models;
using HRproject.Infrastructure.DebugServices;
using HRproject.Interfaces;
using HRproject.Services;
using HRproject.Services.Interfaces;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace HRproject.ViewModels
{
    class EmployeesViewModel : ViewModel
    {
        private readonly IRepository<Employee> _EmployeesRepository;
        private readonly IUserDialog _UserDialog;

        public IEnumerable<Employee> ListEmployees => _EmployeesRepository.Items;
          
        public EmployeesViewModel(IRepository<Employee> Employees, IUserDialog UserDialog)
        {
            _EmployeesRepository = Employees;
            _UserDialog = UserDialog;
        }

        private CollectionViewSource _EmployeeViewSource;
        public ICollectionView EmployeeView => _EmployeeViewSource?.View;

        #region Employee : ObservableCollection<Employee> - Коллекция Сотрудников

        /// <summary>Коллекция Сотрудников</summary>
        private ObservableCollection<Employee> _Employees;

        /// <summary>Коллекция Сотрудников</summary> 
        public ObservableCollection<Employee> Employees
        {
            get => _Employees;
            set
            {
                if (Set(ref _Employees, value))
                {
                    _EmployeeViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(Employee.Name), ListSortDirection.Ascending)
                        }
                    };

                    _EmployeeViewSource.Filter += OnEmployeeFilter;
                    _EmployeeViewSource.View.Refresh();

                    OnPropertyChanged(nameof(EmployeeView));
                }
            }
        }
        #endregion
        private void OnEmployeeFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Employee employee) || string.IsNullOrEmpty(EmployeeFilter)) return;

            if (!employee.Name.Contains(EmployeeFilter))
                e.Accepted = false;
        }

        private string _EmployeeFilter;
        public string EmployeeFilter 
        { 
            get => _EmployeeFilter;
            set {
                if (Set(ref _EmployeeFilter, value))
                    _EmployeeViewSource.View.Refresh();
            }
        }

        public string TestValue { get; } = "Test value!!!";


        #region SelectedEmployee : Employee - Выбранный Сотрудник

        /// <summary>Выбранный Сотрудник</summary>
        private Employee _SelectedEmployee;

        /// <summary>Выбранный Сотрудник</summary>
        public Employee SelectedEmployee { get => _SelectedEmployee; set => Set(ref _SelectedEmployee, value); }

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
            Employees = new ObservableCollection<Employee>(await _EmployeesRepository.Items.ToArrayAsync());
        }

        #endregion

        #region Command AddNewEmployeeCommand - Добавление нового сотрудника

        /// <summary>Добавление нового сотрудника</summary>
        private ICommand _AddNewEmployeeCommand;

        /// <summary>Добавление нового сотрудника</summary>
        public ICommand AddNewEmployeeCommand => _AddNewEmployeeCommand
            ??= new LambdaCommand(OnAddNewEmployeeCommandExecuted, CanAddNewEmployeeCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление нового сотрудника</summary>
        private bool CanAddNewEmployeeCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление нового сотрудника</summary>
        private void OnAddNewEmployeeCommandExecuted()
        {
            var new_employee = new Employee();

            if (!_UserDialog.Edit(new_employee))
                return;

            _Employees.Add(_EmployeesRepository.Add(new_employee));

            SelectedEmployee = new_employee;
        }

        #endregion

        #region Command RemoveEmployeeCommand : Employee - Удаление указаного сотрудника

        /// <summary>Удаление указаного сотрудника</summary>
        private ICommand _RemoveEmployeeCommand;

        /// <summary>Удаление указаного сотрудника</summary>
        public ICommand RemoveEmployeeCommand => _RemoveEmployeeCommand
            ??= new LambdaCommand<Employee>(OnRemoveEmployeeCommandExecuted, CanRemoveEmployeeCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление указаного сотрудника</summary>
        private bool CanRemoveEmployeeCommandExecute(Employee p) => p != null || SelectedEmployee != null;

        /// <summary>Проверка возможности выполнения - Удаление указаного сотрудника</summary>
        private void OnRemoveEmployeeCommandExecuted(Employee p)
        {
            var employee_remove = p ?? SelectedEmployee;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить книгу {employee_remove.Name}?", "Удаление книги"))
                return;

            _EmployeesRepository.Remove(employee_remove.Id);

            Employees.Remove(employee_remove);
            if (ReferenceEquals(SelectedEmployee, employee_remove))
                SelectedEmployee = null;
        }

        #endregion

        public EmployeesViewModel()
            : this(new DebugEmoloyeeRepository(), new UserDialogService())
        {
            if (App.IsDesignTime)
                throw new InvalidOperationException("данный конструктор не предназначен для исползьования вне дизайнера VisualStudio");

            _ = OnLoadDataCommandExecuted();
        }


    }
}
