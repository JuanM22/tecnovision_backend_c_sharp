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
        public List<Order> ListOrders(long personId, string filter)
        {
            OrderServicesImplements orderServicesImplements = new OrderServicesImplements();
            List<Order> orders = new List<Order>();
            if (filter.Equals("None")) orders = ListWithoutFilter(personId, orders, orderServicesImplements);
            else if (filter.Contains("Ones")) orders = ListByOrderState(personId, orders, filter, orderServicesImplements);
            else orders = ListByDate(personId, orders, filter, orderServicesImplements);
            return orders;
        }


        [HttpGet("view/{id}")]
        public Order ViewOrder(long id)
        {
            OrderServicesImplements orderServicesImplements = new OrderServicesImplements();
            return orderServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string[] SaveOrder([FromBody] Order order)
        {
            string[] messages = new string[1];
            messages[0] = (order.OrderId == 0) ? "El pedido ha sido registrado" : "Datos actualizados correctamente";
            try
            {
                OrderServicesImplements orderServicesImplements = new OrderServicesImplements();
                orderServicesImplements.Save(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                messages[0] = (order.OrderId == 0) ? "Error al crear el pedido" : "Error al actualizar los datos";
            }
            return messages;
        }

        public List<Order> ListWithoutFilter(long id, List<Order> orders, OrderServicesImplements orderServicesImplements)
        {
            if (id > 0)
            {
                orders = orderServicesImplements.FindAllByCustomerIdAndState(id, "active", orders);
            }
            else
            {
                orders = orderServicesImplements.FindAll();
            }
            return orders;
        }

        public List<Order> ListByOrderState(long id, List<Order> orders, string filter, OrderServicesImplements orderServicesImplements)
        {
            filter = filter.Replace("Ones", "");
            if (id > 0)
            {
                orders = orderServicesImplements.FindAllByCustomerIdAndState(id, filter, orders);
            }
            else
            {
                orders = orderServicesImplements.FindAllByState(filter, orders);
            }
            return orders;
        }

        public List<Order> ListByDate(long id, List<Order> orders, string filter, OrderServicesImplements orderServicesImplements)
        {
            if (id > 0)
            {
                orders = orderServicesImplements.FindAllByCustomerIdAndDate(id, filter, orders);
            }
            else
            {
                orders = orderServicesImplements.FindAllByDate(filter, orders);
            }
            return orders;
        }
    }
}
