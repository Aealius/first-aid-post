using Appp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Appp.Controllers
{
    [ApiController]
    [Route("api/medicalcard")]
    public class MedicalCardController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public MedicalCardController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public ActionResult<MedicalCardView> GetMedicalCardById(int id)
        {
            var medCardId = _dbContext.Students.FirstOrDefault(a => a.StudentId == id).MedicalcardId;

            var data = _dbContext.MedicalCards.Include(m => m.BloodType).Include(m => m.HealthGroup).FirstOrDefault(q => q.MedicalCardId == medCardId);

            var result = new MedicalCardView();
            if (data != null)
            {
                result.Height = data.Height;
                result.Weight = data.Weight;
                result.BloodTypeId = data.BloodTypeId;
                result.HealthGroupId = data.HealthGroupId;
                result.MedicalCardId = data.MedicalCardId;
                result.HealthGroupName = data.HealthGroup.Type;
                result.BloodTypeName = data.BloodType.Name;
            }

            return Ok(result);
        }
    }
}
