using Dapper;
using Microsoft.AspNetCore.Mvc;
using NiksDoughnuts.Web.Models;
using System.Data;

namespace NiksDoughnuts.Web.Repositories
{
    public class DoughnutsRepository 
    {
        private readonly IDbConnection _db;
        public DoughnutsRepository(IDbConnection db)
        {
            _db = db;
        }
        public List<Doughnut> Get()
        {
            string sql = @"
             SELECT
            e.*,
             d.*
            FROM dounutsss d
            JOIN employees e On e.id = d.creatorId
               ";
            return _db.Query<Employee, Doughnut, Doughnut>(sql, (emp, dough) => {
                dough.Creator = emp;
                return dough;
            }).ToList();
        }
    
        public Doughnut Create(Doughnut doughnutData)
        {
            string sql = @"
             INSERT INTO dounutsss
            (doughnutsMade, creatorId)
            VALUES
            (@DoughnutsMade, @CreatorId);
            ";
            int id = _db.ExecuteScalar<int>(sql,doughnutData);
            doughnutData.Id = id;
            return doughnutData;
        }

        internal Doughnut GetById(int id)
        {
            string sql = @"
             SELECT
            e.*,
             d.*
            FROM dounutsss d
            JOIN employees e On e.id = d.creatorId
            WHERE d.id = @id
             ";
            return _db.Query<Employee, Doughnut, Doughnut>(sql, (emp, dough) => {
                dough.Creator = emp;
                return dough;
            }, new { id }).FirstOrDefault();
        }

        internal void Edit(Doughnut original)
        {
            string sql = @"
            UPDATE dounutsss
             SET
            doughnutsMade = @DoughnutsMade
             WHERE id = @Id
               ";
            _db.Execute(sql, original);
        }

        internal void Deleted(int id)
        {
            string sql = "DELETE FROM dounutsss WHERE id = @Id";
            _db.Execute(sql, new { id });
        }
    }
}
