using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ZipcodeService
{
    public class ZipcodeService : IZipcodeService
    {
        private String connectionString;

        ZipcodeService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["zipcodeDatabaseConnectionString"].ConnectionString;
        }

        private SqlConnection retrieveConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public Zipcode QueryZipcode(string zipcodeKey)
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;
            Zipcode zipcode = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("select Zipcode, Street, City from zipcode where Zipcode = @zipcode", connection);
                command.Parameters.Add(new SqlParameter("zipcode", zipcodeKey));

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    zipcode = new Zipcode();
                    zipcode.ZipcodeKey = reader["Zipcode"].ToString();
                    zipcode.Street = reader["Street"].ToString();
                    zipcode.City = reader["City"].ToString();
                }
                else
                    throw new Exception("Zip code not found!");

                return zipcode;
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        public void InsertZipcode(Zipcode zipcode)
        {
            SqlConnection connection = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("insert into zipcode values (@ZipcodeKey, @Street, @City)", connection);
                command.Parameters.Add(new SqlParameter("ZipcodeKey", zipcode.ZipcodeKey));
                command.Parameters.Add(new SqlParameter("Street", zipcode.Street));
                command.Parameters.Add(new SqlParameter("City", zipcode.City));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateZipcode(string zipcodeKey, Zipcode zipcode)
        {
            SqlConnection connection = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("update zipcode set Zipcode = @Zipcode, Street = @Street, City = @City where Zipcode = @zipcodeKey", connection);
                command.Parameters.Add(new SqlParameter("Zipcode", zipcode.ZipcodeKey));
                command.Parameters.Add(new SqlParameter("Street", zipcode.Street));
                command.Parameters.Add(new SqlParameter("City", zipcode.City));
                command.Parameters.Add(new SqlParameter("zipcodeKey", zipcodeKey));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteZipcode(string zipcodeKey)
        {
            SqlConnection connection = null;

            try
            {
                connection = retrieveConnection();

                SqlCommand command = new SqlCommand("delete from zipcode where Zipcode = @zipcodeKey");
                command.Parameters.Add(new SqlParameter("zipcodeKey", zipcodeKey));

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
