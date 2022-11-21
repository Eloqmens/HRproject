using HR.DAL.Models;
using HRproject.Services.Interfaces;
using HRproject.ViewModels;
using HRproject.Views.Windows;
using System.Windows;

namespace HRproject.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(Employee employee)
        {
            var employee_editor_model = new EmployeeEditorViewModel(employee);

            var employee_editor_window = new EmployeeEditorWindow
            {
                DataContext = employee_editor_model
            };

            if (employee_editor_window.ShowDialog() != true) return false;

            employee.Name = employee_editor_model.Name;
            employee.Surname = employee_editor_model.Surname;
            employee.Patronymic = employee_editor_model.Patronymic;
            employee.Number = employee_editor_model.Number;
            employee.Adress = employee_editor_model.Adress;
            employee.DateofBirth = employee_editor_model.DateofBirth;
            employee.Department = employee_editor_model.Department;
            employee.Position = employee_editor_model.Position;

            return true;
        }

        public bool ConfirmError(string Error, string Caption) => MessageBox
           .Show(
                Error, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Error)
                == MessageBoxResult.Yes;

        public bool ConfirmInformation(string Information, string Caption) => MessageBox
           .Show(
                Information, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Information)
                == MessageBoxResult.Yes;

        public bool ConfirmWarning(string Warning, string Caption) => MessageBox
           .Show(
                Warning, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning)
                == MessageBoxResult.Yes;
    }
}
