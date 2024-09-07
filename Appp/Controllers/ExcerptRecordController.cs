using Appp;
using Appp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appp.Controllers
{
    [Route("api/excerptrecord")]
    [ApiController]
    public class ExcerptRecordController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;
        public ExcerptRecordController(UniversityFirstAidPostContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("all")]
        public IEnumerable<ExcerptRecord> Get(int id)
        {
            var data = _dbContext.ExcerptRecords.Where(q => q.MedicalCardId == _dbContext.Students.FirstOrDefault(x => x.StudentId == id).MedicalcardId).ToList();
            return data;
        }

    }
}
