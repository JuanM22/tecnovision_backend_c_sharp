namespace tecnovision_backend.Models
{
    public class Product
    {

        private long id, code;
        private string description, name, imagePath;
        private int stock;
        private double unitPrice;
        private bool state;
        private Category category;
        private Brand brand;
        private Supplier supplier;

        public Product()
        {
            this.category = new Category();
            this.brand = new Brand();
            this.supplier = new Supplier();
        }

        public Product(long id, long code, string description, string name, string imagePath, int stock, double unitPrice, bool state)
        {
            this.id = id;
            this.code = code;
            this.description = description;
            this.name = name;
            this.imagePath = imagePath;
            this.stock = stock;
            this.unitPrice = unitPrice;
            this.state = state;
        }

        public long Id
        {
            get => id;
            set => id = value;
        }

        public long Code
        {
            get => code;
            set => code = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string ImagePath
        {
            get => imagePath;
            set => imagePath = value;
        }

        public int Stock
        {
            get => stock;
            set => stock = value;
        }

        public double UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }

        public bool State
        {
            get => state;
            set => state = value;
        }

        public Category Category
        {
            get => category;
            set => category = value;
        }

        public Brand Brand
        {
            get => brand;
            set => brand = value;
        }

        public Supplier Supplier
        {
            get => supplier;
            set => supplier = value;
        }

    }
}
