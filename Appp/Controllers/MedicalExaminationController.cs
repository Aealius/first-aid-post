using Appp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Appp.Controllers
{
    [ApiController]
    [Route("api/medexam")]
    public class MedicalExaminationController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public MedicalExaminationController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpGet("all")]
        public IEnumerable<MedicalExamination> GetAll(int id)
        {
            var data = _dbContext.MedicalExaminations.Where(a => a.StudentId == id).ToList();

            return data;
        }
    }
}
