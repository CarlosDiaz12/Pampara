using Pampara.DataAccess.Data;
using Pampara.DataAccess.Interface;
using Pampara.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pampara.DataAccess.Util;

namespace Pampara.DataAccess.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee Create(Employee _object)
        {
            var employee = _context.Employees.Add(_object);
            _context.SaveChanges();
            return employee.Entity;
        }

        public void Delete(int Id)
        {
           var employee = _context.Employees.FirstOrDefault(x => x.Id == Id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }

        public PagedResult<Employee> GetAllPaged(int page, int pageSize)
        {
            IQueryable<Employee> employees = _context.Employees.AsQueryable();
            var result = Pagination<Employee>.GetPagedResultForQuery(employees, page, pageSize);
            return result;
        }

        public Employee GetById(int Id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == Id);
            return employee;
        }

        public Employee Update(Employee _object)
        {
           
            var employee = _context.Employees.Update(_object);
            _context.SaveChanges();
            return employee.Entity;
        }

    }
}
