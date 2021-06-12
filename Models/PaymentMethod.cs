namespace tecnovision_backend.Models
{
    public class PaymentMethod
    {

        private long paymentMethodId;
        private string paymentMethod;

        public PaymentMethod()
        {
            this.paymentMethodId = 0;
            this.paymentMethod = "";
        }

        public PaymentMethod(long paymentMethodId, string paymentMethod)
        {
            this.paymentMethodId = paymentMethodId;
            this.paymentMethod = paymentMethod;
        }

        public long PaymentMethodId
        {
            get => paymentMethodId;
            set => paymentMethodId = value;
        }

        public string PAYMENTMETHOD
        {
            get => paymentMethod;
            set => paymentMethod = value;
        }


    }
}
