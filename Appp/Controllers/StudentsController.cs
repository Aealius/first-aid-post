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
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        UniversityFirstAidPostContext _dbContext;

        public StudentsController(UniversityFirstAidPostContext context)
        {
            _dbContext = context;
        }

        [HttpGet("all")]
        public IEnumerable<StudentView> GetAllSellers(string searchLine)
        {
            var data = _dbContext.Students.Include(s => s.Speciality).Include(s => s.Faculty).Include(s => s.Group).ToList();

            List<Student> result;
            if (searchLine != null)
            {
                result = new List<Student>();

                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].Name != null && data[i].Name.IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                    if (data[i].Surname != null && data[i].Surname.IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                    if (data[i].Lastname != null && data[i].Lastname.IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                    if (data[i].Group.Name != null && data[i].Group.Name.IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                    if (data[i].Faculty.Name != null && data[i].Faculty.Name.IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                    if (data[i].Speciality.Name != null && data[i].Speciality.Name.IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                    if (data[i].BirthDate.ToString().IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                    if (data[i].EnrollDate.ToString().IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                    if (data[i].ExpulsionDate.ToString().IndexOf(searchLine) != -1)
                    {
                        if (!result.Contains(data[i]))
                            result.Add(data[i]);
                    }
                }
            }
            else
            {
                result = data;
            }

            var viewModels = new List<StudentView>();
            foreach (var res in result)
            {
                var view = new StudentView();
                view.StudentId = res.StudentId;
                view.Name = res.Name;
                view.Surname = res.Surname;
                view.Lastname = res.Lastname;
                view.BirthDate = res.BirthDate;
                view.ExpulsionDate = res.ExpulsionDate;
                view.EnrollDate = res.EnrollDate;
                view.Sex = res.Sex;
                view.GroupId = res.GroupId;
                view.FacultyId = res.FacultyId;
                view.SpecialityId = res.SpecialityId;
                view.MedicalcardId = res.MedicalcardId;
                view.FacultyName = res.Faculty.Name;
                view.GroupName = res.Group.Name;
                view.SpecialityName = res.Speciality.Name;

                viewModels.Add(view);
            }

            return viewModels;
        }

        [HttpDelete("delete")]
        public IActionResult DeleteData(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Student data)
        {
            data.BirthDate = data.BirthDate.AddHours(3);
            data.EnrollDate = data.EnrollDate.AddHours(3);
            if (data.ExpulsionDate != null)
            {
                data.ExpulsionDate = ((DateTime)data.ExpulsionDate).AddHours(3);
            }
          

            if (data.StudentId == 0)
            {
                _dbContext.Students.Add(data);
            }
            else
            {
                var student = _dbContext.Students.FirstOrDefault(x => x.StudentId == data.StudentId);

                student.Name = data.Name;
                student.Surname = data.Surname;
                student.Lastname = data.Lastname;
                student.BirthDate = data.BirthDate;
                student.EnrollDate = data.EnrollDate;
                student.ExpulsionDate = data.ExpulsionDate;
                student.FacultyId = data.FacultyId;
                student.GroupId = data.GroupId;
                student.SpecialityId = data.SpecialityId;
                student.Sex = data.Sex;

                _dbContext.Students.Update(student);
            }
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
