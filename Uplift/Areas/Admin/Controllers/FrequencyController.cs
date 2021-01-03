﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FrequencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FrequencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Frequency frequency= new Frequency();
            if (id == null)
            {
                return View(frequency);
            }

            frequency = _unitOfWork.Frequency.Get(id.GetValueOrDefault());

            if (frequency == null)
            {
                return NotFound();
            }

            return View(frequency);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Frequency.GetAll() });
        }
    }
}
