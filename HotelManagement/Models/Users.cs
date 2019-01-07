using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Users:Member
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int RoleID;
        public string Status { get; set; }
        public string Email { get; set; }
        
        public bool Insert()
        {
            bool IsInserted = false;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_UsersInsert1", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("FirstName", FirstName);
                objSqlCommand.Parameters.AddWithValue("LastName", LastName);
                objSqlCommand.Parameters.AddWithValue("UserName", UserName);
                objSqlCommand.Parameters.AddWithValue("UserPassword", UserPassword);
                objSqlCommand.Parameters.AddWithValue("RoleID", 3);
                objSqlCommand.Parameters.AddWithValue("Email", Email);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsInserted = true;
                }
            }
            return IsInserted;

        }

    

        //E merr userid ne baze te username qe e shkruajme,sepse cdo user ka username unik.
        public static int GetUserID(string username)
        {
            int id = 0;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_UserGetByUsername", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                
                objSqlCommand.Parameters.AddWithValue("Username", username);
                

                objSqlConn.Open();

                using (SqlDataReader dataReader = objSqlCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            id = (int)dataReader["UserID"];
                                
                        }
                    }
                }
            }
            return id;


        }
        public bool UpdateUsers(int SessionID)
        {
            bool IsUpdated = false;

            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_UsersUpdate", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("UserID", UserID);
                objSqlCommand.Parameters.AddWithValue("SessionID", SessionID);
                objSqlCommand.Parameters.AddWithValue("UserName", UserName);
                objSqlCommand.Parameters.AddWithValue("FirstName", FirstName);
                objSqlCommand.Parameters.AddWithValue("LastName", LastName);
                objSqlCommand.Parameters.AddWithValue("UserPassword", UserPassword);
                objSqlCommand.Parameters.AddWithValue("RoleID", RoleID);
                objSqlCommand.Parameters.AddWithValue("Email", Email);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsUpdated = true;
                }
            }
            return IsUpdated;

        }

        public bool UpdateUsersInit(int SessionID)
        {
            bool IsUpdated = false;

            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_UsersUpdateAnotherUser", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("UserID", UserID);
                objSqlCommand.Parameters.AddWithValue("SessionID", SessionID);
                objSqlCommand.Parameters.AddWithValue("FirstName", FirstName);
                objSqlCommand.Parameters.AddWithValue("LastName", LastName);
                objSqlCommand.Parameters.AddWithValue("UserName", UserName);
                objSqlCommand.Parameters.AddWithValue("UserPassword", UserPassword);
                objSqlCommand.Parameters.AddWithValue("RoleID", RoleID);
                objSqlCommand.Parameters.AddWithValue("Email", Email);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsUpdated = true;
                }
            }
            return IsUpdated;

        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;

            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_UsersDelete", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("UserID", id);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsDeleted = true;
                }
            }
            return IsDeleted;

        }

        public bool Login()
        {
            bool isValid = false;

            using (SqlConnection conn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand cmd = new SqlCommand("usp_UsersLogin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserName", UserName);
                cmd.Parameters.AddWithValue("UserPassword", UserPassword);

                conn.Open();

                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            UserID = int.Parse(dataReader["UserID"].ToString());
                            RoleID = int.Parse(dataReader["RoleID"].ToString());
                            UserName =dataReader["UserName"].ToString();
                            UserPassword =dataReader["UserPassword"].ToString();
                            Email = dataReader["Email"].ToString();
                            isValid = true;
                        }
                    }
                }

            }

            return isValid;
        }
    

        public static List<Users> GetAll()
        {
            List<Users> list = null;
            Connection objConn = new Connection();
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_UsersGetAll", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        list = new List<Users>();

                        while (objSqlReader.Read())
                        {
                            Users objUser = new Users();
                            objUser.UserID = int.Parse(objSqlReader["UserID"].ToString());
                            objUser.FirstName = objSqlReader["FirstName"].ToString();
                            objUser.LastName = objSqlReader["LastName"].ToString();
                            objUser.UserName = objSqlReader["UserName"].ToString();
                            objUser.UserPassword = objSqlReader["UserPassword"].ToString();
                            objUser.Email = objSqlReader["Email"].ToString();
                            objUser.RoleID = int.Parse(objSqlReader["RoleID"].ToString());

                            list.Add(objUser);

                        }
                    }

                }


            }
            return list;
        }

        public static Models.Users GetUserById(int id)
        {
            Connection objConn = new Connection();
            
            Users objUser = null;
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_UsersGetById", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlComm.Parameters.AddWithValue("UserID", id);

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {
                        
                        while (objSqlReader.Read())
                        {
                            objUser = new Users();
                            objUser.UserID = int.Parse(objSqlReader["UserID"].ToString());
                            objUser.FirstName = objSqlReader["FirstName"].ToString();
                            objUser.LastName = objSqlReader["LastName"].ToString();
                            objUser.UserName = objSqlReader["UserName"].ToString();
                            objUser.UserPassword = objSqlReader["UserPassword"].ToString();
                            objUser.Email = objSqlReader["Email"].ToString();
                            objUser.RoleID = int.Parse(objSqlReader["RoleID"].ToString());
                            

                        }
                    }

                }


            }
            return objUser;
        }


        



    }
}