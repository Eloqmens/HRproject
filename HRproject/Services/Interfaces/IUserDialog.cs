using HR.DAL.Models;

namespace HRproject.Services.Interfaces
{
    internal interface IUserDialog
    {
        bool Edit(Employee Employee);

        bool ConfirmInformation(string Information, string Caption);
        bool ConfirmWarning(string Warning, string Caption);
        bool ConfirmError(string Error, string Caption);
    }
}
