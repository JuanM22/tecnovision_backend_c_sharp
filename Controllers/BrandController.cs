using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{
    [Route("/brand")]
    public class BrandController : ControllerBase
    {

        [HttpGet("list")]
        public List<Brand> ListBrands()
        {
            BrandServicesImplements brandServicesImplements = new BrandServicesImplements();
            return brandServicesImplements.FindAll();
        }

        [HttpGet("view/{id}")]
        public Brand ViewBrand(long id)
        {
            BrandServicesImplements brandServicesImplements = new BrandServicesImplements();
            return brandServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string[] SaveBrand([FromBody] Brand brand)
        {
            string[] messages = new string[1];
            messages[0] = (brand.BrandId == 0) ? "La marca ha sido registrada" : "Datos actualizados correctamente";
            try
            {
                BrandServicesImplements brandServicesImplements = new BrandServicesImplements();
                brandServicesImplements.Save(brand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                messages[0] = (brand.BrandId == 0) ? "Error al crear la marca" : "Error al actualizar los datos";
            }
            return messages;
        }

    }
}
