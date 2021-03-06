using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class ServiceServicesImplements : ITransferObjetcs<Service>
    {
        public List<Service> FindAll()
        {
            List<Service> services = new List<Service>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Services";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Service service = new Service();
                    service.ServiceId = (long)reader["service_id"];
                    service.Description = reader["service_description"].ToString();
                    service.Name = reader["service_name"].ToString();
                    service.Value = (double)reader["service_price"];
                    service.State = (bool)reader["state"];
                    services.Add(service);
                }
            }
            connection.Close();
            return services;
        }

        public Service FindById(long id)
        {
            Service service = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Services WHERE service_id = @ServiceId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ServiceId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    service = new Service();
                    service.ServiceId = (long)reader["service_id"];
                    service.Description = reader["service_description"].ToString();
                    service.Name = reader["service_name"].ToString();
                    service.Value = (double)reader["service_price"];
                    service.State = (bool)reader["state"];
                }
            }
            connection.Close();
            return service;
        }

        public void Save(Service o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.ServiceId > 0) ? "UPDATE Services set service_description = @ServiceDescription, service_name = @ServiceName, " +
                                        "service_price = @ServicePrice, state = @State WHERE service_id = @Id" :
                                        "INSERT INTO Services (service_description, service_name, service_price, state) " +
                                        "VALUES (@ServiceDescription, @ServiceName, @ServicePrice, @State)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@ServiceDescription", o.Description);
            sqlCommand.Parameters.AddWithValue("@ServiceName", o.Name);
            sqlCommand.Parameters.AddWithValue("@ServicePrice", o.Value / 100);
            sqlCommand.Parameters.AddWithValue("@State", o.State);
            if (o.ServiceId > 0)
            {
                sqlCommand.Parameters.AddWithValue("@Id", o.ServiceId);
            }
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

    }
}
