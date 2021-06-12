using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class CityServicesImplements : ITransferObjetcs<City>
    {
        public List<City> FindAll()
        {
            List<City> cities = new List<City>();

            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();

            string query = "SELECT * FROM Cities";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    City city = new City((long)reader["city_id"], reader["city_name"].ToString());
                    cities.Add(city);
                }
            }
            connection.Close();

            return cities;
        }

        public City FindById(long id)
        {
            City city = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Cities WHERE city_id = @CityId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CityId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    city = new City((long)reader["city_id"], reader["city_name"].ToString());
                }
            }
            connection.Close();
            return city;
        }

        public void Save(City o)
        {
            throw new NotImplementedException();
        }

    }
}
