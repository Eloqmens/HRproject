using HR.DAL.Models;
using HRproject.Interfaces;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using System.Windows.Input;

namespace HRproject.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Title
        private string _Title = "Отдел Кадров";

        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion


        #region CurrentModel : ViewModel - Текущая дочерняя модель-представления

        /// <summary>
        /// Текущая дочерняя модель-представления
        /// </summary>
        private ViewModel _CurrentModel;
        
        public ViewModel CurrentModel { get => _CurrentModel; private set => Set(ref _CurrentModel, value); }
        #endregion


        #region Предоставление Сотрудников
        /// <summary>
        /// Отобразить прдеставление сотрудников
        /// </summary>
        private ICommand _ShowEmployeeViewCommand;
        /// <summary>
        /// Отобразить прдеставление сотрудников
        /// </summary>
        public ICommand ShowEmployeeViewCommand => _ShowEmployeeViewCommand
            ??= new LambdaCommand(OnShowEmployeeViewCommandExecuted, CanShowEmployeeViewCommandExecuted);
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние сотрудников
        /// </summary>
        private bool CanShowEmployeeViewCommandExecuted() => true;
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние сотрудников
        /// </summary>
        private void OnShowEmployeeViewCommandExecuted()
        {
            CurrentModel = new EmployeesViewModel(_Employee);
        }
        #endregion


        #region Предоставление Отделов
        /// <summary>
        /// Отобразить прдеставление Отделов
        /// </summary>
        private ICommand _ShowDepartmentsViewCommand;
        /// <summary>
        /// Отобразить прдеставление Отделов
        /// </summary>
        public ICommand ShowDepartmentsViewCommand => _ShowDepartmentsViewCommand
            ??= new LambdaCommand(OnShowDepartmentsViewCommandExecuted, CanShowDepartmentsViewCommandExecuted);
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние Отделов
        /// </summary>
        private bool CanShowDepartmentsViewCommandExecuted() => true;
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние Отделов
        /// </summary>
        private void OnShowDepartmentsViewCommandExecuted()
        {
            CurrentModel = new DeparmentsViewModel(_Department);
        }
        #endregion


        #region Предоставление Должностей
        /// <summary>
        /// Отобразить прдеставление должностей
        /// </summary>
        private ICommand _ShowPostionsViewCommand;
        /// <summary>
        /// Отобразить прдеставление должностей
        /// </summary>
        public ICommand ShowPostionsViewCommand => _ShowPostionsViewCommand
            ??= new LambdaCommand(OnShowPostionsViewCommandExecuted, CanShowPostionsViewCommandExecuted);
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние должностей
        /// </summary>
        private bool CanShowPostionsViewCommandExecuted() => true;
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние должностей
        /// </summary>
        private void OnShowPostionsViewCommandExecuted()
        {
            CurrentModel = new PositionsViewModel(_Position);
        }
        #endregion


        #region Предоставление Больных
        /// <summary>
        /// Отобразить прдеставление больных
        /// </summary>
        private ICommand _ShowHospitalsViewCommand;
        /// <summary>
        /// Отобразить прдеставление больных
        /// </summary>
        public ICommand ShowHospitalsViewCommand => _ShowHospitalsViewCommand
            ??= new LambdaCommand(OnShowHospitalsViewCommandExecuted, CanShowHospitalsViewCommandExecuted);
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние больных
        /// </summary>
        private bool CanShowHospitalsViewCommandExecuted() => true;
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние больных
        /// </summary>
        private void OnShowHospitalsViewCommandExecuted()
        {
            CurrentModel = new HospitalsViewModel(_Hospital);
        }
        #endregion


        #region Предоставление Отпускных
        /// <summary>
        /// Отобразить прдеставление отпускных
        /// </summary>
        private ICommand _ShowVacationsViewCommand;
        /// <summary>
        /// Отобразить прдеставление отпускных
        /// </summary>
        public ICommand ShowVacationsViewCommand => _ShowVacationsViewCommand
            ??= new LambdaCommand(OnShowVacationsViewCommandExecuted, CanShowVacationsViewCommandExecuted);
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние отпускных
        /// </summary>
        private bool CanShowVacationsViewCommandExecuted() => true;
        /// <summary>
        /// Проверка возможности выполнение - Отобразить прдеставлние отпускных
        /// </summary>
        private void OnShowVacationsViewCommandExecuted()
        {
            CurrentModel = new VacationsViewModel(_Vacation);
        }
        #endregion



        private IRepository<Employee> _Employee;
        private IRepository<Department> _Department;
        private IRepository<Position> _Position;
        private IRepository<Hospital> _Hospital;
        private IRepository<Vacation> _Vacation;
        public MainWindowViewModel(IRepository<Employee> Employee,
            IRepository<Department> Department,
            IRepository<Position> Position,
            IRepository<Hospital> Hospital,
            IRepository<Vacation> Vacation)
        {
            _Employee = Employee;
            _Department = Department;
            _Position = Position;
            _Hospital = Hospital;
            _Vacation = Vacation;


        }
    }
}
