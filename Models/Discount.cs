namespace tecnovision_backend.Models
{
    public class Discount
    {

        private long id;
        private bool state;
        private double value;

        public Discount()
        {
            this.id = 0;
            this.state = true;
            this.value = 0;
        }

        public Discount(long id, bool state, double value)
        {
            this.id = id;
            this.state = state;
            this.value = value;
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

        public double Value
        {
            get => value;
            set => this.value = value;
        }

    }
}
