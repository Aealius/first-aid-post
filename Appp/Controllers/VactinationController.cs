using Appp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Appp.Controllers
{
    [ApiController]
    [Route("api/vactination")]
    public class VactinationController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public VactinationController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpGet("all")]
        public IEnumerable<VaccinationCardRecordView> Get(int id)
        {
            var data = _dbContext.VaccinationCardRecords.Include(v => v.Infection).Where(q => q.MedicalCardId == _dbContext.Students.FirstOrDefault(x => x.StudentId == id).MedicalcardId).ToList();

            var result = new List<VaccinationCardRecordView>();
            foreach (var item in data)
            {
                var res = new VaccinationCardRecordView();

                res.VaccardRecordId = item.VaccardRecordId;
                res.MedicalCardId = item.MedicalCardId;
                res.Inoculation = item.Inoculation;
                res.Vaccine = item.Vaccine;
                res.Series = item.Series;
                res.Dose = item.Dose;
                res.ImmuneWay = item.ImmuneWay;
                res.ImmuneDate = item.ImmuneDate;
                res.Reactions = item.Reactions;
                res.InfectionId = item.InfectionId;
                res.InfectionName = item.Infection.Name;

                result.Add(res);
            }

            return result;
        }
    }
}
