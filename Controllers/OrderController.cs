using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/order")]
    public class OrderController : Controller
    {
        [HttpGet("list")]
        public List<Order> ListOrders()
        {
            OrderServicesImplements orderServicesImplements = new OrderServicesImplements();
            return orderServicesImplements.FindAll();
        }


        [HttpGet("view/{id}")]
        public Order ViewOrder(long id)
        {
            OrderServicesImplements orderServicesImplements = new OrderServicesImplements();
            return orderServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string SaveOrder([FromBody] Order order)
        {
            string message = (order.Id == 0) ? "El pedido ha sido registrado" : "Datos actualizados correctamente";
            try
            {
                OrderServicesImplements orderServicesImplements = new OrderServicesImplements();
                orderServicesImplements.Save(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                message = (order.Id == 0) ? "Error al crear el pedido" : "Error al actualizar los datos";
            }
            return message;
        }

    }
}
