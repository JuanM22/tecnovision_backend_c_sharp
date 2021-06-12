using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/discount")]
    public class DiscountController : Controller
    {
        [HttpGet("list")]
        public List<Discount> ListDiscounts()
        {
            DiscountServicesImplements discountServicesImplements = new DiscountServicesImplements();
            return discountServicesImplements.FindAll();
        }


        [HttpGet("view/{id}")]
        public Discount ViewDiscount(long id)
        {
            DiscountServicesImplements discountServicesImplements = new DiscountServicesImplements();
            return discountServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string SaveDiscount([FromBody] Discount discount)
        {
            string message = (discount.Id == 0) ? "El descuento ha sido registrado" : "Datos actualizados correctamente";
            try
            {
                DiscountServicesImplements discountServicesImplements = new DiscountServicesImplements();
                discountServicesImplements.Save(discount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                message = (discount.Id == 0) ? "Error al crear el descuento" : "Error al actualizar los datos";
            }
            return message;
        }

    }
}
