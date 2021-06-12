using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class DiscountServicesImplements : ITransferObjetcs<Discount>
    {
        public List<Discount> FindAll()
        {
            List<Discount> discounts = new List<Discount>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Discounts";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Discount discount = new Discount((long)reader["discount_id"], (bool)reader["state"], (double)reader["discount_value"]);
                    discounts.Add(discount);
                }
            }
            connection.Close();
            return discounts;
        }

        public Discount FindById(long id)
        {
            Discount discount = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Discounts WHERE discount_id = @discountId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@discountId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    discount = new Discount((long)reader["discount_id"], (bool)reader["state"], (double)reader["discount_value"]);
                }
            }
            connection.Close();
            return discount;
        }

        public void Save(Discount o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.DiscountId > 0) ? "UPDATE Discounts set state = @State, discount_value = @DiscountValue WHERE discount_id = @Id" :
                                 "INSERT INTO Discounts (state, discount_value) VALUES (@State, @DiscountValue)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@State", o.State);
            sqlCommand.Parameters.AddWithValue("@DiscountValue", o.Value);
            if (o.DiscountId > 0)
            {
                sqlCommand.Parameters.AddWithValue("@Id", o.DiscountId);
            }
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

    }
}
