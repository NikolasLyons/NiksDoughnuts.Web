using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NiksDoughnuts.Web.Models;
using NiksDoughnuts.Web.Services;

namespace NiksDoughnuts.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoughnutsController : ControllerBase
    {
        private readonly DoughnutsService _ds;

        public DoughnutsController(DoughnutsService ds)
        {
            _ds = ds;
        }

        [HttpGet]
        public ActionResult<List<Doughnut>> GetDoughnuts()
        {
            try
            {
                List<Doughnut> doughnuts = _ds.GetAll();
                return Ok(doughnuts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Doughnut> GetDoughnutById(int id)
        {
            try
            {
                Doughnut doughtnut = _ds.GetById(id);
                return Ok(doughtnut);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<Doughnut> CreateDoughnut([FromBody] Doughnut doughnutData)
        {
            try
            {
                Doughnut newDoughnut = _ds.Create(doughnutData);
                return Ok(newDoughnut);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]

        public ActionResult<Doughnut> EditDoughnut(int id, [FromBody] Doughnut doughnutData)
        {
            try
            {
                Doughnut update = _ds.Edit(doughnutData);
                return Ok(update);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult<Doughnut> DeleteDoughnut(int id)
        {
            try
            {
                Doughnut deleted = _ds.Deleted(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
