using Appp;
using Appp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appp.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class UniversityController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public UniversityController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpGet("all")]
        public IEnumerable<Group> GetAllGroups()
        {
            var data = _dbContext.Groups.ToList();
            return data;
        }
    }
}
