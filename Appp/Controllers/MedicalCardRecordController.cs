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
    [Route("api/medicalcardRecord")]
    public class MedicalCardRecordController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public MedicalCardRecordController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpGet("all")]
        public IEnumerable<MedicalCardRecord> GetMedicalCardRecordsById(int id)
        {
            var medCardId = _dbContext.Students.FirstOrDefault(a => a.StudentId == id).MedicalcardId;
            var data = _dbContext.MedicalCardRecords.Where(q => q.MedicalCardId == medCardId).ToList();

            return data;
        }
    }
}
