namespace tecnovision_backend.Models
{
    public class City
    {

        private long cityId;
        private string cityName;

        public City()
        {
            this.cityId = 0;
            this.cityName = "";
        }

        public City(long cityId, string cityName)
        {
            this.cityId = cityId;
            this.cityName = cityName;
        }

        public long CityId
        {
            get => cityId;
            set => cityId = value;
        }

        public string CityName
        {
            get => cityName;
            set => cityName = value;
        }

    }
}
