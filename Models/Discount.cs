namespace tecnovision_backend.Models
{
    public class Discount
    {

        private long discountId;
        private bool state;
        private double value;

        public Discount()
        {
            this.discountId = 0;
            this.state = true;
            this.value = 0;
        }

        public Discount(long discountId, bool state, double value)
        {
            this.discountId = discountId;
            this.state = state;
            this.value = value;
        }

        public long DiscountId
        {
            get => discountId;
            set => discountId = value;
        }

        public bool State
        {
            get => state;
            set => state = value;
        }

        public double Value
        {
            get => value;
            set => this.value = value;
        }

    }
}
