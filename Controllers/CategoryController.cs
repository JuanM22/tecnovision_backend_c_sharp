using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/category")]
    public class CategoryController : ControllerBase
    {

        [HttpGet("list")]
        public List<Category> ListCategories()
        {
            CategoryServicesImplements categoryServicesImplements = new CategoryServicesImplements();
            return categoryServicesImplements.FindAll();
        }


        [HttpGet("view/{id}")]
        public Category ViewCategory(long id)
        {
            CategoryServicesImplements categoryServicesImplements = new CategoryServicesImplements();
            return categoryServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string[] SaveBrand([FromBody] Category category)
        {
            string[] messages = new string[1];
            messages[0] = (category.CategoryId == 0) ? "La categoría ha sido registrada" : "Datos actualizados correctamente";
            try
            {
                CategoryServicesImplements categoryServicesImplements = new CategoryServicesImplements();
                categoryServicesImplements.Save(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                messages[0] = (category.CategoryId == 0) ? "Error al crear la categoría" : "Error al actualizar los datos";
            }
            return messages;
        }
    }
}
