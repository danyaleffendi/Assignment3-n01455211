using System;
using System.Collections.Generic;
using System.Linq;
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
        public string HireDate;
        public string Salary;

        //Created to show course name under the teacher show view
        public string Classname;
        public string Classcode;

        //Created to link course name to respective class show view
        public int Classid;

    }
}