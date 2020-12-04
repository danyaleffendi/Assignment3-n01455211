using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment3_n01455211.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;


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
        [Route("api/AuthorData/ListAuthors/{SearchKey?}")]
        public IEnumerable<Teacher> TeacherInfo(string SearchKey = null)
        {
            //Creating connection with database
            MySqlConnection Conn = School.AccessDatabase();

            //Acivate connection between the web server and database
            Conn.Open();

            //Establish a new command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY to access columns from teacher table
            cmd.CommandText = "Select * from Teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key)";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

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
                DateTime HireDate;
                DateTime.TryParse(ResultSet["HireDate"].ToString(), out HireDate);
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
               // int Classid = (int)ResultSet["classid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate;
                DateTime.TryParse(ResultSet["HireDate"].ToString(), out HireDate);
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
               // NewTeacher.Classid = Classid;
            }
            Conn.Close();

            return NewTeacher;
        }

        /// <summary>
        /// 
        /// Removes a Teacher from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id">The ID of the teacher to remove</param>
        /// <example>POST : /api/TeacherData/DeleteTeacher/3</example>
        /// <returns>Does not return anything.</returns>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();
            //Open the connection between the web server and database
            Conn.Open();
            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();
            //SQL QUERY
            cmd.CommandText = "Delete from teachers WHERE teacherid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
        /// <summary>
        /// Adds an Teacher to the MySQL Database.
        /// </summary>
        /// <param name="NewTeacher">An object with fields that map to the columns of the author's table. Non-Deterministic.</param>
        /// <example>
        /// POST api/TeacherData/AddTeacher 
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"TeacherFname":"Christine",
        ///	"TeacherLname":"Bittle",
        ///	"EmployeeNumber":"Likes Coding!",
        ///	"Salary":"christine@test.ca"
        /// }
        /// </example>
        [HttpPost] 
        public void AddTeacher([FromBody] Teacher NewTeacher)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            Debug.WriteLine(NewTeacher.TeacherFname);

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "insert into teachers (teacherfname, teacherlname, employeenumber, hiredate, salary) values (@TeacherFname,@TeacherLname,@EmployeeNumber, CURRENT_DATE(), @Salary)";
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", NewTeacher.EmployeeNumber);
            cmd.Parameters.AddWithValue("@Salary", NewTeacher.Salary);
            //cmd.Parameters.AddWithValue("@Classcode", NewTeacher.Classcode);
            //cmd.Parameters.AddWithValue("@Classname", NewTeacher.Classname);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            Conn.Close();


        }

    }
}
