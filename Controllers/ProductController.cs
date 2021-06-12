using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/product")]
    public class ProductController : Controller
    {

        [HttpGet("list")]
        public List<Product> ListProducts()
        {
            ProductServicesImplements productServicesImplements = new ProductServicesImplements();
            return productServicesImplements.FindAll();
        }


        [HttpGet("view/{id}")]
        public Product ViewProduct(long id)
        {
            ProductServicesImplements productServicesImplements = new ProductServicesImplements();
            return productServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string SaveProduct([FromBody] Product product)
        {
            string message = (product.Id == 0) ? "El producto ha sido registrado" : "Datos actualizados correctamente";
            try
            {
                ProductServicesImplements productServicesImplements = new ProductServicesImplements();
                productServicesImplements.Save(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                message = (product.Id == 0) ? "Error al crear el producto" : "Error al actualizar los datos";
            }
            return message;
        }
    }
}
