using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace StaffService
{
    public class StaffService : IStaffService
    {
        private String connectionString;

        StaffService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["staffDatabaseConnectionString"].ConnectionString;
        }

        private SqlConnection retrieveConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public Staff[] QueryAllStaff()
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("select STAFF_ID, Name, LastName, Room, ipAddress from staff order by STAFF_ID", connection);

                reader = command.ExecuteReader();

                ArrayList result = new ArrayList();

                while (reader.Read())
                {
                    Staff staff = new Staff();
                    staff.Id = Int32.Parse(reader["STAFF_ID"].ToString());
                    staff.Name = reader["Name"].ToString();
                    staff.LastName = reader["LastName"].ToString();
                    staff.Room = reader["Room"].ToString();
                    staff.IpAddress = reader["ipAddress"].ToString();
                    result.Add(staff);
                }

                return result.ToArray(typeof(Staff)) as Staff[];
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        public Staff QueryStaff(int id)
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;
            Staff staff = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("select STAFF_ID, Name, LastName, Room, ipAddress from staff where STAFF_ID = @id", connection);
                command.Parameters.Add(new SqlParameter("id", id));

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    staff = new Staff();
                    staff.Id = Int32.Parse(reader["STAFF_ID"].ToString());
                    staff.Name = reader["Name"].ToString();
                    staff.LastName = reader["LastName"].ToString();
                    staff.Room = reader["Room"].ToString();
                    staff.IpAddress = reader["ipAddress"].ToString();
                }
                else
                    throw new Exception("Staff member not found!");

                return staff;
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        public void InsertStaff(Staff staff)
        {
            SqlConnection connection = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("insert into staff values (@Id, @Name, @LastName, @Room, @IpAddress)", connection);
                command.Parameters.Add(new SqlParameter("id", staff.Id));
                command.Parameters.Add(new SqlParameter("Name", staff.Name));
                command.Parameters.Add(new SqlParameter("LastName", staff.LastName));
                command.Parameters.Add(new SqlParameter("Room", staff.Room));
                command.Parameters.Add(new SqlParameter("ipAddress", staff.IpAddress));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateStaff(int id, Staff staff)
        {
            SqlConnection connection = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("update staff set "+
                    "STAFF_ID = @staffId, "+
                    "Name = @Name, "+
                    "LastName = @LastName, "+
                    "Room = @Room, "+
                    "ipAddress = @IpAddress "+
                    "where STAFF_ID = @id", connection);
                command.Parameters.Add(new SqlParameter("staffId", staff.Id));
                command.Parameters.Add(new SqlParameter("Name", staff.Name));
                command.Parameters.Add(new SqlParameter("LastName", staff.LastName));
                command.Parameters.Add(new SqlParameter("Room", staff.Room));
                command.Parameters.Add(new SqlParameter("IpAddress", staff.IpAddress));
                command.Parameters.Add(new SqlParameter("id", id));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteStaff(int id)
        {
            SqlConnection connection = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("delete from staff where STAFF_ID = @id", connection);
                command.Parameters.Add(new SqlParameter("id", id));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
