using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice_Test.Filters;

namespace Microservice_Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    [ErrorHandlingFilter]
    public class ProductController : Controller
    {
        public ActionResult GetProductNames()
        {
            List<string> lstProduct = new List<string>();
            lstProduct.Add("Cricket Bat");
            lstProduct.Add("Cricket Bat");
            lstProduct.Add("Cricket Bat");
            lstProduct.Add("Cricket Bat");
            lstProduct.Add("Cricket Bat");
            //throw new DivideByZeroException("Sorry");
            return Ok(lstProduct);
        }
    }
}