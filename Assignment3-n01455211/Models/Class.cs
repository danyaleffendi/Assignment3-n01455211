using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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

        public bool IsValid()
        {
            bool valid = true;

            if (Classname == null || Classcode == null || Startdate == null || Finishdate == null)
            {
                //Base validation to check if the fields are entered.
                valid = false;
            }
            else
            {
                //Validation for fields to make sure they meet server constraints
                if (Classname.Length < 2 || Classname.Length > 255) valid = false;
                Regex ClasscodeCheck = new Regex(@"^/\w{4}\d{4}/$");
                if (!ClasscodeCheck.IsMatch(Classcode)) valid = false;
            }
            Debug.WriteLine("The model validity is : " + valid);

            return valid;
        }


        //parameter-less constructor function
        public Class() { }
    }
}