using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/customer")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("list")]
        public List<Customer> ListCustomers()
        {
            CustomerServicesImplements customerServicesImplements = new CustomerServicesImplements();
            return customerServicesImplements.FindAll();
        }

        [HttpGet("view/{id}")]
        public Customer ViewCustomer(long id)
        {
            CustomerServicesImplements customerServicesImplements = new CustomerServicesImplements();
            return customerServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string SaveCustomer([FromBody] Customer customer)
        {
            string message = (customer.Id == 0) ? "El cliente ha sido registrado" : "Datos actualizados correctamente";
            try
            {
                CustomerServicesImplements customerServicesImplements = new CustomerServicesImplements();
                customerServicesImplements.Save(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                message = (customer.Id == 0) ? "Error al crear el cliente" : "Error al actualizar los datos";
            }
            return message;
        }
    }
}
