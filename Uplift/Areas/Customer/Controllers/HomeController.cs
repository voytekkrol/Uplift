using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;
using Uplift.Models.ViewModels;

namespace Uplift.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private HomeVM HomeVM;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVM = new HomeVM()
            {
                CategoryList = _unitOfWOrk.Category.GetAll(),
                ServiceList = _unitOfWOrk.Service.GetAll(includeProperties:"Frequency")
            };

            return View(HomeVM);
        }

        public IActionResult Details(int id)
        {
            var serviceFromDb = _unitOfWOrk.Category.GetFirstOrDefault(includeProperties: "Category,Frequency", filter: c => c.Id == id);
            return View(serviceFromDb);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
