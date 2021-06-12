using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class ProductServicesImplements : ITransferObjetcs<Product>
    {
        public List<Product> FindAll()
        {
            List<Product> products = new List<Product>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Products";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (long)reader["product_id"];
                    product.Code = (long)reader["product_code"];
                    product.Description = reader["product_description"].ToString();
                    product.ImagePath = reader["image_path"].ToString();
                    product.Name = reader["product_name"].ToString();
                    product.UnitPrice = (double)reader["product_price"];
                    product.State = (bool)reader["state"];
                    product.Stock = (int)reader["stock"];
                    product.Brand = new BrandServicesImplements().FindById((long)reader["brand_brand_id"]);
                    product.Category = new CategoryServicesImplements().FindById((long)reader["category_category_id"]);
                    product.Supplier = new SupplierServicesImplements().FindById((long)reader["supplier_supplier_id"]);
                    products.Add(product);
                }
            }
            connection.Close();
            return products;
        }

        public Product FindById(long id)
        {
            Product product = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Products WHERE product_id = @ProductId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    product = new Product();
                    product.Id = (long)reader["product_id"];
                    product.Code = (long)reader["product_code"];
                    product.Description = reader["product_description"].ToString();
                    product.ImagePath = reader["image_path"].ToString();
                    product.Name = reader["product_name"].ToString();
                    product.UnitPrice = (double)reader["product_price"];
                    product.State = (bool)reader["state"];
                    product.Stock = (int)reader["stock"];
                    product.Brand = new BrandServicesImplements().FindById((long)reader["brand_brand_id"]);
                    product.Category = new CategoryServicesImplements().FindById((long)reader["category_category_id"]);
                    product.Supplier = new SupplierServicesImplements().FindById((long)reader["supplier_supplier_id"]);
                }
            }
            connection.Close();
            return product;
        }

        public void Save(Product o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.Id > 0) ? "UPDATE Products set product_code = @ProductCode, product_description = @ProductDescription, image_path = @ImagePath, " +
                                 "product_name = @ProductName, product_price = @ProductPrice, state = @State, stock = @Stock, brand_brand_id = @BrandId, " +
                                 "category_category_id = @CategoryId, supplier_supplier_id = @SupplierId WHERE product_id = @Id" :
                                 "INSERT INTO Products (product_code, product_description, image_path, product_name, product_price, state, stock, " +
                                 "brand_brand_id, category_category_id, supplier_supplier_id) VALUES (@ProductCode, @ProductDescription, @ImagePath, " +
                                 "@ProductName, @ProductPrice, @State, @Stock, @BrandId, @CategoryId, @SupplierId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@ProductCode", o.Code);
            sqlCommand.Parameters.AddWithValue("@ProductDescription", o.Description);
            sqlCommand.Parameters.AddWithValue("@ImagePath", o.ImagePath);
            sqlCommand.Parameters.AddWithValue("@ProductName", o.Name);
            sqlCommand.Parameters.AddWithValue("@ProductPrice", o.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@State", o.State);
            sqlCommand.Parameters.AddWithValue("@Stock", o.Stock);
            sqlCommand.Parameters.AddWithValue("@BrandId", o.Brand.Id);
            sqlCommand.Parameters.AddWithValue("@CategoryId", o.Category.Id);
            sqlCommand.Parameters.AddWithValue("@SupplierId", o.Supplier.Id);
            if (o.Id > 0)
            {
                sqlCommand.Parameters.AddWithValue("@Id", o.Id);
            }
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

    }
}
