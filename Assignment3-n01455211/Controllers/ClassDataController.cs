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
    public class ClassDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
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
        public IEnumerable<Class> ClassInfo()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Author Names
            List<Class> Classes = new List<Class> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = (int)ResultSet["ClassId"];
                int TeacherId = (int)ResultSet["TeacherId"];
                string ClassCode = ResultSet["ClassCode"].ToString();
                string ClassName = ResultSet["ClassName"].ToString();
                string StartDate = ResultSet["StartDate"].ToString();
                string FinishDate = ResultSet["FinishDate"].ToString();

                Class NewClass = new Class();
                NewClass.ClassId = ClassId;
                NewClass.TeacherId = TeacherId;
                NewClass.ClassCode = ClassCode;
                NewClass.ClassName = ClassName;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;

                //Add the Author Name to the List
                Classes.Add(NewClass);
            }


            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Classes;
        }
        [HttpGet]
        public Class FindClass(int id)
        {
            Class NewClass = new Class();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Classes where Classid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = (int)ResultSet["ClassId"];
                int TeacherId = (int)ResultSet["TeacherId"];
                string ClassCode = ResultSet["ClassCode"].ToString();
                string ClassName = ResultSet["ClassName"].ToString();
                string StartDate = ResultSet["StartDate"].ToString();
                string FinishDate = ResultSet["FinishDate"].ToString();
                
                NewClass.ClassId = ClassId;
                NewClass.TeacherId = TeacherId;
                NewClass.ClassCode = ClassCode;
                NewClass.ClassName = ClassName;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
            }


            return NewClass;
        }

    }
}
