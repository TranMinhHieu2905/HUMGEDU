using EDUHUMG.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EDUHUMG.Common.ClassCommon;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDUHUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucController : ControllerBase
    {
    
        [HttpGet]
        public IEnumerable<DanhmucChicoten> Get()
        {

            HUMGEDUContext context = new HUMGEDUContext();
            List<Danhmuc> danhmucs = context.Danhmucs.ToList();

            IEnumerable<DanhmucChicoten> ketqua = (from d in danhmucs select new DanhmucChicoten() { tendanhmuc = d.Tendanhmuc });
            return ketqua;
        }
        [HttpGet("timdm/{id}")]
        public IEnumerable<Danhmuc> Timdanhmuc(int id)
        {
            HUMGEDUContext context = new HUMGEDUContext();
            List<Danhmuc> danhmucs = context.Danhmucs.ToList();
            IEnumerable<Danhmuc> ketqua = from d in danhmucs
                                          where d.Iddanhmuc == id
                                          select d;                              ;
            return ketqua;
        }

        [HttpGet("xoadm/{id}")]
        public loginStatus Xoadm(int id)
        {
            loginStatus status = new loginStatus();
            HUMGEDUContext context = new HUMGEDUContext();
            List<Danhmuc> danhmucs = context.Danhmucs.ToList();
            Danhmuc ketqua = context.Danhmucs.Single(x => x.Iddanhmuc == id);
            if(ketqua!= null)
            {
                context.Danhmucs.Remove(ketqua);
                context.SaveChanges();
                status.status = true;
                status.message = "success";
                status.code = 200;


            }
            else
            {
                status.status = false;
                status.message = "fail";
                status.code = 401;
            }

            return status;
           
        }

        // POST api/<DanhmucController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DanhmucController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DanhmucController>/5
      
    }
}
