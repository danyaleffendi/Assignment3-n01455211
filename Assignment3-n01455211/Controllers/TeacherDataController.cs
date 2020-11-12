using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment3_n01455211.Models;
using MySql.Data.MySqlClient;

namespace Assignment3_n01455211.Controllers
{
    public class TeacherDataController : ApiController
    {
        // This project is done with the help of instructor Christine Bittle's Blog Project.
        // Resources used are Github blog project example and lecture videos. Accessed on 11 and 12 Nov. 2020.
        // Some help also taken from fellow students especially proper syntax for GetDateTime

        // The database context class which allows us to access School Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the teachers table of our school database.
        /// <summary>
        /// Returns Teacher Information
        /// </summary>
        /// <example>GET api/TeacherData/TeacherInfo</example>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> TeacherInfo()
        {
            //Creating connection with database
            MySqlConnection Conn = School.AccessDatabase();

            //Acivate connection between the web server and database
            Conn.Open();

            //Establish a new command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY to access columns from teacher table
            cmd.CommandText = "Select * from teachers";
            

            //Incorporating SQL Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teacher Names
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Get column information by the column name from teacher table
                int TeacherId = (int)ResultSet["teacherid"];                
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                string HireDate = ResultSet.GetDateTime("hiredate").ToString("yyyy-MM-dd");
                string Salary = ResultSet["salary"].ToString();                

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
                
                //Adding Teacher Name to the List
                Teachers.Add(NewTeacher);
            }
        

            //Ending connection between the MySQL Database and the WebServer
            Conn.Close();

            //Returning the final list of teacher names
            return Teachers;
        }
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Creating connection with database
            MySqlConnection Conn = School.AccessDatabase();

            //Acivate connection between the web server and database
            Conn.Open();

            //Establish a new command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY to access columns from teacher table
            cmd.CommandText = "Select teachers.*, classes.classcode, classes.classname, classes.classid from Teachers LEFT JOIN classes ON teachers.teacherid=classes.teacherid where teachers.Teacherid = " + id;

            //Incorporating SQL Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Get column information by the column name from teacher table
                int TeacherId = (int)ResultSet["teacherid"];
                int Classid = (int)ResultSet["classid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                string HireDate = ResultSet.GetDateTime("hiredate").ToString("yyyy-MM-dd");
                string Salary = ResultSet["salary"].ToString();                
                string Classname = ResultSet["classname"].ToString();
                string Classcode = ResultSet["classcode"].ToString();
                

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
                NewTeacher.Classname = Classname;
                NewTeacher.Classcode = Classcode;
                NewTeacher.Classid = Classid;
            }

            return NewTeacher;
        }

    }
}
