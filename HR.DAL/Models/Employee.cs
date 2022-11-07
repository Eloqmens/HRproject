using HR.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Models
{
    public class Employee : Person
    {
        public int Passport { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
        public DateTime DateofBirth { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public override string ToString() => $"Сотрудник {Surname} {Name} {Patronymic}, Должность {Position}, Отдел {Department}";

    }
}
