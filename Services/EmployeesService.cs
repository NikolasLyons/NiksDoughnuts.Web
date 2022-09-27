using Microsoft.AspNetCore.Mvc;
using NiksDoughnuts.Web.Models;
using NiksDoughnuts.Web.Repositories;

namespace NiksDoughnuts.Web.Services
{
    public class EmployeesService
    {
        private readonly EmployeesRepository _er;

        public EmployeesService(EmployeesRepository employeesRepository)
        {
            _er = employeesRepository;
        }
        internal List<Employee> Get()
        {
            return _er.Get();
        }
        internal Employee GetById(int id)
        {
            Employee found = _er.GetbyId(id);
                if(found == null)
            {
                throw new Exception("InValid Id");
            }
            return found;
        }

        internal Employee Create(Employee employeeData)
        {
            return _er.Create(employeeData);
        }

        internal Employee Edit(Employee employeeData)
        {
            Employee original = GetById(employeeData.Id);
            if(original.Id != employeeData.Id)
            {
                throw new Exception("InValid Id");
            }
            original.Name = employeeData.Name ?? original.Name;
            _er.Edit(original);
            return original;
        }
        internal Employee Deleted(int id) 
        {
            Employee original = GetById(id);
            if(original.Id != id)
            {
                throw new Exception("Invalid Id");
            }
            _er.Deleted(id);
            return original;
        }

    }
}
