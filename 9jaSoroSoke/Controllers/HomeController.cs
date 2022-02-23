using _9jasorosoke.Interface;
using _9jaSoroSoke.Domain.Models;
using _9jaSoroSoke.Models;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _9jaSoroSoke.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGeneralService  _generalService;
        
        public HomeController(ILogger<HomeController> logger, IGeneralService generalService)
        {
            _logger = logger;
            _generalService = generalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VeiwDetails(int id)
        {
            var view = await _generalService.GetCarOwnerReporByIds(id);

            return View("VeiwDetails", view);
        }
        [HttpGet]
        public async Task <IActionResult> CarOwnersReports()
        {
            var view = await _generalService.GetCarOwnerReports();

            return View("CarOwnersReports", view);
        }
        public IActionResult CarOwnersReport()
        {
            return View("CarOwnersReport");
        }

        [HttpGet]
        public IActionResult AddReport(string processingMessage)
        {
            var view = _generalService.CreateCarownerView(processingMessage);
            return View("AddReport", view);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport([FromForm] CarOwnerViewModel carOwnerReport)
        {
            string processingMessage = string.Empty;
            if (carOwnerReport == null)
            {
                throw new ArgumentNullException(nameof(carOwnerReport));
            }
            if (!ModelState.IsValid)
            {
                var model = this._generalService.CreateCarownerView(carOwnerReport, processingMessage);
                return View("AddReport", model);
            };
            var returnInfo  = await this._generalService.SaveReport(carOwnerReport);

            if (!string.IsNullOrEmpty(returnInfo))
            {
                var model = this._generalService.CreateCarownerView(carOwnerReport, processingMessage);
                return View("AddReport", model);
            }

            return this.RedirectToAction("GetCarOwnersReports", "Home");
        }
    }
}