namespace tecnovision_backend.Models
{
    public class Brand
    {

        private string brandName;
        private long id;
        private bool state;

        public Brand()
        {
            this.id = 0;
            this.brandName = "";
            this.state = true;
        }

        public Brand(long id, string brandName, bool state)
        {
            this.id = id;
            this.brandName = brandName;
            this.state = state;
        }

        public string BrandName
        {
            get => brandName;
            set => brandName = value;
        }

        public long Id
        {
            get => id;
            set => id = value;
        }

        public bool State
        {
            get => state;
            set => state = value;
        }

    }
}
