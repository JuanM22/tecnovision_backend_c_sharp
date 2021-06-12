namespace tecnovision_backend.Models
{
    public class Category
    {

        private long categoryId;
        private string name;
        private bool state;
        private Discount discount;

        public Category()
        {
            this.categoryId = 0;
            this.name = "";
            this.state = true;
        }

        public Category(long categoryId, string name, bool state)
        {
            this.categoryId = categoryId;
            this.name = name;
            this.state = state;
        }

        public void AddDiscount() => this.discount = new Discount();

        public long CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public bool State
        {
            get => state;
            set => state = value;
        }

        public Discount Discount
        {
            get => discount;
            set => discount = value;
        }

    }
}
