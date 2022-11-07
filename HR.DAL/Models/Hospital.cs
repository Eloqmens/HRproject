using HR.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Models
{
    public class Hospital : DateStartAndEnd
    {
        public Employee Employee { get; set; }
        public override string ToString() => $"Больной {Surname} {Name} {Patronymic}, Дата начала {DateStart} Дата завершения {DateEnd}";
        public string Diagnosis { get; set; }
    }
}
