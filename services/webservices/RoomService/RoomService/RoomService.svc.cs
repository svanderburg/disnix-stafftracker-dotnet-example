using System;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace RoomService
{
    public class RoomService : IRoomService
    {
        private String connectionString;

        RoomService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["roomDatabaseConnectionString"].ConnectionString;
        }

        private SqlConnection retrieveConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public string[] QueryAllRoomIdentifiers()
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("select Room from room order by Room", connection);
                reader = command.ExecuteReader();

                ArrayList result = new ArrayList();

                while (reader.Read())
                    result.Add(reader["Room"]);

                return result.ToArray(typeof(string)) as string[];
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        public Room QueryRoom(string roomKey)
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;
            Room room = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("select Room, Zipcode from room where Room = @roomKey", connection);
                command.Parameters.Add(new SqlParameter("roomKey", roomKey));

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    room = new Room();
                    room.RoomKey = reader["Room"].ToString();
                    room.Zipcode = reader["Zipcode"].ToString();
                }
                else
                    throw new Exception("Room not found!");

                return room;
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        public void InsertRoom(Room room)
        {
            SqlConnection connection = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("insert into room values (@Room, @Zipcode)", connection);
                command.Parameters.Add(new SqlParameter("Room", room.RoomKey));
                command.Parameters.Add(new SqlParameter("Zipcode", room.Zipcode));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateRoom(Room room, string roomKey)
        {
            SqlConnection connection = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("update room set Room = @Room, Zipcode = @Zipcode where Room = @roomKey", connection);
                command.Parameters.Add(new SqlParameter("Room", room.RoomKey));
                command.Parameters.Add(new SqlParameter("Zipcode", room.Zipcode));
                command.Parameters.Add(new SqlParameter("roomKey", roomKey));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteRoom(string roomKey)
        {
            SqlConnection connection = null;

            try
            {
                SqlCommand command = new SqlCommand("delete from room where Room = @roomKey", connection);
                command.Parameters.Add(new SqlParameter("roomKey", roomKey));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
