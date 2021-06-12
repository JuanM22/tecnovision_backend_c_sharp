using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class CustomerServicesImplements : ITransferObjetcs<Customer>
    {
        public List<Customer> FindAll()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Customers";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerId = (long)reader["customer_id"];
                    customer.Address = reader["customer_address"].ToString();
                    customer.Document = (long)reader["customer_document"];
                    customer.Email = reader["customer_email"].ToString();
                    customer.LastName = reader["customer_last_name"].ToString();
                    customer.Name = reader["customer_name"].ToString();
                    customer.Password = reader["customer_password"].ToString();
                    customer.Phone = (decimal)(reader["customer_phone"]);
                    customer.State = (bool)reader["state"];
                    customer.Administrator = new AdministratorServicesImplements().FindById((long)reader["administrator_administrator_id"]);
                    customer.City = new CityServicesImplements().FindById((long)reader["city_city_id"]);
                    customers.Add(customer);
                }
            }
            connection.Close();
            return customers;
        }

        public Customer FindById(long id)
        {
            Customer customer = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Customers WHERE customer_id = @CustomerId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    customer = new Customer();
                    customer.CustomerId = (long)reader["customer_id"];
                    customer.Address = reader["customer_address"].ToString();
                    customer.Document = (long)reader["customer_document"];
                    customer.Email = reader["customer_email"].ToString();
                    customer.LastName = reader["customer_last_name"].ToString();
                    customer.Name = reader["customer_name"].ToString();
                    customer.Password = reader["customer_password"].ToString();
                    customer.Phone = (decimal)(reader["customer_phone"]);
                    customer.State = (bool)reader["state"];
                    customer.Administrator = new AdministratorServicesImplements().FindById((long)reader["administrator_administrator_id"]);
                    customer.City = new CityServicesImplements().FindById((long)reader["city_city_id"]);
                }
            }
            connection.Close();
            return customer;
        }

        public void Save(Customer o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.CustomerId > 0) ? "UPDATE Customers set customer_document = @Document, customer_address = @Address, " +
                                 "customer_email = @Email, customer_last_name = @LastName, customer_name = @Name, " +
                                 "customer_password = @Password, customer_phone = @Phone, state = @State," +
                                 "administrator_administrator_id = @AdministratorId, city_city_id = @CityId WHERE customer_id = @Id" :
                                 "INSERT INTO Customers (customer_document, customer_address, customer_email, customer_last_name," +
                                 "customer_name, customer_password, customer_phone, state, administrator_administrator_id, city_city_id) " +
                                 "VALUES (@Document, @Address, @Email, @LastName, @Name, @Password, @Phone, @State, @AdministratorId, @CityId)";
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
            sqlCommand.Parameters.AddWithValue("@AdministratorId", o.Administrator.AdministratorId);
            sqlCommand.Parameters.AddWithValue("@CityId", o.City.CityId);
            if (o.CustomerId > 0)
            {
                sqlCommand.Parameters.AddWithValue("@Id", o.CustomerId);
            }
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public Customer Login(string email, string password)
        {
            Customer customer = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Customers " +
                           "WHERE customer_email = @CustomerEmail AND customer_password = @CustomerPassword";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerEmail", email);
            command.Parameters.AddWithValue("@CustomerPassword", password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    customer = new Customer();
                    customer.CustomerId = (long)reader["customer_id"];
                    customer.Address = reader["customer_address"].ToString();
                    customer.Document = (long)reader["customer_document"];
                    customer.Email = reader["customer_email"].ToString();
                    customer.LastName = reader["customer_last_name"].ToString();
                    customer.Name = reader["customer_name"].ToString();
                    customer.Password = reader["customer_password"].ToString();
                    customer.Phone = (decimal)(reader["customer_phone"]);
                    customer.State = (bool)reader["state"];
                    customer.Administrator = new AdministratorServicesImplements().FindById((long)reader["administrator_administrator_id"]);
                    customer.City = new CityServicesImplements().FindById((long)reader["city_city_id"]);
                }
            }
            connection.Close();
            return customer;
        }

    }
}
