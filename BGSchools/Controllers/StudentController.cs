using BGSchools.Data;
using BGSchools.Entities;
using BGSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace BGSchools.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var context = new RegistrationDbContext();
            var studentList = context.Student.ToList();

            var studentRegistrationList = new List<StudentRegistration>();
            foreach (var student in studentList)
            {
                studentRegistrationList.Add(new StudentRegistration()
                {
                    Name = student.Name,
                    Email = student.Email,
                    RetypeEmail = student.RetypeEmail,
                    Phone = student.Phone,
                    Age = student.Age,
                    DateOfBirth = student.DateOfBirth,
                    Address = student.Address,
                    City = student.City,
                    Id = student.Id,
                });
            }

            return View(studentRegistrationList);
        }


        [HttpGet]
        public ActionResult RegisterStudent()
        {
            var context = new RegistrationDbContext();

            var studentRegistration = new StudentRegistration();

            return View(studentRegistration);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult RegisterStudent(StudentRegistration studentRegistration)
        {
            if (!ModelState.IsValid)
            {
                return View(studentRegistration);
            }

            var context = new RegistrationDbContext();
            var studentEntity = new Student()
            {
                Name = studentRegistration.Name,
                Email = studentRegistration.Email,
                RetypeEmail = studentRegistration.RetypeEmail,
                Phone = studentRegistration.Phone,
                Age = studentRegistration.Age,
                DateOfBirth = studentRegistration.DateOfBirth,
                Address = studentRegistration.Address,
                City = studentRegistration.City,
                Id = studentRegistration.Id,
            };
            context.Student.Add(studentEntity);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var context = new RegistrationDbContext();
            var student = context.Student.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            var studentRegistration = new StudentRegistration()
            {
                Name = student.Name,
                Email = student.Email,
                RetypeEmail = student.RetypeEmail,
                Phone = student.Phone,
                Age = student.Age,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                City = student.City,
                Id = student.Id,

            };
            return View(studentRegistration);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(StudentRegistration studentRegistration)
        {
            if (!ModelState.IsValid)
            {
                return View(studentRegistration);
            }
            var context = new RegistrationDbContext();
            var studentEntity = context.Student.Find(studentRegistration.Id);// to check if student is registered
            if (studentEntity == null)
            {
                return HttpNotFound();
            }
            //lets update it
            studentEntity.Name = studentRegistration.Name;
            studentEntity.Email = studentRegistration.Email;
            studentEntity.RetypeEmail = studentRegistration.RetypeEmail;
            studentEntity.Phone = studentRegistration.Phone;
            studentEntity.Age = studentRegistration.Age;
            studentEntity.Address = studentRegistration.Address;
            studentEntity.City = studentRegistration.City;
            studentEntity.Id = studentRegistration.Id;

            context.SaveChanges();//save to db

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult StudentRecord(int id)
        {
            var context = new RegistrationDbContext();
            var student = context.Student.Find(id);
            if(student == null)
            {
                return HttpNotFound(nameof(student));
            }
            //Create a register to pass the record to thr view
            var studentModel = new StudentRegistration
            {
                Name = student.Name,
                Email = student.Email,
                RetypeEmail = student.RetypeEmail,
                Phone = student.Phone,
                Age = student.Age,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                City = student.City,
                Id = student.Id,

            };
            return View(studentModel);
        }
        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            var context = new RegistrationDbContext();
            var studentEntity = context.Student.Find(id);
            if (studentEntity == null)
            {
                return HttpNotFound();
            }
            context.Student.Remove(studentEntity);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
    