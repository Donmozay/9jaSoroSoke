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

        public IActionResult LandingPage()
        {
            return View();
        }

        #region ------------------ Car Owner Report ----------------------------

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

            return PartialView("CarOwnersReports", view);
        }
        public IActionResult CarOwnersReport()
        {
            return View("CarOwnerReport");
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

            return this.RedirectToAction("CarOwnersReports", "Home");
        }

        #endregion


        #region ------------------ Company Owner Report ----------------------------
        [HttpGet]
        public async Task<IActionResult> CompanyOwnerDetails(int id)
        {
            var view = await _generalService.GetCompanyOwnerReporById(id);

            return View("CompanyOwnerDetails", view);
        }
        [HttpGet]
        public async Task<IActionResult> CompanyOwnersReports()
        {
            var view = await _generalService.GetCompanyOwnerReports();

            return View("CompanyOwnersReports", view);
        }
        public IActionResult CompanyOwnersReport()
        {
            return View("CompanyOwnersReport");
        }

        [HttpGet]
        public IActionResult AddCompanyOwnerReport(string processingMessage)
        {
            var view = _generalService.CreateCompanyOwnerView(processingMessage);
            return View("AddCompanyOwnerReport", view);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyOwnerReport([FromForm] CompanyOwnerViewModel companyOwnerReport)
        {
            string processingMessage = string.Empty;
            if (companyOwnerReport == null)
            {
                throw new ArgumentNullException(nameof(companyOwnerReport));
            }
            if (!ModelState.IsValid)
            {
                var model = this._generalService.CreateCompanyOwnerView(companyOwnerReport, processingMessage);
                return View("AddCompanyOwnerReport", model);
            };
            var returnInfo = await this._generalService.SaveCompanyOwnerReport(companyOwnerReport);

            if (!string.IsNullOrEmpty(returnInfo))
            {
                var model = this._generalService.CreateCompanyOwnerView(companyOwnerReport, processingMessage);
                return View("AddCompanyOwnerReport", model);
            }

            return this.RedirectToAction("CompanyOwnersReports", "Home");
        }

        #endregion
    }
}