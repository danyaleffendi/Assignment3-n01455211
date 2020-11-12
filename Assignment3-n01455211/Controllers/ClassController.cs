using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3_n01455211.Models;

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
        public ActionResult List()
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Class> Clases = controller.ClassInfo();
            return View(Classes);
        }

        //GET : /Class/Show/{id}
        public ActionResult Show(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class NewClass = controller.FindClass(id);


            return View(NewClass);
        }

    }
}
