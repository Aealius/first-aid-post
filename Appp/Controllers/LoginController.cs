using Appp;
using Appp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Appp.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public LoginController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User userLog)
        {
            var users = _dbContext.Users.ToList();
            var result = new User();
            result.UserId = -1;

            foreach (var user in users)
            {
                if (user.Login == userLog.Login && user.Pwd == userLog.Pwd)
                {
                    result.Login = user.Login;
                    result.Pwd = user.Pwd;
                    result.RoleId = user.RoleId;
                    result.UserId = user.UserId;
                    result.DoctorInitials = user.DoctorInitials;

                    return Ok(result);
                }
            }

            return Ok(result);
        }
    }


}
