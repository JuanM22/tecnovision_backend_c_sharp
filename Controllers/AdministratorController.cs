using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/administrator")]
    public class AdministratorController : ControllerBase
    {

        [HttpGet("list")]
        public List<Administrator> ListAdministrators()
        {
            AdministratorServicesImplements administratorServicesImplements = new AdministratorServicesImplements();
            return administratorServicesImplements.FindAll();
        }

        [HttpGet("view/{id}")]
        public Administrator ViewAdministrator(long id)
        {
            AdministratorServicesImplements administratorServicesImplements = new AdministratorServicesImplements();
            return administratorServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string SaveAdministrator([FromBody] Administrator administrator)
        {
            string message = (administrator.Id == 0) ? "El administrator ha sido registrado" : "Datos actualizados correctamente";
            try
            {
                AdministratorServicesImplements administratorServicesImplements = new AdministratorServicesImplements();
                administratorServicesImplements.Save(administrator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                message = (administrator.Id == 0) ? "Error al crear el administrator" : "Error al actualizar los datos";
            }
            return message;
        }

    }
}
