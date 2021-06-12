using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class OrderServicesImplements : ITransferObjetcs<Order>
    {
        public List<Order> FindAll()
        {
            List<Order> orders = new List<Order>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Orders";
            SqlCommand command = new SqlCommand(query, connection);
            command.Transaction = connection.BeginTransaction();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    order.OrderId = (long)reader["order_id"];
                    order.DeliveryDate = (DateTime)reader["delivery_date"];
                    order.DispatchDate = (DateTime)reader["dispatch_date"];
                    order.State = reader["state"].ToString();
                    order.TotalPrice = (double)reader["total_price"];
                    order.Customer = new CustomerServicesImplements().FindById((long)reader["customer_customer_id"]);
                    order.PaymentMethod = new PaymentMethodServicesImplements().FindById((long)reader["payment_method_id"]);
                    orders.Add(order);
                }
                reader.Close();
            }
            foreach (Order order in orders)
            {
                order.OrderDetailList = GetOrderDetails(order.OrderId, command);
            }
            command.Transaction.Commit();
            connection.Close();
            return orders;
        }

        public List<Order> FindAllByCustomerIdAndState(long id, string filter, List<Order> orders)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Orders WHERE customer_customer_id = @CustomerId AND state = @State";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            command.Parameters.AddWithValue("@State", filter);
            command.Transaction = connection.BeginTransaction();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    order.OrderId = (long)reader["order_id"];
                    order.DeliveryDate = (DateTime)reader["delivery_date"];
                    order.DispatchDate = (DateTime)reader["dispatch_date"];
                    order.State = reader["state"].ToString();
                    order.TotalPrice = (double)reader["total_price"];
                    order.Customer = new CustomerServicesImplements().FindById((long)reader["customer_customer_id"]);
                    order.PaymentMethod = new PaymentMethodServicesImplements().FindById((long)reader["payment_method_id"]);
                    orders.Add(order);
                }
                reader.Close();
            }
            foreach (Order order in orders)
            {
                order.OrderDetailList = GetOrderDetails(order.OrderId, command);
            }
            command.Transaction.Commit();
            connection.Close();
            return orders;
        }

        public List<Order> FindAllByState(string filter, List<Order> orders)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Orders WHERE state = @State";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@State", filter);
            command.Transaction = connection.BeginTransaction();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    order.OrderId = (long)reader["order_id"];
                    order.DeliveryDate = (DateTime)reader["delivery_date"];
                    order.DispatchDate = (DateTime)reader["dispatch_date"];
                    order.State = reader["state"].ToString();
                    order.TotalPrice = (double)reader["total_price"];
                    order.Customer = new CustomerServicesImplements().FindById((long)reader["customer_customer_id"]);
                    order.PaymentMethod = new PaymentMethodServicesImplements().FindById((long)reader["payment_method_id"]);
                    orders.Add(order);
                }
                reader.Close();
            }
            foreach (Order order in orders)
            {
                order.OrderDetailList = GetOrderDetails(order.OrderId, command);
            }
            command.Transaction.Commit();
            connection.Close();
            return orders;
        }

        public List<Order> FindAllByCustomerIdAndDate(long id, string filter, List<Order> orders)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Orders WHERE customer_customer_id = @CustomerId and state = 'active' ORDER BY dispatch_date ";
            query += (filter.Equals("oldest")) ? "ASC" : "DESC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            command.Transaction = connection.BeginTransaction();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    order.OrderId = (long)reader["order_id"];
                    order.DeliveryDate = (DateTime)reader["delivery_date"];
                    order.DispatchDate = (DateTime)reader["dispatch_date"];
                    order.State = reader["state"].ToString();
                    order.TotalPrice = (double)reader["total_price"];
                    order.Customer = new CustomerServicesImplements().FindById((long)reader["customer_customer_id"]);
                    order.PaymentMethod = new PaymentMethodServicesImplements().FindById((long)reader["payment_method_id"]);
                    orders.Add(order);
                }
                reader.Close();
            }
            foreach (Order order in orders)
            {
                order.OrderDetailList = GetOrderDetails(order.OrderId, command);
            }
            command.Transaction.Commit();
            connection.Close();
            return orders;
        }

        public List<Order> FindAllByDate(string filter, List<Order> orders)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Orders ORDER BY dispatch_date ";
            query += (filter.Equals("oldest")) ? "ASC" : "DESC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Transaction = connection.BeginTransaction();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    order.OrderId = (long)reader["order_id"];
                    order.DeliveryDate = (DateTime)reader["delivery_date"];
                    order.DispatchDate = (DateTime)reader["dispatch_date"];
                    order.State = reader["state"].ToString();
                    order.TotalPrice = (double)reader["total_price"];
                    order.Customer = new CustomerServicesImplements().FindById((long)reader["customer_customer_id"]);
                    order.PaymentMethod = new PaymentMethodServicesImplements().FindById((long)reader["payment_method_id"]);
                    orders.Add(order);
                }
                reader.Close();
            }
            foreach (Order order in orders)
            {
                order.OrderDetailList = GetOrderDetails(order.OrderId, command);
            }
            command.Transaction.Commit();
            connection.Close();
            return orders;
        }

        public Order FindById(long id)
        {
            Order order = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Orders WHERE order_id = @OrderId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Transaction = connection.BeginTransaction();
            command.Parameters.AddWithValue("@OrderId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    order = new Order();
                    order.OrderId = (long)reader["order_id"];
                    order.DeliveryDate = (DateTime)reader["delivery_date"];
                    order.DispatchDate = (DateTime)reader["dispatch_date"];
                    order.State = reader["state"].ToString();
                    order.TotalPrice = (double)reader["total_price"];
                    order.Customer = new CustomerServicesImplements().FindById((long)reader["customer_customer_id"]);
                    order.PaymentMethod = new PaymentMethodServicesImplements().FindById((long)reader["payment_method_id"]);
                }
            }
            if (order.OrderId > 0) order.OrderDetailList = GetOrderDetails(order.OrderId, command);
            command.Transaction.Commit();
            connection.Close();
            return order;
        }

        public void Save(Order o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query;
            query = (o.OrderId > 0) ? "UPDATE Orders set state = @State WHERE order_id = @OrderId" :
                                      "INSERT INTO Orders (delivery_date, dispatch_date, state, total_price, customer_customer_id, " +
                                      "payment_method_id) VALUES(@DeliveryDate, @DispatchDate, @State, @TotalPrice, @CustomerId, " +
                                      "@PaymentMethodId)";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Transaction = connection.BeginTransaction();
            if (o.OrderId == 0)
            {
                sqlCommand.Parameters.AddWithValue("@DeliveryDate", o.DeliveryDate);
                sqlCommand.Parameters.AddWithValue("@DispatchDate", o.DispatchDate);
                sqlCommand.Parameters.AddWithValue("@State", o.State);
                sqlCommand.Parameters.AddWithValue("@TotalPrice", o.TotalPrice);
                sqlCommand.Parameters.AddWithValue("@CustomerId", o.Customer.CustomerId);
                sqlCommand.Parameters.AddWithValue("@PaymentMethodId", o.PaymentMethod.PaymentMethodId);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
                SaveOrderDetails(o.OrderDetailList, sqlCommand);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@State", o.State);
                sqlCommand.Parameters.AddWithValue("@OrderId", o.OrderId);
                sqlCommand.ExecuteNonQuery();
            }
            sqlCommand.Transaction.Commit();
            connection.Close();
        }

        public List<OrderDetail> GetOrderDetails(long id, SqlCommand command)
        {
            command.Parameters.Clear();
            List<OrderDetail> OrderDetailList = new List<OrderDetail>();
            string query = "SELECT * FROM Order_Details WHERE order_detail_order_id = @OrderId";
            command.CommandText = query;
            command.Parameters.AddWithValue("@OrderId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderDetailOrderId = (long)reader["order_detail_order_id"];
                    orderDetail.Product = new ProductServicesImplements().FindById((long)reader["product_product_id"]);
                    orderDetail.Quantity = (int)reader["quantity"];
                    orderDetail.TotalPrice = (double)reader["total_price"];
                    orderDetail.UnitPrice = (double)reader["unit_price"];
                    orderDetail.ServicePrice = (double)reader["service_price"];
                    long serviceId = (reader["service_service_id"] != DBNull.Value) ? (long)reader["service_service_id"] : 0;
                    if (serviceId > 0)
                    {
                        orderDetail.AddService();
                        orderDetail.Service = new ServiceServicesImplements().FindById(serviceId);
                    }
                    OrderDetailList.Add(orderDetail);
                }
            }
            return OrderDetailList;
        }

        private void SaveOrderDetails(List<OrderDetail> OrderDetailList, SqlCommand sqlCommand)
        {
            long orderId = Convert.ToInt64(GetLastOrderId());
            foreach (OrderDetail order in OrderDetailList)
            {
                string query = "INSERT INTO Order_Details (order_detail_order_id, product_product_id, quantity, total_price, unit_price, service_price, " +
                               "service_service_id) VALUES(@OrderId, @ProductId, @Quantity, @TotalPrice, @UnitePrice, @ServicePrice, @ServiceId)";
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.AddWithValue("@OrderId", orderId);
                sqlCommand.Parameters.AddWithValue("@ProductId", order.Product.ProductId);
                sqlCommand.Parameters.AddWithValue("@Quantity", order.Quantity);
                sqlCommand.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                sqlCommand.Parameters.AddWithValue("@UnitePrice", order.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@ServicePrice", order.ServicePrice);
                if (order.Service != null) sqlCommand.Parameters.AddWithValue("@ServiceId", order.Service.ServiceId);
                else sqlCommand.Parameters.AddWithValue("@ServiceId", DBNull.Value);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
            }
        }

        private decimal GetLastOrderId()
        {
            decimal orderId = 0;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "EXEC ORDER_LAST_ID";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    orderId = (decimal)reader["GO"];
                }
            }
            connection.Close();
            return orderId;
        }

    }
}
