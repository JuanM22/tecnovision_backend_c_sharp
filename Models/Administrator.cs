using System.Numerics;

namespace tecnovision_backend.Models
{
    public class Administrator
    {

        private long administratorId, document;
        private string address, email, lastName, name, password;
        private decimal phone;
        private bool state;
        private City city;

        public Administrator()
        {
            this.administratorId = 0;
            this.document = 0;
            this.address = "";
            this.email = "";
            this.lastName = "";
            this.name = "";
            this.password = "";
            this.phone = 0;
            this.state = true;
            this.city = new City();
        }

        public Administrator(long administratorId, long document, string address, string email, string lastName, string name, string password, decimal phone, bool state)
        {
            this.administratorId = administratorId;
            this.document = document;
            this.address = address;
            this.email = email;
            this.lastName = lastName;
            this.name = name;
            this.password = password;
            this.phone = phone;
            this.state = state;
            this.city = new City();
        }

        public long AdministratorId
        {
            get => administratorId;
            set => administratorId = value;
        }

        public long Document
        {
            get => document;
            set => document = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
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
