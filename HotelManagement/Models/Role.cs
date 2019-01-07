using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; }

        public static List<Role> GetAll()
        {
            List<Role> list = null;
            Connection objConn = new Connection();
            string mString = objConn.GetCon("FirstConnection");
            using (SqlConnection objSqlConn = new SqlConnection(mString))
            {
                SqlCommand objSqlComm = new SqlCommand("usp_RoleGetAll", objSqlConn);
                objSqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlConn.Open();

                using (SqlDataReader objSqlReader = objSqlComm.ExecuteReader())
                {
                    if (objSqlReader.HasRows)
                    {

                        list = new List<Role>();

                        while (objSqlReader.Read())
                        {
                            Role objRole = new Role();
                            objRole.RoleID = int.Parse(objSqlReader["RoleID"].ToString());
                            objRole.Name = objSqlReader["Name"].ToString();

                            list.Add(objRole);

                        }
                    }

                }


            }
            return list;
        }
    }
}