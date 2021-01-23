using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository;

namespace Uplift.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CartController()
        {

        }

        [Area("Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
