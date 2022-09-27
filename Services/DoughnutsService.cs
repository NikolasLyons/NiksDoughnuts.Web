using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NiksDoughnuts.Web.Models;
using NiksDoughnuts.Web.Repositories;

namespace NiksDoughnuts.Web.Services
{

    public class DoughnutsService
    {
        private readonly DoughnutsRepository _dr;

        public DoughnutsService(DoughnutsRepository dr)
        {
            _dr = dr;
        }

       
        internal Doughnut GetById(int id)
        {
            Doughnut found = _dr.GetById(id);
            if(found == null)
            {
                throw new Exception("invalid Id");
            }
            return found;
        }
        internal Doughnut Create(Doughnut doughnutData)
        {
            return _dr.Create(doughnutData);
        }

        internal Doughnut Edit(Doughnut doughnutData)
        {
           Doughnut original = GetById(doughnutData.Id);
            if(original.Id != doughnutData.Id)
            {
                throw new Exception("Invalid Id");
            }
            original.DoughnutsMade = doughnutData.DoughnutsMade ?? original.DoughnutsMade;
            _dr.Edit(original);
            return original;
        }
        internal Doughnut Deleted(int id)
        {
            Doughnut original = GetById(id);
            if (original.Id != id)
            {
                throw new Exception("Invalid Id");
            }
            _dr.Deleted(id);
            return original;
        }

        internal List<Doughnut> GetAll()
        {
            return _dr.Get();
        }
    }
}
