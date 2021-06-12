namespace tecnovision_backend.Models
{
    public class Service
    {

        private string description, name;
        private long id;
        private bool state;

        public Service()
        {
            this.description = "";
            this.id = 0;
            this.name = "";
            this.state = true;
        }
        public Service(string description, long id, string name, bool state)
        {
            this.description = description;
            this.id = id;
            this.name = name;
            this.state = state;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

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


    }
}
