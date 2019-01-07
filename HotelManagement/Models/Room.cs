using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int FloorNumber { get; set; }
        public RoomType RoomType { get; set; }
        public int TypeID = RoomType.TypeID;
        public int MaxGuestNumber = RoomType.MaxGuestNumber;
        public string RoomDescription = RoomType.RoomDescription;
        public double RoomPrice = RoomType.RoomPrice;
        public string Status { get; set; }



        public static List<Room> GetAll()
        {

            List<Room> list = null;
            Connection objConn = new Connection();
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_RoomGetAll", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        list = new List<Room>();

                        while (objSqlReader.Read())
                        {
                            Room objRoom = new Room();

                            objRoom.RoomID = int.Parse(objSqlReader["RoomID"].ToString());
                            objRoom.FloorNumber = int.Parse(objSqlReader["FloorNumber"].ToString());
                            objRoom.TypeID = int.Parse(objSqlReader["TypeID"].ToString());
                            objRoom.MaxGuestNumber = int.Parse(objSqlReader["MaxGuestNumber"].ToString());
                            objRoom.RoomDescription = objSqlReader["RoomDescription"].ToString();
                            objRoom.RoomPrice = double.Parse(objSqlReader["RoomPrice"].ToString());


                            list.Add(objRoom);

                        }
                    }

                }


            }
            return list;
        }

        public static List<Room> GetAllStatus()
        {

            List<Room> list = null;
            Connection objConn = new Connection();
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_RoomGetAllStatus", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        list = new List<Room>();

                        while (objSqlReader.Read())
                        {
                            Room objRoom = new Room();

                            objRoom.RoomID = int.Parse(objSqlReader["RoomID"].ToString());
                            objRoom.FloorNumber = int.Parse(objSqlReader["FloorNumber"].ToString());
                            objRoom.TypeID = int.Parse(objSqlReader["TypeID"].ToString());
                            objRoom.MaxGuestNumber = int.Parse(objSqlReader["MaxGuestNumber"].ToString());
                            objRoom.RoomDescription = objSqlReader["RoomDescription"].ToString();
                            objRoom.RoomPrice = double.Parse(objSqlReader["RoomPrice"].ToString());
                            objRoom.Status = objSqlReader["Status"].ToString();

                            list.Add(objRoom);

                        }
                    }

                }


            }
            return list;
        }

        public static Models.Room GetById(int id)
        {
            Connection objConn = new Connection();

            Room objRoom = null;
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_RoomGetById", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlComm.Parameters.AddWithValue("RoomID", id);

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        while (objSqlReader.Read())
                        {
                            objRoom = new Room();
                            objRoom.RoomID = int.Parse(objSqlReader["RoomID"].ToString());
                            objRoom.FloorNumber = int.Parse(objSqlReader["FloorNumber"].ToString());
                            objRoom.TypeID = int.Parse(objSqlReader["TypeID"].ToString());
                            objRoom.MaxGuestNumber = int.Parse(objSqlReader["MaxGuestNumber"].ToString());
                            objRoom.RoomDescription = objSqlReader["RoomDescription"].ToString();
                            objRoom.RoomPrice = double.Parse(objSqlReader["RoomPrice"].ToString());


                        }
                    }

                }


            }
            return objRoom;
        }
        public static Models.Room GetByTypeAndId(int id, int type)
        {
            Connection objConn = new Connection();

            Room objRoom = null;
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_RoomGetByTypeAndId", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlComm.Parameters.AddWithValue("RoomID", id);
                objSqlComm.Parameters.AddWithValue("TypeID", type);

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        while (objSqlReader.Read())
                        {
                            objRoom = new Room();
                            objRoom.RoomID = int.Parse(objSqlReader["RoomID"].ToString());
                            objRoom.FloorNumber = int.Parse(objSqlReader["FloorNumber"].ToString());
                            objRoom.TypeID = int.Parse(objSqlReader["TypeID"].ToString());
                            objRoom.MaxGuestNumber = int.Parse(objSqlReader["MaxGuestNumber"].ToString());
                            objRoom.RoomDescription = objSqlReader["RoomDescription"].ToString();
                            objRoom.RoomPrice = double.Parse(objSqlReader["RoomPrice"].ToString());



                        }
                    }

                }


            }
            return objRoom;
        }

        public bool Update(int typeID, int roomID,int userID)
        {
            bool IsUpdated = false;

            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_RoomUpdate", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("ID", userID);
                objSqlCommand.Parameters.AddWithValue("RoomID", roomID);
                objSqlCommand.Parameters.AddWithValue("TypeID", typeID);
                objSqlCommand.Parameters.AddWithValue("FloorNumber", FloorNumber);
                objSqlCommand.Parameters.AddWithValue("MaxGuestNumber", MaxGuestNumber);
                objSqlCommand.Parameters.AddWithValue("RoomDescription", RoomDescription);
                objSqlCommand.Parameters.AddWithValue("RoomPrice", RoomPrice);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsUpdated = true;
                }
            }
            return IsUpdated;
        }

        public bool UpdateByRole2(int typeID, int roomID, int userID)
        {
            bool IsUpdated = false;

            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_RoomUpdateByRole2", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("ID", userID);
                objSqlCommand.Parameters.AddWithValue("RoomID", roomID);
                objSqlCommand.Parameters.AddWithValue("TypeID", typeID);
                objSqlCommand.Parameters.AddWithValue("FloorNumber", FloorNumber);
                objSqlCommand.Parameters.AddWithValue("MaxGuestNumber", MaxGuestNumber);
                objSqlCommand.Parameters.AddWithValue("RoomDescription", RoomDescription);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsUpdated = true;
                }
            }
            return IsUpdated;
        }
        /// <summary>
        /// Room Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            bool IsDeleted = false;

            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_RoomDelete", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("RoomID", id);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsDeleted = true;
                }
            }
            return IsDeleted;

        }
        public static List<Models.Room> CheckAvailability(DateTime checkIn, DateTime checkOut)
        {
            List<Models.Room> list = null;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {

                SqlCommand objSqlCommand = new SqlCommand("usp_RoomCheckAvailability", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("CheckIn", checkIn);
                objSqlCommand.Parameters.AddWithValue("CheckOut", checkOut);
                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlCommand.ExecuteReader())
                {


                    if (objSqlReader.HasRows)
                    {
                        list = new List<Room>();
                        while (objSqlReader.Read())
                        {

                            Models.Room r = new Room();
                            r.RoomID = int.Parse(objSqlReader["RoomID"].ToString());
                            r.TypeID = int.Parse(objSqlReader["TypeID"].ToString());
                            r.FloorNumber = int.Parse(objSqlReader["FloorNumber"].ToString());
                            r.MaxGuestNumber = int.Parse(objSqlReader["MaxGuestNumber"].ToString());
                            r.RoomDescription = objSqlReader["RoomDescription"].ToString();
                            r.RoomPrice = double.Parse(objSqlReader["RoomPrice"].ToString());
                            list.Add(r);
                        }
                    }

                }
            }
            return list;
        }

        public int GetTypeByDescription(string description,int roomID)
        {
            int type = 0;
            using (SqlConnection conn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand comm = new SqlCommand("usp_GetTypeByDescription", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("RoomDescription", description);
                comm.Parameters.AddWithValue("RoomID", roomID);

                conn.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            type = int.Parse(reader["TypeID"].ToString());
                        }
                    }
                }
            }
            return type;

        }

        public bool Insert(int userID)
        {
            bool IsInserted = false;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_RoomTypeInsert", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("UserID", userID);
                objSqlCommand.Parameters.AddWithValue("FloorNumber", FloorNumber);
                objSqlCommand.Parameters.AddWithValue("MaxGuestNumber", MaxGuestNumber);
                objSqlCommand.Parameters.AddWithValue("RoomPrice", RoomPrice);
                objSqlCommand.Parameters.AddWithValue("RoomDescription", RoomDescription);

                objSqlConn.Open();
                if (objSqlCommand.ExecuteNonQuery() > 0)
                {
                    IsInserted = true;
                }
            }
            return IsInserted;

        }

        //public int GetRoomByType(int type)
        //{
        //    int room = 0;
        //    using (SqlConnection conn = new SqlConnection(Connection.DefaultConnection))
        //    {
        //        SqlCommand comm = new SqlCommand("usp_GetRoomByType", conn);
        //        comm.CommandType = System.Data.CommandType.StoredProcedure;
        //        comm.Parameters.AddWithValue("RoomType", type);
        //        conn.Open();
        //        using (SqlDataReader reader = comm.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                if (reader.Read())
        //                {
        //                    room = int.Parse(reader["TypeID"].ToString());
        //                }
        //            }
        //        }
        //    }
        //    return room;

        //}

        public static List<Models.Room> GetAllRoomPrice()
        {
            List<Models.Room> list = null;
            using (SqlConnection objSqlConn = new SqlConnection(Connection.DefaultConnection))
            {
                SqlCommand objSqlCommand = new SqlCommand("usp_GetAllRoomPrice", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlConn.Open();

                using (SqlDataReader dataReader = objSqlCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        list = new List<Room>();
                        while (dataReader.Read())
                        {
                            Room obj = new Room();
                            obj.RoomID = (int)dataReader["RoomID"];
                            obj.RoomDescription = dataReader["RoomDescription"].ToString();
                            obj.RoomPrice = double.Parse(dataReader["RoomPrice"].ToString());
                            list.Add(obj);
                        }
                    }
                }
            }
            return list;
        }
    }
}