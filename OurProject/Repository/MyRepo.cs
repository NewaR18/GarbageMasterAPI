using OurProject.Model;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
namespace OurProject.Repository
{
    public class MyRepo : ConnRepo
    {
        public string RegisterUser(Register r1)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RegisterUser";
                using (SqlConnection conn1 = Connection())
                {
                    cmd.Connection = conn1;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = r1.FName;
                    cmd.Parameters.Add("@mname", SqlDbType.VarChar).Value = r1.MName;
                    cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = r1.LName;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = r1.Email;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = r1.Username;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = r1.Password;
                    cmd.Parameters.Add("@ward", SqlDbType.VarChar).Value = r1.Ward;
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                response = sd.GetString(0);
                            }
                        }
                    }
                }
            }
            return response;
        }
        public string LoginUser(Login l1)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LoginUser";
                using (SqlConnection conn1 = Connection())
                {
                    cmd.Connection = conn1;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = l1.Username;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = l1.Password;
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                response = sd.GetString(0);
                            }
                        }
                    }
                }
            }
            return response;
        }
        public IEnumerable<Users> Users()
        {
            List<Users> users = new List<Users>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Users";
                using (SqlConnection conn = Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 30;
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                Users b1 = new Users();
                                b1.FName = Convert.ToString(rd["FName"]);
                                b1.MName = Convert.ToString(rd["MName"]);
                                b1.LName = Convert.ToString(rd["LName"]);
                                b1.Email = Convert.ToString(rd["Email"]);
                                b1.Username = Convert.ToString(rd["Username"]);
                                b1.Password = Convert.ToString(rd["Password"]);
                                b1.Ward = Convert.ToInt32(rd["Ward"]);
                                users.Add(b1);
                            }
                        }
                    }
                }
            }
            return users;
        }
        public Users DatafromUserTable(string name)
        {
            Users s2 = new Model.Users();
            string fname = "";
            string mname = "";
            string lname = "";
            string email = "";
            string username = "";
            string ward = "";
            string phone = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select* from Users where Username=@name";
                using (SqlConnection conn1 = Connection())
                {
                    cmd.Connection = conn1;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                s2.FName = Convert.ToString(sd["FName"]);
                                s2.MName = Convert.ToString(sd["MName"]);
                                s2.LName = Convert.ToString(sd["LName"]);
                                s2.Email = Convert.ToString(sd["Email"]);
                                s2.Username = Convert.ToString(sd["Username"]);
                                s2.Ward = Convert.ToInt32(sd["Ward"]);
                            }
                        }
                    }
                }
            }
            return s2;
        }
        public string InsertMessage(Messages m1)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertmessage";
                using (SqlConnection conn1 = Connection())
                {
                    cmd.Connection = conn1;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = m1.Name;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = m1.Email;
                    cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = m1.Subject;
                    cmd.Parameters.Add("@message", SqlDbType.VarChar).Value = m1.Message;
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                response = sd.GetString(0);
                            }
                        }
                    }
                }
            }
            return response;
        }
    }
}
