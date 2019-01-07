//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace HotelManagement.Models
//{
//    public class Guest:Member
//    {
//        public static int GuestID { get; set; }

//        public static List<Guest> GetAll()
//        {
//            List<Guest> list = null;
//            Connection objConn = new Connection();
//            string mString = objConn.GetCon("FirstConnection");
//            using (SqlConnection objSqlConn = new SqlConnection(mString))
//            {
//                SqlCommand objSqlComm = new SqlCommand("usp_GuestGetAll", objSqlConn);
//                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;

//                objSqlConn.Open();

//                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
//                {
//                    if (objSqlReader.HasRows)
//                    {

//                        list = new List<Guest>();

//                        while (objSqlReader.Read())
//                        {
//                            Guest objGuest = new Guest();
//                            objGuest.FirstName = objSqlReader["FirstName"].ToString();
//                            objGuest.LastName = objSqlReader["LastName"].ToString();
//                            objGuest.Birthday = DateTime.Parse(objSqlReader["Birthday"].ToString());
//                            objGuest.Address = objSqlReader["Address"].ToString();
//                            objGuest.PhoneNumber =objSqlReader["PhoneNumber"].ToString();
//                            objGuest.PassportNumber =objSqlReader["PassportNumber"].ToString();
//                            objGuest.Gender= char.Parse(objSqlReader["Gender"].ToString());
//                            list.Add(objGuest);

//                        }
//                    }

//                }


//            }
//            return list;
//        }

//        public bool Insert()
//        {
//            bool IsInserted = false;
//            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
//            {
//                SqlCommand objSqlCommand = new SqlCommand("usp_GuestInsert", objSqlConn);
//                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                objSqlCommand.Parameters.AddWithValue("FirstName", FirstName);
//                objSqlCommand.Parameters.AddWithValue("LastName", LastName);
//                objSqlCommand.Parameters.AddWithValue("Birthday", Birthday);
//                objSqlCommand.Parameters.AddWithValue("Address", Address);
//                objSqlCommand.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
//                objSqlCommand.Parameters.AddWithValue("Gender", Gender);

//                objSqlConn.Open();
//                if (objSqlCommand.ExecuteNonQuery() > 0)
//                {
//                    IsInserted = true;
//                }
//            }
//            return IsInserted;

//        }


//    }
//}