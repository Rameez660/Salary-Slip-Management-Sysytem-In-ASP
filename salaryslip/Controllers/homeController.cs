using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using salaryslip.Models;
using salaryslip.ViewModel.Home;

namespace salaryslip.Controllers
{
    public class homeController : Controller
    {
        //
        // GET: /home/

        public ActionResult Index()
        {
            salaryViewModel studentVM = new salaryViewModel();
            List<salary> students = studentVM.personDetails();

            return View(students);
        
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(salary student)
        {
            if (ModelState.IsValid)
            {

                salaryViewModel studentVM = new salaryViewModel();
                studentVM.Addperson(student);
                return RedirectToAction("Index");
            }
            return View();
        }



        public ActionResult print(int id)
        {
            salaryViewModel studentVM = new salaryViewModel();
            salary student = studentVM.print(id);
            return View(student);
        }

        public ActionResult update(int id)
        {
            salaryViewModel studentVM = new salaryViewModel();
            salary student = studentVM.print(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult update(salary student)
        {
            if (ModelState.IsValid)
            {
                salaryViewModel studentVM = new salaryViewModel();
                studentVM.update(student);

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            salaryViewModel studentVM = new salaryViewModel();
            studentVM.Deleteperson(id);

            return RedirectToAction("Index");

        }














        
public ActionResult login()
{
    return View();
}
[HttpPost]
public ActionResult login(login login)
{
    if (ModelState.IsValid)
    {
        salaryViewModel studentVM = new salaryViewModel();
        studentVM.login(login);
        return RedirectToAction("Index");
    }

    return View();
}


    }
}
