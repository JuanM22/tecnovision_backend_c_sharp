using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class CategoryServicesImplements : ITransferObjetcs<Category>
    {
        public List<Category> FindAll()
        {
            List<Category> categories = new List<Category>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Categories";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Category category = new Category((long)reader["category_id"], reader["category_name"].ToString(), (bool)reader["state"]);
                    long discountId = (long)reader["discount_discount_id"];
                    if (discountId > 0)
                    {
                        category.AddDiscount();
                        category.Discount = new DiscountServicesImplements().FindById(discountId);
                    }
                    categories.Add(category);
                }
            }
            connection.Close();
            return categories;
        }

        public Category FindById(long id)
        {
            Category category = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Categories WHERE category_id = @CategoryId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    category = new Category((long)reader["category_id"], reader["category_name"].ToString(), (bool)reader["state"]);
                    long discountId = (long)reader["discount_discount_id"];
                    if (discountId > 0)
                    {
                        category.AddDiscount();
                        category.Discount = new DiscountServicesImplements().FindById(discountId);
                    }
                }
            }
            connection.Close();
            return category;
        }

        public void Save(Category o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.CategoryId > 0) ? "UPDATE Categories set category_name = @CategoryName,  state = @CategoryState, discount_discount_id  = @DiscountId " +
                                 "WHERE category_id = @CategoryId" :
                                 "INSERT INTO Categories (category_name, state, discount_discount_id) VALUES (@CategoryName, @CategoryState, @DiscountId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@CategoryName", o.Name);
            sqlCommand.Parameters.AddWithValue("@CategoryState", o.State);
            if (o.Discount != null) sqlCommand.Parameters.AddWithValue("@DiscountId", o.Discount.DiscountId);
            else sqlCommand.Parameters.AddWithValue("@DiscountId", DBNull.Value);
            if (o.CategoryId > 0)
            {
                sqlCommand.Parameters.AddWithValue("@CategoryId", o.CategoryId);
            }
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

    }
}
