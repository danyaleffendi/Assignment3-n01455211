﻿using System;
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
        // This project is done with the help of instructor Christine Bittle's Blog Project.
        // Resources used are Github blog project example and lecture videos. Accessed on 11 and 12 Nov. 2020.

        // The database context class which allows us to access School Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the teachers table of our school database.
        /// <summary>
        /// Returns Teacher Information
        /// </summary>
        /// <example>GET api/ClassData/ClassInfo</example>
        /// <returns>
        /// A list of Class
        /// </returns>
        [HttpGet]
        public IEnumerable<Class> ClassInfo()
        {
            //Creating connection with database
            MySqlConnection Conn = School.AccessDatabase();

            //Acivate connection between the web server and database
            Conn.Open();

            //Establish a new command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY to access columns from teacher table
            cmd.CommandText = "Select * from classes";


            //Incorporating SQL Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teacher Names
            List<Class> Class = new List<Class> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Get column information by the column name from teacher table
                int Classid = (int)ResultSet["classid"];
                string Classname = ResultSet["classname"].ToString();
                string Classcode = ResultSet["classcode"].ToString();
                string StartDate = ResultSet.GetDateTime("startdate").ToString("yyyy-MM-dd");
                string FinishDate = ResultSet.GetDateTime("finishdate").ToString("yyyy-MM-dd");
                int Teacherid = Convert.ToInt32(ResultSet["teacherid"]);

                Class NewClass = new Class();
                NewClass.ClassId = Classid;
                NewClass.Classname = Classname;
                NewClass.Classcode = Classcode;
                NewClass.Startdate = StartDate;
                NewClass.Finishdate = FinishDate;
                NewClass.Teacherid = Teacherid;

                //Adding Teacher Name to the List
                Class.Add(NewClass);
            }


            //Ending connection between the MySQL Database and the WebServer
            Conn.Close();

            //Returning the final list of teacher names
            return Class;
        }
        [HttpGet]
        public Class FindClass(int id)
        {
            Class NewClass = new Class();

            //Creating connection with database
            MySqlConnection Conn = School.AccessDatabase();

            //Acivate connection between the web server and database
            Conn.Open();

            //Establish a new command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY to access columns from teacher table
            cmd.CommandText = "Select classes.*, teachers.teacherfname, teachers.teacherlname from classes LEFT JOIN teachers ON classes.teacherid=teachers.teacherid WHERE classes.classid = " + id;

            //Incorporating SQL Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Get column information by the column name from teacher table
                int Classid = (int)ResultSet["classid"];
                int Teacherid = Convert.ToInt32(ResultSet["teacherid"]);
                string Classname = ResultSet["classname"].ToString();
                string Classcode = ResultSet["classcode"].ToString();
                string StartDate = ResultSet.GetDateTime("startdate").ToString("yyyy-MM-dd");
                string FinishDate = ResultSet.GetDateTime("finishdate").ToString("yyyy-MM-dd");
                string Teachername = ResultSet["teacherfname"].ToString() + " " + ResultSet["teacherlname"].ToString();

                NewClass.ClassId = Classid;
                NewClass.Classname = Classname;
                NewClass.Classcode = Classcode;
                NewClass.Startdate = StartDate;
                NewClass.Finishdate = FinishDate;
                NewClass.Teachername = Teachername;
                NewClass.Teacherid = Teacherid;
            }
                return NewClass;
            
        }

    }

}