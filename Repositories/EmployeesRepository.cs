using Dapper;
using NiksDoughnuts.Web.Models;
using System.Data;

namespace NiksDoughnuts.Web.Repositories
{
    public class EmployeesRepository
    {
        private readonly IDbConnection _db;
        public EmployeesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Employee> Get()
        {
            string sql = @"
              SELECT
              *
              FROM employees;
              ";
            return _db.Query<Employee>(sql).ToList();
        }

        internal Employee GetbyId(int id)
        {
            string sql = @"
               SELECT
                e.*
                FROM employees e
                WHERE e.id = @id
                ";
            return _db.Query<Employee>(sql, new { id }).FirstOrDefault();
        }

        internal Employee Create(Employee employeeData)
        {
            string sql = @"
             INSERT INTO employees
             (name)
             VALUES
             (@Name);
             ";
            int id = _db.ExecuteScalar<int>(sql, employeeData);
            employeeData.Id = id;
            return employeeData;
        }

        internal void Edit(Employee original)
        {
            string sql = @"
            UPDATE employees
            SET
             name = @Name
             WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Deleted(int id)
        {
            string sql = "DELETE FROM employees WHERE id = @Id";
            _db.Execute(sql, new { id });
        }
    }
}
