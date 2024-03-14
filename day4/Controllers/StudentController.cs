using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Mvc;
using day4.Models;

namespace day4.Controllers
{
    public class StudentController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString;

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName)";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                   
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            List<Student> studentList = new List<Student>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Student";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        studentList.Add(new Student
                        {
                           
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            
                        });
                    }
                }
            }
            return View(studentList);
        }
    }
}