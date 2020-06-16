using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegBackEndNew.DataAccess;
using RegBackEndNew.Models;

namespace RegBackEndNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpGet]
        [Route("Register")]

        public List<Register> LoadReg()
        {
            List<Register> register = RegisterManage.GetAllRegister();
            return register;
        }

        [HttpGet]
        [Route("Register")]

        public IActionResult AddRegister(Register register)
        {
            try
            {
                if (RegisterManage.InsertReg(register) == true)
                {
                    return Ok(new { Message = "Inserted" });


                }
                else
                {
                    return BadRequest(new { Message = "Erorr.." });
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}