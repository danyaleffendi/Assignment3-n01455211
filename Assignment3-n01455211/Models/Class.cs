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
        public string Startdate;
        public string Finishdate;        
        public int Teacherid;

        //Created to show teachername under the course show view
        public string Teachername;
    }
}