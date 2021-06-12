using System.Collections.Generic;
using System.Data.SqlClient;
using System.Numerics;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class AdministratorServicesImplements : ITransferObjetcs<Administrator>
    {
        public List<Administrator> FindAll()
        {
            List<Administrator> administrators = new List<Administrator>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Administrators";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Administrator administrator = new Administrator();
                    administrator.AdministratorId = (long)reader["administrator_id"];
                    administrator.Document = (long)reader["administrator_document"];
                    administrator.Address = reader["administrator_address"].ToString();
                    administrator.Email = reader["administrator_email"].ToString();
                    administrator.LastName = reader["administrator_last_name"].ToString();
                    administrator.Name = reader["administrator_name"].ToString();
                    administrator.Password = reader["administrator_password"].ToString();
                    administrator.Phone = (decimal)(reader["administrator_phone"]);
                    administrator.State = (bool)reader["state"];
                    administrator.City = new CityServicesImplements().FindById((long)reader["city_city_id"]);
                    administrators.Add(administrator);
                }
            }
            connection.Close();
            return administrators;
        }

        public Administrator FindById(long id)
        {
            Administrator administrator = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Administrators WHERE administrator_id = @AdministratorId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministratorId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    administrator = new Administrator();
                    administrator.AdministratorId = (long)reader["administrator_id"];
                    administrator.Document = (long)reader["administrator_document"];
                    administrator.Address = reader["administrator_address"].ToString();
                    administrator.Email = reader["administrator_email"].ToString();
                    administrator.LastName = reader["administrator_last_name"].ToString();
                    administrator.Name = reader["administrator_name"].ToString();
                    administrator.Password = reader["administrator_password"].ToString();
                    administrator.Phone = (decimal)reader["administrator_phone"];
                    administrator.State = (bool)reader["state"];
                    administrator.City = new CityServicesImplements().FindById((long)reader["city_city_id"]);
                }
            }
            connection.Close();
            return administrator;
        }

        public void Save(Administrator o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.AdministratorId > 0) ? "UPDATE Administrators set administrator_document = @Document, administrator_address = @Address, " +
                                 "administrator_email = @Email, administrator_last_name = @LastName, administrator_name = @Name, " +
                                 "administrator_password = @Password, administrator_phone = @Phone, state = @State, city_city_id = @CityId " +
                                 "WHERE administrator_id = @Id" :
                                 "INSERT INTO Administrators (administrator_document, administrator_address, administrator_email, administrator_last_name," +
                                 "administrator_name, administrator_password, administrator_phone, state, city_city_id) VALUES (@Document, @Address," +
                                 "@Email, @LastName, @Name, @Password, @Phone, @State, @CityId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@Document", o.Document);
            sqlCommand.Parameters.AddWithValue("@Address", o.Address);
            sqlCommand.Parameters.AddWithValue("@Email", o.Email);
            sqlCommand.Parameters.AddWithValue("@LastName", o.LastName);
            sqlCommand.Parameters.AddWithValue("@Name", o.Name);
            sqlCommand.Parameters.AddWithValue("@Password", o.Password);
            sqlCommand.Parameters.AddWithValue("@Phone", o.Phone);
            sqlCommand.Parameters.AddWithValue("@State", o.State);
            sqlCommand.Parameters.AddWithValue("@CityId", o.City.CityId);
            if (o.AdministratorId > 0)
            {
                sqlCommand.Parameters.AddWithValue("@Id", o.AdministratorId);
            }
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public Administrator Login(string email, string password)
        {
            Administrator administrator = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Administrators " +
                           "WHERE administrator_email = @AdministratorEmail AND administrator_password = @AdminstratorPassword";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministratorEmail", email);
            command.Parameters.AddWithValue("@AdminstratorPassword", password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    administrator = new Administrator();
                    administrator.AdministratorId = (long)reader["administrator_id"];
                    administrator.Document = (long)reader["administrator_document"];
                    administrator.Address = reader["administrator_address"].ToString();
                    administrator.Email = reader["administrator_email"].ToString();
                    administrator.LastName = reader["administrator_last_name"].ToString();
                    administrator.Name = reader["administrator_name"].ToString();
                    administrator.Password = reader["administrator_password"].ToString();
                    administrator.Phone = (decimal)reader["administrator_phone"];
                    administrator.State = (bool)reader["state"];
                    administrator.City = new CityServicesImplements().FindById((long)reader["city_city_id"]);
                }
            }
            connection.Close();
            return administrator;
        }

    }
}
