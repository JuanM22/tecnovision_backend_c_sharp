namespace tecnovision_backend.Models
{
    public class PaymentMethod
    {

        private long paymentMethodId;
        private string paymentMethodName;

        public PaymentMethod()
        {
            this.paymentMethodId = 0;
            this.paymentMethodName = "";
        }

        public PaymentMethod(long paymentMethodId, string paymentMethodName)
        {
            this.paymentMethodId = paymentMethodId;
            this.paymentMethodName = paymentMethodName;
        }

        public long PaymentMethodId
        {
            get => paymentMethodId;
            set => paymentMethodId = value;
        }

        public string PaymentMethodName
        {
            get => paymentMethodName;
            set => paymentMethodName = value;
        }


    }
}
