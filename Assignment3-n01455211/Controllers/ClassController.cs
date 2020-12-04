using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3_n01455211.Models;
using System.Diagnostics;

namespace Assignment3_n01455211.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Class/List
        public ActionResult List(string SearchKey = null)
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Class> Classes = controller.ClassInfo(SearchKey);
            return View(Classes);
        }

        //GET : /Class/Show/{id}
        public ActionResult Show(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class SelectedClass = controller.FindClass(id);


            return View(SelectedClass);
        }

        //GET : /Class/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class NewClass = controller.FindClass(id);


            return View(NewClass);
        }

        //POST : /Class/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ClassDataController controller = new ClassDataController();
            controller.DeleteClass(id);
            return RedirectToAction("List");
        }

        //GET : /Class/New
        public ActionResult New()
        {
            return View();
        }

        //GET : /Class/Ajax_New
        public ActionResult Ajax_New()
        {
            return View();

        }

        //POST : /Class/Create
        [HttpPost]
        public ActionResult Create(string Classcode, string Classname, DateTime Startdate, DateTime Finishdate, int Teacherid)
        {
            //Identify that this method is running
            //Identify the inputs provided from the form

            Debug.WriteLine("Accessed the Create Method to add Class!");
            Debug.WriteLine(Classname);
            Debug.WriteLine(Classcode);
            Debug.WriteLine(Startdate);
            Debug.WriteLine(Finishdate);

            Class NewClass = new Class();
            NewClass.Classcode = Classcode;
            NewClass.Classname = Classname;
            NewClass.Startdate = Startdate;
            NewClass.Finishdate = Finishdate;
            NewClass.Teacherid = Teacherid;

            ClassDataController controller = new ClassDataController();
            controller.AddClass(NewClass);

            return RedirectToAction("List");
        }
    }
}
