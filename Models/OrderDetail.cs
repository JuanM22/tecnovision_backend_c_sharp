namespace tecnovision_backend.Models
{
    public class OrderDetail
    {

        private long orderDetailOrderId;
        private int quantity;
        private double totalPrice, unitPrice, servicePrice;
        private Service service;
        private Product product;

        public OrderDetail()
        {
            this.orderDetailOrderId = 0;
            this.quantity = 0;
            this.totalPrice = 0;
            this.unitPrice = 0;
            this.servicePrice = 0;
            this.product = new Product();
        }

        public OrderDetail(long orderDetailOrderId, int quantity, double totalPrice, double unitPrice, double servicePrice)
        {
            this.orderDetailOrderId = 0;
            this.quantity = 0;
            this.totalPrice = 0;
            this.unitPrice = 0;
            this.servicePrice = 0;
            this.product = new Product();
        }

        public void AddService() => this.service = new Service();

        public long OrderDetailOrderId
        {
            get => orderDetailOrderId;
            set => orderDetailOrderId = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public double TotalPrice
        {
            get => totalPrice;
            set => totalPrice = value;
        }

        public double UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }

        public double ServicePrice
        {
            get => servicePrice;
            set => servicePrice = value;
        }

        public Service Service
        {
            get => service;
            set => service = value;
        }

        public Product Product
        {
            get => product;
            set => product = value;
        }

    }
}
