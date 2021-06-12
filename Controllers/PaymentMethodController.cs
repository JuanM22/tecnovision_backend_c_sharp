using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tecnovision_backend.Models;
using tecnovision_backend.Services;

namespace tecnovision_backend.Controllers
{

    [Route("/paymentMethod")]
    public class PaymentMethodController : Controller
    {
        [HttpGet("list")]
        public List<PaymentMethod> ListPaymentMethods()
        {
            PaymentMethodServicesImplements paymentMethodServicesImplements = new PaymentMethodServicesImplements();
            return paymentMethodServicesImplements.FindAll();
        }


    }
}
