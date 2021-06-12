namespace tecnovision_backend.Models
{
    public class Brand
    {

        private string brandName;
        private long brandId;
        private bool state;

        public Brand()
        {
            this.brandId = 0;
            this.brandName = "";
            this.state = true;
        }

        public Brand(long brandId, string brandName, bool state)
        {
            this.brandId = brandId;
            this.brandName = brandName;
            this.state = state;
        }

        public string BrandName
        {
            get => brandName;
            set => brandName = value;
        }

        public long BrandId
        {
            get => brandId;
            set => brandId = value;
        }

        public bool State
        {
            get => state;
            set => state = value;
        }

    }
}
