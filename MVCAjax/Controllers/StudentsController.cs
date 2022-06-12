using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using MVCAjax.Data;
using Service;
using Domain;
using MVCAjax.Models;

namespace MVCAjax.Controllers
{
    public class StudentsController : Controller
    {
        private StudentService service = new StudentService();

        // GET: Students
        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             studentID = c.studentID,
                             studentName = c.studentName,
                             studentAddress = c.studentAddress
                         }).ToList();
            return View(model);
        }

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult createStudent(Student std)
        {
            service.Insert(std);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}
