using System.Numerics;

namespace tecnovision_backend.Models
{
    public class Supplier
    {

        private long supplierId;
        private string email, name, nit;
        private decimal phone;
        private bool state;
        private City city;

        public Supplier()
        {
            this.supplierId = 0;
            this.email = "";
            this.name = "";
            this.nit = "";
            this.phone = 0;
            this.state = true;
            this.city = new City();
        }

        public Supplier(long supplierId, string email, string name, string nit, decimal phone, bool state)
        {
            this.supplierId = supplierId;
            this.email = email;
            this.name = name;
            this.nit = nit;
            this.phone = phone;
            this.state = state;
            this.city = new City();
        }

        public long SupplierId
        {
            get => supplierId;
            set => supplierId = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Nit
        {
            get => nit;
            set => nit = value;
        }

        public decimal Phone
        {
            get => phone;
            set => phone = value;
        }

        public bool State
        {
            get => state;
            set => state = value;
        }

        public City City
        {
            get => city;
            set => city = value;
        }

    }
}
