using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tecnovision_backend.Controllers;
using tecnovision_backend.Interfaces;
using tecnovision_backend.Models;

namespace tecnovision_backend.Services
{
    public class PaymentMethodServicesImplements : ITransferObjetcs<PaymentMethod>
    {
        public List<PaymentMethod> FindAll()
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Payment_Methods";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    PaymentMethod paymentMethod = new PaymentMethod((long)reader["payment_method_id"], reader["payment_method"].ToString());
                    paymentMethods.Add(paymentMethod);
                }
            }
            connection.Close();

            return paymentMethods;
        }

        public PaymentMethod FindById(long id)
        {
            PaymentMethod paymentMethod = null;
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Payment_Methods WHERE payment_method_id = @PaymentMethodId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PaymentMethodId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    paymentMethod = new PaymentMethod((long)reader["payment_method_id"], reader["payment_method"].ToString());
                }
            }
            connection.Close();
            return paymentMethod;
        }

        public void Save(PaymentMethod o)
        {
            throw new NotImplementedException();
        }

    }
}
