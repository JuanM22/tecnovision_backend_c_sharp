using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/service")]
    public class ServiceController : Controller
    {

        [HttpGet("list")]
        public List<Service> ListServices()
        {
            ServiceServicesImplements serviceServicesImplements = new ServiceServicesImplements();
            return serviceServicesImplements.FindAll();
        }


        [HttpGet("view/{id}")]
        public Service ViewService(long id)
        {
            ServiceServicesImplements serviceServicesImplements = new ServiceServicesImplements();
            return serviceServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string SaveService([FromBody] Service service)
        {
            string message = (service.Id == 0) ? "El servicio ha sido registrado" : "Datos actualizados correctamente";
            try
            {
                ServiceServicesImplements serviceServicesImplements = new ServiceServicesImplements();
                serviceServicesImplements.Save(service);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                message = (service.Id == 0) ? "Error al crear el servicio" : "Error al actualizar los datos";
            }
            return message;
        }
    }
}
