using Pampara.DataAccess.Interface;
using Pampara.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pampara.BusinessLogic.Service
{
   public class EmployeeService
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return _repository.GetAll();
        }

        public Employee SaveEmployee(Employee employee)
        {
            employee.HireDate = DateTime.Now;
            var result = _repository.Create(employee);
            return result;
        }

    }
}
