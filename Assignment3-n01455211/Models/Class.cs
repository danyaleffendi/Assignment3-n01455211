using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3_n01455211.Models
{
    public class Class
    {
        //Columns from the class table of our database
        public int ClassId;        
        public string Classname;
        public string Classcode;
        public DateTime Startdate;
        public DateTime Finishdate;        
        public int Teacherid;

        //Created to show teachername under the course show view
        public string Teachername;

        //parameter-less constructor function
        public Class() { }
    }
}