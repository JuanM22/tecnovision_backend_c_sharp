using System;
using System.Collections.Generic;

namespace tecnovision_backend.Models
{
    public class Order
    {

        private long orderId;
        private DateTime deliveryDate, dispatchDate;
        private string state;
        private double totalPrice;
        private Customer customer;
        private PaymentMethod paymentMethod;
        private List<OrderDetail> orderDetailList;

        public Order()
        {
            this.orderId = 0;
            this.deliveryDate = new DateTime();
            this.dispatchDate = new DateTime();
            this.state = "active";
            this.totalPrice = 0;
            this.customer = new Customer();
            this.paymentMethod = new PaymentMethod();
            this.orderDetailList = new List<OrderDetail>();
        }

        public Order(long orderId, DateTime deliveryDate, DateTime dispatchDate, string state, double totalPrice)
        {
            this.orderId = orderId;
            this.deliveryDate = deliveryDate;
            this.dispatchDate = dispatchDate;
            this.state = state;
            this.totalPrice = totalPrice;
            this.customer = new Customer();
            this.paymentMethod = new PaymentMethod();
            this.orderDetailList = new List<OrderDetail>();
        }

        public long OrderId
        {
            get => orderId;
            set => orderId = value;
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

        public string State
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

        public List<OrderDetail> OrderDetailList
        {
            get => orderDetailList;
            set => orderDetailList = value;
        }

    }
}