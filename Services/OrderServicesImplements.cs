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
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    order.Id = (long)reader["order_id"];
                    order.DeliveryDate = (DateTime)reader["delivery_date"];
                    order.DispatchDate = (DateTime)reader["dispatch_date"];
                    order.State = (bool)reader["state"];
                    order.TotalPrice = (double)reader["total_price"];
                    order.Customer = new CustomerServicesImplements().FindById((long)reader["customer_customer_id"]);
                    order.PaymentMethod = new PaymentMethodServicesImplements().FindById((long)reader["payment_method_id"]);
                    order.OrderDetails = GetOrderDetails(order.Id);
                    orders.Add(order);
                }
            }
            connection.Close();
            foreach (Order order in orders)
            {
                order.OrderDetails = GetOrderDetails(order.Id);
            }
            return orders;
        }

        public Order FindById(long id)
        {
            Order order = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Orders WHERE order_id = @OrderId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    order = new Order();
                    order.Id = (long)reader["order_id"];
                    order.DeliveryDate = (DateTime)reader["delivery_date"];
                    order.DispatchDate = (DateTime)reader["dispatch_date"];
                    order.State = (bool)reader["state"];
                    order.TotalPrice = (double)reader["total_price"];
                    order.Customer = new CustomerServicesImplements().FindById((long)reader["customer_customer_id"]);
                    order.PaymentMethod = new PaymentMethodServicesImplements().FindById((long)reader["payment_method_id"]);
                    order.OrderDetails = GetOrderDetails(order.Id);
                }
            }
            connection.Close();
            order.OrderDetails = GetOrderDetails(order.Id);
            return order;
        }

        public void Save(Order o)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string query = "INSERT INTO Orders (delivery_date, dispatch_date, state, total_price, customer_customer_id, " +
                           "payment_method_id) VALUES(@DeliveryDate, @DispatchDate, @State, @TotalPrice, @CustomerId, @PaymentMethodId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@DeliveryDate", o.DeliveryDate);
            sqlCommand.Parameters.AddWithValue("@DispatchDate", o.DispatchDate);
            sqlCommand.Parameters.AddWithValue("@State", o.State);
            sqlCommand.Parameters.AddWithValue("@TotalPrice", o.TotalPrice);
            sqlCommand.Parameters.AddWithValue("@CustomerId", o.Customer.Id);
            sqlCommand.Parameters.AddWithValue("@PaymentMethodId", o.PaymentMethod.PaymentMethodId);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            SaveOrderDetails(o.OrderDetails);
        }

        public List<OrderDetail> GetOrderDetails(long id)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Order_Details WHERE order_detail_order_id = @OrderId";
            SqlCommand command = new SqlCommand(query, connection);
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
                    orderDetail.TotalPrice = (double)reader["unit_price"];
                    orderDetail.TotalPrice = (double)reader["service_price"];
                    long serviceId = (reader["service_service_id"] != DBNull.Value) ? (long)reader["service_service_id"] : 0;
                    if (serviceId > 0)
                    {
                        orderDetail.AddService();
                        orderDetail.Service.Id = serviceId;
                    }
                    orderDetails.Add(orderDetail);
                }
            }
            connection.Close();
            return orderDetails;
        }

        private void SaveOrderDetails(List<OrderDetail> orderDetails)
        {
            long orderId = Convert.ToInt64(GetLastOrderId());
            foreach (OrderDetail order in orderDetails)
            {
                SqlConnection connection = DBConnection.GetConnection();
                string query = "INSERT INTO Order_Details (order_detail_order_id, product_product_id, quantity, total_price, unit_price, service_price, " +
                               "service_service_id) VALUES(@OrderId, @ProductId, @Quantity, @TotalPrice, @UnitePrice, @ServicePrice, @ServiceId)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@OrderId", orderId);
                sqlCommand.Parameters.AddWithValue("@ProductId", order.Product.Id);
                sqlCommand.Parameters.AddWithValue("@Quantity", order.Quantity);
                sqlCommand.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                sqlCommand.Parameters.AddWithValue("@UnitePrice", order.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@ServicePrice", order.ServicePrice);
                if (order.Service != null) sqlCommand.Parameters.AddWithValue("@ServiceId", order.Service.Id);
                else sqlCommand.Parameters.AddWithValue("@ServiceId", DBNull.Value);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
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
