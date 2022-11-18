using HR.DAL.Models;
using HRproject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRproject.Infrastructure.DebugServices
{
    class DebugEmoloyeeRepository : IRepository<Employee>
    {
        public DebugEmoloyeeRepository()
        {


            var employees = Enumerable.Range(1, 100)
                .Select(i => new Employee
                {
                    Id = i,
                    Name = $"Name {i}",
                    Number = $"Number {i}",
                    Patronymic = $"Patronymic {i}"
                }).ToArray();

            var departments = Enumerable.Range(1, 100)
                .Select(i => new Department
                {
                    Id = i,
                    Name = $"Department {i}"
                }).ToArray();

            var positions = Enumerable.Range(1, 100)
                .Select(i => new Position
                {
                    Id = i,
                    Name = $"Position {i}",
                }).ToArray();

            foreach (var emoloyee in employees)
            {
                var items = emoloyee.Name.Any();
            }

            Items = employees.AsQueryable();
        }


        public IQueryable<Employee> Items { get; }

        public Employee Add(Employee item)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> AddAsync(Employee item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
