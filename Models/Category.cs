namespace tecnovision_backend.Models
{
    public class Category
    {

        private long id;
        private string name;
        private bool state;
        private Discount discount;

        public Category()
        {
            this.id = 0;
            this.name = "";
            this.state = true;
        }

        public Category(long id, string name, bool state)
        {
            this.id = id;
            this.name = name;
            this.state = state;
        }

        public void AddDiscount() => this.discount = new Discount();

        public long Id
        {
            get => id;
            set => id = value;
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
