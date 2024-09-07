using Appp;
using Appp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appp.Controllers
{
    [Route("api/certificate")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;
        public CertificateController(UniversityFirstAidPostContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("all")]
        public IEnumerable<CertificateView> Get(int id)
        {
            var data = _dbContext.Certificates.Include(c => c.Doctor).Where(q => q.StudentId == id).ToList();

            var result = new List<CertificateView>();
            foreach (var item in data)
            {
                var res = new CertificateView();

                res.Dianosis = item.Dianosis;
                res.FromDate = item.FromDate;
                res.ToDate = item.ToDate;
                res.Note = item.Note;
                res.DoctorName = item.Doctor.DoctorInitials;

                result.Add(res);
            }

            return result;
        }

    }
}
