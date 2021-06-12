using System;
using System.Collections.Generic;

namespace tecnovision_backend.Models
{
    public class Order
    {

        private long id;
        private DateTime deliveryDate, dispatchDate;
        private bool state;
        private double totalPrice;
        private Customer customer;
        private PaymentMethod paymentMethod;
        private List<OrderDetail> orderDetails;

        public Order()
        {
            this.id = 0;
            this.deliveryDate = new DateTime();
            this.dispatchDate = new DateTime();
            this.state = true;
            this.totalPrice = 0;
            this.customer = new Customer();
            this.paymentMethod = new PaymentMethod();
            this.orderDetails = new List<OrderDetail>();
        }

        public Order(long id, DateTime deliveryDate, DateTime dispatchDate, bool state, double totalPrice)
        {
            this.id = id;
            this.deliveryDate = deliveryDate;
            this.dispatchDate = dispatchDate;
            this.state = state;
            this.totalPrice = totalPrice;
            this.customer = new Customer();
            this.paymentMethod = new PaymentMethod();
            this.orderDetails = new List<OrderDetail>();
        }

        public long Id
        {
            get => id;
            set => id = value;
        }

        public DateTime DeliveryDate
        {
            get => deliveryDate;
            set => deliveryDate = value;
        }

        public DateTime DispatchDate
        {
            get => dispatchDate;
            set => dispatchDate = value;
        }

        public bool State
        {
            get => state;
            set => state = value;
        }

        public double TotalPrice
        {
            get => totalPrice;
            set => totalPrice = value;
        }

        public Customer Customer
        {
            get => customer;
            set => customer = value;
        }

        public PaymentMethod PaymentMethod
        {
            get => paymentMethod;
            set => paymentMethod = value;
        }

        public List<OrderDetail> OrderDetails
        {
            get => orderDetails;
            set => orderDetails = value;
        }

    }
}