using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;
using System.Net.Mail;
using System.Net;

namespace HotelManagement.Models
{
    public class Booking : Member
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int ContactNumber { get; set; }
        public int StaffID { get; set; }
        public Room Room { get; set; }
        public int AdultsNo { get; set; }
        public int ChildrenNo { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double TotalPrice { get; set; }
        public int TypeID = RoomType.TypeID;
        public string RoomDescription = RoomType.RoomDescription;
        public string isDeleted { get; set; }
        public string isConfirmed { get; set; }
        //Room obj = new Room();
        public bool Insert(int id,int roomID)
        {
            bool IsInserted = false;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_BookingInsertByRole3", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("SessionID", id);
                objSqlCommand.Parameters.AddWithValue("Birthday", Birthday);
                objSqlCommand.Parameters.AddWithValue("Address", Address);
                objSqlCommand.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
                objSqlCommand.Parameters.AddWithValue("PassportNumber", PassportNumber);
                objSqlCommand.Parameters.AddWithValue("CheckIn", CheckIn);
                objSqlCommand.Parameters.AddWithValue("CheckOut", CheckOut);
                objSqlCommand.Parameters.AddWithValue("AdultsNo", AdultsNo);
                objSqlCommand.Parameters.AddWithValue("ChildrenNo", ChildrenNo);
                objSqlCommand.Parameters.AddWithValue("RoomDescription", RoomDescription);
                objSqlCommand.Parameters.AddWithValue("RoomID", roomID);
                objSqlCommand.Parameters.AddWithValue("Gender", Gender);
                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsInserted = true;
                }
            }
            return IsInserted;

        }

        public bool InsertWhileInCookie(int id, int roomID)
        {
            bool IsInserted = false;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_BookingInsertByRole3Twice", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("SessionID", id);
                objSqlCommand.Parameters.AddWithValue("CheckIn", CheckIn);
                objSqlCommand.Parameters.AddWithValue("CheckOut", CheckOut);
                objSqlCommand.Parameters.AddWithValue("AdultsNo", AdultsNo);
                objSqlCommand.Parameters.AddWithValue("ChildrenNo", ChildrenNo);
                objSqlCommand.Parameters.AddWithValue("RoomDescription", RoomDescription);
                objSqlCommand.Parameters.AddWithValue("RoomID", roomID);
                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsInserted = true;
                }
            }
            return IsInserted;

        }


        public bool InsertByRole2(int sessionID, int roomID,int idByName)
        {
            bool IsInserted = false;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_BookingInsertByRole2", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("SessionID", sessionID);
                objSqlCommand.Parameters.AddWithValue("IDByName", idByName);
                objSqlCommand.Parameters.AddWithValue("Birthday", Birthday);
                objSqlCommand.Parameters.AddWithValue("Address", Address);
                objSqlCommand.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
                objSqlCommand.Parameters.AddWithValue("PassportNumber", PassportNumber);
                objSqlCommand.Parameters.AddWithValue("CheckIn", CheckIn);
                objSqlCommand.Parameters.AddWithValue("CheckOut", CheckOut);
                objSqlCommand.Parameters.AddWithValue("AdultsNo", AdultsNo);
                objSqlCommand.Parameters.AddWithValue("ChildrenNo", ChildrenNo);
                objSqlCommand.Parameters.AddWithValue("RoomDescription", RoomDescription);
                objSqlCommand.Parameters.AddWithValue("RoomID", roomID);
                objSqlCommand.Parameters.AddWithValue("Gender", Gender);
                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsInserted = true;
                }
            }
            return IsInserted;

        }

        public static bool UpdateUserWhileOtherBooking(int id,string Address,DateTime? Birthday,string PhoneNumber,string PassportNumber,char Gender)
        {
            bool IsUpdated = false;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_BookingUserUpdateInitByRole3", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("SessionID", id);
                objSqlCommand.Parameters.AddWithValue("Birthday", Birthday);
                objSqlCommand.Parameters.AddWithValue("Address", Address);
                objSqlCommand.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
                objSqlCommand.Parameters.AddWithValue("PassportNumber", PassportNumber);
                objSqlCommand.Parameters.AddWithValue("Gender", Gender);
                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsUpdated = true;
                }
            }
            return IsUpdated;

        }
        public bool InsertForOthers(int SessionID, int BookingID, int UserID)
        {
            bool IsInserted = false;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_BookingForOthers", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("SessionID", SessionID);
                objSqlCommand.Parameters.AddWithValue("BookingID", BookingID);
                objSqlCommand.Parameters.AddWithValue("UserID", UserID);
                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsInserted = true;
                }
            }
            return IsInserted;

        }


        public bool Update(int bookID, int roomID, int userID)
        {
            bool IsUpdated = false;

            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_BookingUpdate", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("UserID", userID);
                objSqlCommand.Parameters.AddWithValue("BookingID", bookID);
                objSqlCommand.Parameters.AddWithValue("RoomID", roomID);
                objSqlCommand.Parameters.AddWithValue("CheckIn", CheckIn);
                objSqlCommand.Parameters.AddWithValue("CheckOut", CheckOut);
                objSqlCommand.Parameters.AddWithValue("ChildrenNo", ChildrenNo);
                objSqlCommand.Parameters.AddWithValue("AdultsNo", AdultsNo);
                objSqlCommand.Parameters.AddWithValue("RoomDescription", RoomDescription);
                objSqlCommand.Parameters.AddWithValue("IsConfirmed", isConfirmed);

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
                SqlCommand objSqlCommand = new SqlCommand("usp_BookingDelete", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("BookingID", id);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsDeleted = true;
                }
            }
            return IsDeleted;

        }

        public static List<Booking> GetAll()
        {

            List<Booking> list = null;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_BookingGetAll", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        list = new List<Booking>();

                        while (objSqlReader.Read())
                        {
                            
                            Booking objBooking = new Booking();
                            objBooking.BookingID = int.Parse(objSqlReader["BookingID"].ToString());
                            objBooking.FirstName = objSqlReader["FirstName"].ToString();
                            objBooking.LastName = objSqlReader["LastName"].ToString();
                            objBooking.Address = objSqlReader["Address"].ToString();
                            objBooking.PhoneNumber = objSqlReader["PhoneNumber"].ToString();
                            objBooking.PassportNumber = objSqlReader["PassportNumber"].ToString();
                            objBooking.CheckIn = DateTime.Parse(objSqlReader["CheckIn"].ToString());
                            objBooking.CheckOut = DateTime.Parse(objSqlReader["CheckOut"].ToString());
                            objBooking.AdultsNo = int.Parse(objSqlReader["AdultsNo"].ToString());
                            objBooking.ChildrenNo = int.Parse(objSqlReader["ChildrenNo"].ToString());
                            objBooking.RoomDescription = objSqlReader["RoomDescription"].ToString();
                            objBooking.isDeleted=objSqlReader["isDeleted"].ToString();
                            objBooking.isConfirmed = objSqlReader["IsConfirmed"].ToString();
                            objBooking.Birthday = objSqlReader["Birthday"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(objSqlReader["Birthday"]);
                            list.Add(objBooking);

                        }
                    }

                }


            }
            return list;
        }

        public int GetRoomID(int roomID)
        {
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_GetRoomID", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlComm.Parameters.AddWithValue("RoomDescription",RoomDescription);
                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {
                        if(objSqlReader.Read())
                        {
                            roomID = int.Parse(objSqlReader["RoomID"].ToString());
                        }
                    }

                }


            }
            return roomID;
        }

        public static Models.Booking GetById(int bookID)
        {
            Connection objConn = new Connection();

            Booking objBooking = null;
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_BookingGetById", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlComm.Parameters.AddWithValue("BookingID", bookID);

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        if(objSqlReader.Read())
                        {
                            objBooking = new Booking();
                            objBooking.BookingID = int.Parse(objSqlReader["BookingID"].ToString());
                            objBooking.FirstName = objSqlReader["FirstName"].ToString();
                            objBooking.LastName = objSqlReader["LastName"].ToString();
                            objBooking.Birthday = DateTime.Parse(objSqlReader["Birthday"].ToString());
                            objBooking.Address = objSqlReader["Address"].ToString();
                            objBooking.PhoneNumber = objSqlReader["PhoneNumber"].ToString();
                            objBooking.PassportNumber = objSqlReader["PassportNumber"].ToString();
                            objBooking.CheckIn = DateTime.Parse(objSqlReader["CheckIn"].ToString());
                            objBooking.CheckOut = DateTime.Parse(objSqlReader["CheckOut"].ToString());
                            objBooking.AdultsNo = int.Parse(objSqlReader["AdultsNo"].ToString());
                            objBooking.ChildrenNo = int.Parse(objSqlReader["ChildrenNo"].ToString());
                            objBooking.RoomDescription = objSqlReader["RoomDescription"].ToString();


                        }
                    }

                }


            }
            return objBooking;
        }

        public static int GetGuestID(int bookingID)
        {
            int guestID = 0;
            using (SqlConnection conn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand comm = new SqlCommand("usp_BookingGetGuestID", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("BookingID", bookingID);

                conn.Open();
                using (SqlDataReader reader=comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            guestID = int.Parse(reader["GuestID"].ToString());
                        }

                    }
                }
            }
            return guestID;
        }
        //Metoda qe ma kthen bookingid e fundit te userid-se qe eshte ne session
        public static int GetBookingIDByUserID(int sessionId)
        {
            Connection objConn = new Connection();

            int bookingID = 0;
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_BookingGetBookingIDByUserID", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlComm.Parameters.AddWithValue("SessionID", sessionId);

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        if (objSqlReader.Read())
                        {
                            bookingID = int.Parse(objSqlReader["BookingID"].ToString());
                        }
                    }

                }


            }
            return bookingID;
        }

        public bool SendEmailToClient(string email,string name,string roomDesc,DateTime checkIn,DateTime checkOut,int adultsNo,int childrenNo)
        {
            try
            {
                MailMessage msg = new MailMessage("lunahotel2018@gmail.com",email);
                msg.Subject = "Please confirm your booking";
                string emailBody = @"<html>
                      <body>
                      <p>Hi <b>" + name+ "</b>,</p>" +
                      "<p>You have requested for a booking with these details:</p>" +
                      "<p><p><b> Room: " + roomDesc + ".</b></p></p>" +
                      "<p><p><b> Check In: " + checkIn + ".</b></p></p>" +
                      "<p><p><b> Check Out: " + checkOut + ".</b></p></p>" +
                      "<p><p><b> Adults Number: " + adultsNo + ".</b></p></p>" +
                      "<p><p><b> Children Number: " + childrenNo + ".</b></p></p>" +
                      "<p><p><p>Please <b>CONFIRM</b> your booking.</p></p></p>" +
                      "<p><p><p>Regards,<br></b>Luna Hotel.</b></p></p></p>" +
                          "</body></html>";
                msg.Body = emailBody;
                msg.IsBodyHtml = true;

                SmtpClient obj = new SmtpClient();
                obj.Host = "smtp.gmail.com";
                obj.Port = 587;
                obj.Timeout = 10000;
                obj.EnableSsl = true;

                string emailFrom = "lunahotel2018@gmail.com";
                string passFrom = "Lunahotel2018.1";
                obj.Credentials = new NetworkCredential(emailFrom, passFrom);
                obj.Send(msg);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static int GetBookingNumber(int userid)
        {
            int no = 0;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_CheckBookingNo", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlCommand.Parameters.AddWithValue("UserID", userid);


                objSqlConn.Open();

                using (SqlDataReader dataReader = objSqlCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            no = (int)dataReader["BookingNo"];

                        }
                    }
                }
            }
            return no;


        }
    }
}