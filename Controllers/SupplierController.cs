using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/supplier")]
    public class SupplierController : Controller
    {

        [HttpGet("list")]
        public List<Supplier> ListSuppliers()
        {
            SupplierServicesImplements supplierServicesImplements = new SupplierServicesImplements();
            return supplierServicesImplements.FindAll();
        }


        [HttpGet("view/{id}")]
        public Supplier ViewSupplier(long id)
        {
            SupplierServicesImplements supplierServicesImplements = new SupplierServicesImplements();
            return supplierServicesImplements.FindById(id);
        }

        [HttpPost("save")]
        public string SaveSupplier([FromBody] Supplier supplier)
        {
            string message = (supplier.Id == 0) ? "El proveedor ha sido registrado" : "Datos actualizados correctamente";
            try
            {
                SupplierServicesImplements supplierServicesImplements = new SupplierServicesImplements();
                supplierServicesImplements.Save(supplier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                message = (supplier.Id == 0) ? "Error al crear el proveedor" : "Error al actualizar los datos";
            }
            return message;
        }
    }
}
