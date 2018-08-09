using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDMVC.Models;

namespace CRUDMVC.Controllers
{
    public class SLKController : ApiController
    {

        public IHttpActionResult GetAllStudents(bool includeDetail = false)
        {
            IList<DataViewModel> students = null;

            using (var ctx = new SLKDatabaseEntities())
            {
                students = ctx.registrations
                            .Select(s => new DataViewModel()
                            {
                                SlNo = s.SlNo,
                                UserName = s.UserName,
                                EmailId = s.EmailId,
                                Password = s.Password,
                                ConfirmPassword = s.ConfirmPassword,
                                //Detail = s.details == null || includeDetail == false ? null : new DetailViewModel()
                                //{
                                //    UserId = s.details.UserId,
                                //    FirstName = s.details.FirstName,
                                //    MiddleName = s.details.MiddleName,
                                //    LastName = s.details.LastName,
                                //    PhoneNumber = s.details.PhoneNumber,
                                //    Gender = s.details.Gender,
                                //    DateOfBirth = s.details.DateOfBirth,
                                //    EmailID = s.details.EmailID,
                                //    Address = s.details.Address,
                                //    City = s.details.City,
                                //    ZipCode = s.details.ZipCode,
                                //    State = s.details.State,
                                //    Country = s.details.Country,
                                //    Department = s.details.Department,
                                //    TenthBoard = s.details.TenthBoard,
                                //    TenthMarks = s.details.TenthMarks,
                                //    TwelfthBoard = s.details.TwelfthBoard,
                                //    TwelfthMarks = s.details.TwelfthMarks,
                                //}

                            }).ToList<DataViewModel>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpPost]
        //[AcceptVerbs("POST")]
        public IHttpActionResult Post1(DataViewModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new SLKDatabaseEntities())
            {
                ctx.registrations.Add(new registration()
                {
                    SlNo = student.SlNo,
                    UserName = student.UserName,
                    EmailId = student.EmailId,
                    Password = student.Password,
                    ConfirmPassword = student.ConfirmPassword,
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put1(DataViewModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new SLKDatabaseEntities())
            {
                var existingStudent = ctx.registrations.Where(s => s.EmailId == student.EmailId).FirstOrDefault<registration>();

                if (existingStudent != null)
                {
                    existingStudent.UserName = student.UserName;
                    existingStudent.EmailId = student.EmailId;
                    existingStudent.Password = student.Password;
                    existingStudent.ConfirmPassword = student.ConfirmPassword;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(student);
        }

        //public IHttpActionResult Delete(int id)
        //{
        //    if (id <= 0)
        //        return BadRequest("Not a valid student id");

        //    using (var ctx = new SLKDatabaseEntities())
        //    {
        //        var student = ctx.registrations.Where(s => s.SlNo == id).FirstOrDefault();

        //        ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
        //        ctx.SaveChanges();
        //    }

        //    return Ok();
        //}


    }
}
