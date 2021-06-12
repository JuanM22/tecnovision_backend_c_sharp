using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class BrandServicesImplements : ITransferObjetcs<Brand>
    {
        public List<Brand> FindAll()
        {
            List<Brand> brands = new List<Brand>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Brands";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Brand brand = new Brand((long)reader["brand_id"], reader["brand_name"].ToString(), (bool)reader["state"]);
                    brands.Add(brand);
                }
            }
            connection.Close();
            return brands;
        }

        public Brand FindById(long id)
        {
            Brand brand = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Brands WHERE brand_id = @BrandId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BrandId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    brand = new Brand((long)reader["brand_id"], reader["brand_name"].ToString(), (bool)reader["state"]);
                }
            }
            connection.Close();
            return brand;
        }

        public void Save(Brand o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.BrandId > 0) ? "UPDATE Brands set brand_name = @BrandName,  state = @BrandState WHERE brand_id = @BrandId" :
                                 "INSERT INTO Brands (brand_name, state) VALUES (@BrandName, @BrandState)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@BrandName", o.BrandName);
            sqlCommand.Parameters.AddWithValue("@BrandState", o.State);
            if (o.BrandId > 0)
            {
                sqlCommand.Parameters.AddWithValue("@BrandId", o.BrandId);
            }
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

    }
}
