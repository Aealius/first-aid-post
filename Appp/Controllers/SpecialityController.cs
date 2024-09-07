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
    [Route("api/speciality")]
    public class SpecialityController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public SpecialityController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpGet("all")]
        public IEnumerable<Speciality> GetAllSpecialities()
        {
            var data = _dbContext.Specialities.ToList();
            return data;
        }
    }
}
