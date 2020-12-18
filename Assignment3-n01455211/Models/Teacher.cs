using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Assignment3_n01455211.Models
{
    public class Teacher
    {        
        //Columns from the Teacher table of our database
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public string Salary;

        //Created to show course name under the teacher show view
        public string Classname;
        public string Classcode;

        //Created to link course name to respective class show view
        public int Classid;

        public bool IsValid()
        {
            bool valid = true;

            if (TeacherFname == null || TeacherLname == null || EmployeeNumber == null || Salary == null)
            {
                //Base validation to check if the fields are entered.
                valid = false;
            }
            else
            {
                //Validation for fields to make sure they meet server constraints
                if (TeacherFname.Length < 2 || TeacherFname.Length > 255) valid = false;
                if (TeacherLname.Length < 2 || TeacherLname.Length > 255) valid = false;

                Regex EmployeeNumberCheck = new Regex(@"^/\w\d\d\d/$");
                if (!EmployeeNumberCheck.IsMatch(EmployeeNumber)) valid = false;
            }
            Debug.WriteLine("The model validity is : " + valid);

            return valid;
        }



        //parameter-less constructor function
        public Teacher() { }
    }
}