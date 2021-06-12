using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {

        [HttpGet("check/{userType}")]
        public string[] CheckLogin(string person, string userType)
        {
            string[] data = { "0", "N/A" };
            switch (userType)
            {
                case "administrator":
                    Administrator administrator = JsonConvert.DeserializeObject<Administrator>(person);
                    administrator = GetIdAdministrator(administrator);
                    if (administrator != null)
                    {
                        data[0] = administrator.AdministratorId.ToString();
                        data[1] = "administrator";
                    }
                    break;
                case "customer":
                    Customer customer = JsonConvert.DeserializeObject<Customer>(person);
                    customer = GetIdCustomer(customer);
                    if (customer != null)
                    {
                        data[0] = customer.CustomerId.ToString();
                        data[1] = "customer";
                    }
                    break;
            }
            return data;
        }

        public Customer GetIdCustomer(Customer customer)
        {
            try
            {
                customer = new CustomerServicesImplements().Login(customer.Email, customer.Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return customer;
        }

        public Administrator GetIdAdministrator(Administrator administrator)
        {
            try
            {
                administrator = new AdministratorServicesImplements().Login(administrator.Email, administrator.Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

            }
            return administrator;
        }

    }
}
