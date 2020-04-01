using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using salaryslip.Models;

namespace salaryslip.ViewModel.Home
{
    public class salaryViewModel
    {
        public List<salary> personDetails()
        {
            List<salary> students = new List<salary>();
            string connString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("persondata", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        salary student = new salary();
                        student.id = Convert.ToInt16(reader["id"]);
                        student.name = reader["name"].ToString();
                        student.employerid = reader["employerid"].ToString();
                        student.title = reader["title"].ToString();
                        student.depart = reader["depart"].ToString();
                        student.accno = reader["accno"].ToString();
                        student.basicsalary = Convert.ToInt32(reader["basicsalary"]);
                        student.mealallow = Convert.ToInt32(reader["mealallow"]);
                        student.transportallow = Convert.ToInt32(reader["transportallow"]);
                        student.medicalallow = Convert.ToInt32(reader["medicalallow"]);
                        student.tax = Convert.ToInt32(reader["tax"]);
                        student.total = Convert.ToInt32(reader["medicalallow"]) + Convert.ToInt32(reader["transportallow"]) + Convert.ToInt32(reader["mealallow"]) + Convert.ToInt32(reader["basicsalary"]) + -Convert.ToInt32(reader["tax"]);



                        students.Add(student);
                    }
                }
            }
            return students;
        }

        internal void Addperson(salary student)
        {
            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("adddata", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@name", student.name);
                    cmd.Parameters.AddWithValue("@employerid", student.employerid);
                    cmd.Parameters.AddWithValue("@title", student.title);
                    cmd.Parameters.AddWithValue("@depart", student.depart);
                    cmd.Parameters.AddWithValue("@accno", student.accno);
                    cmd.Parameters.AddWithValue("@basicsalary", student.basicsalary);
                    cmd.Parameters.AddWithValue("@mealallow", student.mealallow);
                    cmd.Parameters.AddWithValue("@transportallow", student.transportallow);
                    cmd.Parameters.AddWithValue("@medicalallow", student.medicalallow);
                    cmd.Parameters.AddWithValue("@tax", student.tax);
                    cmd.Parameters.AddWithValue("@total", student.total);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal salary print(int id)
        {
            salary student = new salary();
            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("printdetail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    student.id = Convert.ToInt32(reader["id"]);
                    student.name = reader["Name"].ToString();
                    student.employerid = reader["employerid"].ToString();
                    student.title = reader["title"].ToString();
                    student.depart = reader["depart"].ToString();
                    student.accno = reader["accno"].ToString();
                    student.basicsalary = Convert.ToInt32(reader["basicsalary"]);
                    student.mealallow = Convert.ToInt32(reader["mealallow"]);
                    student.transportallow = Convert.ToInt32(reader["transportallow"]);
                    student.medicalallow = Convert.ToInt32(reader["medicalallow"]);
                    student.tax = Convert.ToInt32(reader["tax"]);
                    student.total = Convert.ToInt32(reader["medicalallow"]) + Convert.ToInt32(reader["transportallow"]) + Convert.ToInt32(reader["mealallow"]) + Convert.ToInt32(reader["basicsalary"])- Convert.ToInt32(reader["tax"]);




                }

            }
            return student;
        }


        internal void update(salary student)
        {

            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("updatee", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", student.id);
                    cmd.Parameters.AddWithValue("@name", student.name);
                    cmd.Parameters.AddWithValue("@employerid", student.employerid);
                    cmd.Parameters.AddWithValue("@title", student.title);
                    cmd.Parameters.AddWithValue("@depart", student.depart);
                    cmd.Parameters.AddWithValue("@accno", student.accno);
                    cmd.Parameters.AddWithValue("@basicsalary", student.basicsalary);
                    cmd.Parameters.AddWithValue("@mealallow", student.mealallow);
                    cmd.Parameters.AddWithValue("@transportallow", student.transportallow);
                    cmd.Parameters.AddWithValue("@medicalallow", student.medicalallow);
                    cmd.Parameters.AddWithValue("@tax", student.tax);
                    cmd.Parameters.AddWithValue("@total", student.total);

                    cmd.ExecuteNonQuery();

                }
            }
        }











        internal void Deleteperson(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("deleteperson", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        internal void login(login login)
        {
            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("logg", conn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@username", login.username);
                    cmd.Parameters.AddWithValue("@password", login.password);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}