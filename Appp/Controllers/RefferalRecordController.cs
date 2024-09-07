using Appp;
using Appp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appp.Controllers
{
    [Route("api/refferalrecord")]
    [ApiController]
    public class RefferalRecordController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;
        public RefferalRecordController(UniversityFirstAidPostContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("all")]
        public IEnumerable<RefferalRecord> Get(int id)
        {
            var data = _dbContext.RefferalRecords.Where(q => q.MedicalCardId == _dbContext.Students.FirstOrDefault(x => x.StudentId == id).MedicalcardId).ToList();
            return data;
        }
    }
}
