using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{
    [Route("/city")]
    public class CityController : ControllerBase
    {


        [HttpGet("list")]
        public List<City> ListCities()
        {

            //SqlConnection connection = DBConnection.GetConnection();

            //string query = "INSERT INTO Cities (city_name) VALUES (@CityName)";
            //SqlCommand sqlCommand = new SqlCommand(query, connection);
            //connection.Open();
            //sqlCommand.Parameters.AddWithValue("@CityName", "POPAYÁN");
            //sqlCommand.ExecuteNonQuery();
            //connection.Close();

            //City city = new City();
            //city.CityId = 1;
            //city.CityName = "Tunja";
            CityServicesImplements cityServicesImplements = new CityServicesImplements();
            return cityServicesImplements.FindAll();
        }

    }
}

