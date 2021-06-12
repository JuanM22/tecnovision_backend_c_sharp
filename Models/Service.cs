namespace tecnovision_backend.Models
{
    public class Service
    {

        private string description, name;
        private long serviceId;
        private double value;
        private bool state;

        public Service()
        {
            this.description = "";
            this.serviceId = 0;
            this.name = "";
            this.value = 0;
            this.state = true;
        }
        public Service(string description, long serviceId, string name, double value, bool state)
        {
            this.description = description;
            this.serviceId = serviceId;
            this.name = name;
            this.value = 0;
            this.state = state;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public long ServiceId
        {
            get => serviceId;
            set => serviceId = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Value
        {
            get => value;
            set => this.value = value;
        }

        public bool State
        {
            get => state;
            set => state = value;
        }


    }
}
