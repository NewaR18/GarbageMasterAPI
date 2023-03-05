using OurProject.Model;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

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
        public Users DatafromUserTable(Usernameonly u1)
        {
            Users s2 = new Users();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select* from Users where Username=@name";
                using (SqlConnection conn1 = Connection())
                {
                    cmd.Connection = conn1;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@name", u1.Username);
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
        public string UpdateUsersTable(Changes c1)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateProfile";
                using (SqlConnection conn1 = Connection())
                {
                    cmd.Connection = conn1;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@fname", c1.FName);
                    cmd.Parameters.AddWithValue("@mname", c1.MName);
                    cmd.Parameters.AddWithValue("@lname", c1.LName);
                    cmd.Parameters.AddWithValue("@phone", c1.Phone);
                    cmd.Parameters.AddWithValue("@ward", c1.Ward);
                    cmd.Parameters.AddWithValue("@name", c1.Username);
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
        public string InsertWasteData(Garbages g1)
        {
            int n;
            string response = "";
            int smallP;
            if (g1.SP == "")
            {
                smallP = 0;
            }
            else
            {
                smallP = Convert.ToInt32(g1.SP);
            }
            int bigP;
            if (g1.BP == "")
            {
                bigP = 0;
            }
            else
            {
                bigP = Convert.ToInt32(g1.BP);
            }
            int dustB;
            if (g1.DB == "")
            {
                dustB = 0;
            }
            else
            {
                dustB = Convert.ToInt32(g1.DB);
            }
            int sackB;
            if (g1.sack == "")
            {
                sackB = 0;
            }
            else
            {
                sackB = Convert.ToInt32(g1.sack);
            }
            if (g1.uname == "")
            {
                return "EmptyUsername";
            }
            n = smallP * 1 + bigP * 4 + dustB * 6 + sackB * 12;
            if (n < 1000)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "updatewastedata";
                    using (SqlConnection conn = Connection())
                    {
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@username", g1.uname);
                        cmd.Parameters.AddWithValue("@val", n);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                while (rd.Read())
                                {
                                    response = rd.GetString(0);
                                }
                            }
                        }
                    }
                }
                return response;
            }
            else
            {
                return "spam";
            }
        }
        public Averagewaste getaverage()
        {
            int i = 0;
            List<int> list = new List<int>();
            Averagewaste avgwaste = new Averagewaste();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "findaverage";
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
                                list.Add(Convert.ToInt32(rd[0]));
                            }
                        }
                        for (i = 1; i <= 32; i++)
                        {
                            avgwaste.GetType().GetProperty("Ward" + i + "Average").SetValue(avgwaste, list[i-1]);
                        }
                    }
                }
            }
            return avgwaste;
        }
        public string CheckEmail(Emailonly e1)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "checkforemail";
                using (SqlConnection conn = Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = e1.Email;
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                response = rd.GetString(0);
                            }
                        }
                    }
                }
            }
            return response;
        }
        public string sendemail(Emailonly e1)
        {
            Random r = new Random();
            var x = r.Next(0, 999999);
            string s = x.ToString("000000");
            MailMessage mail = new MailMessage();
            mail.To.Add(e1.Email);
            mail.From = new MailAddress("garbagemaster1417@gmail.com");
            mail.Subject = "Password Reset Code";
            mail.Body = "Dear User,\r\n\r\nWe have received a request to reset your password for your account with us. To proceed, please enter the following 6-digit code to confirm your identity:" + s + ".\r\n\r\nIf you did not make this request, please ignore this email and your password will remain unchanged.\r\n\r\nThank you for using our services.\r\n\r\nBest regards,\r\nGarbage Master";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("garbagemaster1417@gmail.com", "auzclswhmxclllpr");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return s;
        }
        public string ResetPassword(ResetPassword p1)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "resetpassword";
                using (SqlConnection conn = Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = p1.Email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = p1.Password;
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                response = rd.GetString(0);
                            }
                        }
                    }
                }
            }
            return response;
        }
        public IEnumerable<WasteHistory> Extractdata(Usernameonly u1)
        {
            List<WasteHistory> wastehistoryList = new List<WasteHistory>();
            using (SqlConnection conn = Connection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetWasteHiistory";
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = u1.Username;
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                WasteHistory wh = new WasteHistory();
                                wh.Username = Convert.ToString(rd["UsernameWH"]);
                                wh.Waste = Convert.ToString(rd["Waste_Data_History"]);
                                wh.Ward = Convert.ToInt32(rd["WardNoWH"]);
                                wh.Date = Convert.ToString(rd["DateReviewedWH"]);
                                wastehistoryList.Add(wh);
                            }
                        }
                    }
                }
            }
            return wastehistoryList;
        }
        public string GetImage(Usernameonly u1)
        {
            string sql = "Select[Image] from ExtraUserData where Username = @ImageID";
            string myimage = "";
            using (SqlConnection conn = Connection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ImageID", u1.Username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] imageData = (byte[])reader["Image"];
                            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                            {
                                ms.Write(imageData, 0, imageData.Length);
                                myimage = "data:image/png;base64," + Convert.ToBase64String(imageData);
                            }
                        }
                    }
                }
            }
            return myimage;
        }
        public string InsertImage(UsernameAndImage u1)
        {
            string name = u1.Name;
            string image = u1.Image;
            string response = "";
            byte[] imageBytes = Convert.FromBase64String(image.Split(',')[1]);
            SqlConnection con = Connection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insert_img";
                cmd.Parameters.Add("@uname", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@img", SqlDbType.Image).Value = imageBytes;
                cmd.Connection = con;
                using(SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            response = rd.GetString(0);
                        }
                    }
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
