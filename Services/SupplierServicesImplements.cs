using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class SupplierServicesImplements : ITransferObjetcs<Supplier>
    {
        public List<Supplier> FindAll()
        {
            List<Supplier> suppliers = new List<Supplier>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Suppliers";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierId = (long)reader["supplier_id"];
                    supplier.Email = reader["supplier_email"].ToString();
                    supplier.Name = reader["supplier_name"].ToString();
                    supplier.Nit = reader["nit"].ToString();
                    supplier.Phone = (decimal)(reader["supplier_phone"]);
                    supplier.State = (bool)reader["state"];
                    supplier.City = new CityServicesImplements().FindById((long)reader["city_city_id"]);
                    suppliers.Add(supplier);
                }
            }
            connection.Close();
            return suppliers;
        }

        public Supplier FindById(long id)
        {
            Supplier supplier = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Suppliers WHERE supplier_id = @SupplierId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SupplierId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    supplier = new Supplier();
                    supplier.SupplierId = (long)reader["supplier_id"];
                    supplier.Email = reader["supplier_email"].ToString();
                    supplier.Name = reader["supplier_name"].ToString();
                    supplier.Nit = reader["nit"].ToString();
                    supplier.Phone = (decimal)(reader["supplier_phone"]);
                    supplier.State = (bool)reader["state"];
                    supplier.City = new CityServicesImplements().FindById((long)reader["city_city_id"]);
                }
            }
            connection.Close();
            return supplier;
        }

        public void Save(Supplier o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.SupplierId > 0) ? "UPDATE Suppliers set supplier_email = @SupplierEmail, supplier_name = @SupplierName, nit = @Nit, " +
                                 "supplier_phone = @SupplierPhone, state = @State, city_city_id = @CityId WHERE supplier_id = @Id" :
                                 "INSERT INTO Suppliers (supplier_email, supplier_name, nit, supplier_phone, state, city_city_id) " +
                                 "VALUES (@SupplierEmail, @SupplierName, @Nit, @SupplierPhone, @State, @CityId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@SupplierEmail", o.Email);
            sqlCommand.Parameters.AddWithValue("@SupplierName", o.Name);
            sqlCommand.Parameters.AddWithValue("@Nit", o.Nit);
            sqlCommand.Parameters.AddWithValue("@SupplierPhone", o.Phone);
            sqlCommand.Parameters.AddWithValue("@State", o.State);
            sqlCommand.Parameters.AddWithValue("@CityId", o.City.CityId);
            if (o.SupplierId > 0)
            {
                sqlCommand.Parameters.AddWithValue("@Id", o.SupplierId);
            }
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

    }
}
