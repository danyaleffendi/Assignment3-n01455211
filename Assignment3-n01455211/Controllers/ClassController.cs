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

        /// <summary>
        /// Directs to a dynamically generated "Course Update" Page. Takes information from the database.
        /// </summary>
        /// <param name="id">Id of the Course</param>
        /// <returns>A dynamic "Update Course" webpage which provides the current information of the Course and asks the user for new information as part of a form.</returns>
        /// <example>GET : /Class/Update/9</example>
        public ActionResult Update(int id)
            {
                ClassDataController controller = new ClassDataController();
                Class SelectedClass = controller.FindClass(id);

            return View(SelectedClass);
            }

            public ActionResult Ajax_Update(int id)
            {
                ClassDataController controller = new ClassDataController();
                Class SelectedClass = controller.FindClass(id);

                return View(SelectedClass);
            }


        /// <summary>
        /// Receives a POST request containing information about an existing Course in the system, with new values. Conveys this information to the API, and redirects to the "Course Show" page of our updated Course.
        /// </summary>
        /// <param name="id">Id of the Course to update</param>
        /// <param name="Classname">The updated Course name </param>
        /// <param name="Classcode">The updated Course code </param>
        /// <param name="Startdate">The updated start date of the course.</param>
        /// <param name="Finishdate">The updated finish date of the course.</param>
        /// <param name="Teacherid">The updated teacher id of the course.</param>
        /// <returns>A dynamic webpage which provides the current information of the course.</returns>
        /// <example>
        /// POST : /Class/Update/10
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"Classcode":"HTTP6101",
        ///	"Classname":"Technical SEO",
        ///	"Startdate":"1/1/2021",
        ///	"Finishdate":"31/1/2012"
        ///	"Teacherid":"12"
        /// }
        /// </example>
        [HttpPost]
            public ActionResult Update(int id, string Classcode, string Classname, DateTime Startdate, DateTime Finishdate, int Teacherid)
            {
                Class ClassInfo = new Class();
            ClassInfo.Classcode = Classcode;
            ClassInfo.Classname = Classname;
            ClassInfo.Startdate = Startdate;
            ClassInfo.Finishdate = Finishdate;
            ClassInfo.Teacherid = Teacherid;

                ClassDataController controller = new ClassDataController();
                controller.Update(id, ClassInfo);

                return RedirectToAction("Show/" + id);
            }
        }
    }
