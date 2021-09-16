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
    public class LoginController : ControllerBase
    {
        // GET: api/<LoginController>
        [HttpPost]
        public IEnumerable<Taikhoan> Post()
        {
            //using ( var context = new HUMGEDUContext())
            // {
            //     return context.Taikhoans.ToList();

            // }

            HUMGEDUContext context = new HUMGEDUContext();
            return context.Taikhoans.ToList();
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost("layuser"), FormatFilter]
        public IEnumerable<Taikhoan> Post([FromForm] layuser parameter)
        {
            HUMGEDUContext context = new HUMGEDUContext();

           List<Taikhoan>  ketqua = new List<Taikhoan>();
            List<Taikhoan> taikhoans =  context.Taikhoans.ToList();

            //C1
            int checkLoginSuccess = taikhoans.Where(tk => tk.Username == parameter.user && tk.Password == parameter.pass).Count();

           /* //C2
            int checkLoginSuccess2 = 0;
            foreach (Taikhoan tk in taikhoans)
            {
                if (tk.Username == parameter.user && tk.Password == parameter.pass)
                {
                    checkLoginSuccess2++;
                }
            }*/

            if (checkLoginSuccess > 0)
            {
                ketqua = taikhoans.Where(tk => tk.Iduser == parameter.idcanlay).ToList();

            }
            else
            {
                // không có gì
            }

            return ketqua;


        }

        [HttpPost("login"), FormatFilter]
        public loginStatus Posst([FromForm] layuser parameter)
        {
            HUMGEDUContext context = new HUMGEDUContext();
            List<Taikhoan> taikhoans = context.Taikhoans.ToList();

            loginStatus status = new loginStatus();



            int checkLoginSuccess = taikhoans.Where(tk => tk.Username == parameter.user && tk.Password == parameter.pass).Count();

            if (checkLoginSuccess > 0)
            {
                status.status = true;
                status.message = "success";
                status.code = 200;
                status.data = taikhoans;


            }
            else
            {
                status.status = false;
                status.message = "fail";
                status.code = 401;
            }

            return status;


        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
