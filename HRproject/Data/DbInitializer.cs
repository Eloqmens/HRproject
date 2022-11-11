﻿using HR.DAL.Context;
using HR.DAL.Models;
using HRproject.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRproject.Data
{
    class DbInitializer
    {
        private ResourcesDepartmentDB _db;
        private ILogger<DbInitializer> _Logger;


        public DbInitializer(ResourcesDepartmentDB db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация БД...");

            _Logger.LogInformation("Миграция БД...");
            await _db.Database.MigrateAsync().ConfigureAwait(false);
            _Logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await _db.Employees.AnyAsync()) return;

        }

        private Department[] _Departments;
        private const int __DepartmentsCount = 10;
        private async Task IntializeDepartments()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация Отделов");

            var rnd = new Random();
            _Departments = Enumerable.Range(1, __DepartmentsCount)
                .Select(i => new Department
                {
                    Name = $"Отдел {i}"
                }).ToArray();

            await _db.Departments.AddRangeAsync(_Departments);
            await _db.SaveChangesAsync();

            _Logger.LogInformation("Инициализация отделов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int __PositionsCount = 10;
        private Position[] _Positions;

        private async Task IntializePositions()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация Должностей");

            var rnd = new Random();
            _Positions = Enumerable.Range(1, __PositionsCount)
                .Select(i => new Position
                {
                    Name = $"Должность {i}",
                    Patch = (decimal)(rnd.NextDouble() * 4000 + 700)
                }).ToArray();

            await _db.Positions.AddRangeAsync(_Positions);
            await _db.SaveChangesAsync();

            _Logger.LogInformation("Инициализация должностей выполнена за {0} мс", timer.ElapsedMilliseconds);
        }


        private Employee[] _Employees;
        private const int __EmployeesCount = 1000;

        //private async Task IntializeEmployees()
        //{
        //    var rnd = new Random();
        //    _Employees = Enumerable.Range(1, __EmployeesCount)
        //        .Select(i => new Employee
        //        {
        //            Name = $"Имя {i}",
        //            Surname = $"Фамилия {i}",
        //            Patronymic = $"Отчество {i}",
        //            Number = rnd.GetRandomNumber(),
        //            Adress = rnd.RandomAddress(),
        //            DateofBirth = rnd.RandomDay(),
        //            Passport = rnd.PassportNumber(),
        //            Department = rnd.NextItem(_Departments),
        //            Position = rnd.NextItem(_Positions),
        //        });

        //    await _db.Employees.AddRangeAsync(_Employees);
        //    await _db.SaveChangesAsync();
        //}
        //private async Task IntializeEmployees()
        //{
        //    var rnd = new Random();
        //    _Employees = new Employee[__EmployeesCount];
        //    for (var i = 0; i < __EmployeesCount; i++)
        //        _Employees[i] = new Employee {
        //            Name = $"Имя {i}",
        //            Surname = $"Фамилия {i}",
        //            Patronymic = $"Отчество {i}",
        //            Number = rnd.GetRandomNumber(),
        //            Adress = rnd.RandomAddress(),
        //            DateofBirth = rnd.RandomDay(),
        //            Passport = rnd.PassportNumber(),
        //            Department = rnd.NextItem(_Departments),
        //            Position = rnd.NextItem(_Positions),
        //        };

        //    await _db.Employees.AddRangeAsync(_Employees);
        //    await _db.SaveChangesAsync();
        //}

        private Hospital[] _Hospitals;
        private const int __HospitalsCount = 10;

        //private async Task IntializeHospitals()
        //{
        //    var rnd = new Random();
        //    _Hospitals = Enumerable.Range(1, __HospitalsCount)
        //        .Select(i => new Hospital
        //        {
        //            DateStart = DateTime.Today,
        //            DateEnd = DateTime.Today,
        //            Diagnosis = $"Диагноз {i}",
        //            Employee = rnd.NextItem(_Employees)

        //        });

        //    await _db.Hospitals.AddRangeAsync(_Hospitals);
        //    await _db.SaveChangesAsync();
        //}

        private Vacation[] _Vacations;
        private const int __VacationsCount = 10;

        //    private async Task IntializeVacations()
        //    {
        //        var rnd = new Random();
        //        _Vacations = Enumerable.Range(1, __VacationsCount)
        //            .Select(i => new Vacation { 
        //            DateEnd = DateTime.MaxValue.Date,
        //            DateStart = DateTime.Today,
        //            Employee = rnd.NextItem(_Employees)
        //            });
        //    }

    }
}
