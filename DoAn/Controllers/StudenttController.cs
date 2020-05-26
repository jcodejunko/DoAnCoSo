using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class StudenttController : Controller
    {
        // GET: Studentt
        public ActionResult Index()
        {
            StudentList strStu = new StudentList();
            List<StudentManager> obj = strStu.getStudents(string.Empty);
            return View();
        }
    }
}