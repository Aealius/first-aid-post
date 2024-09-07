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
    [Route("api/faculty")]
    public class FacultyController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public FacultyController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpGet("all")]
        public IEnumerable<Faculty> GetAllFaculties()
        {
            var data = _dbContext.Faculties.ToList();
            return data;
        }
    }
}
