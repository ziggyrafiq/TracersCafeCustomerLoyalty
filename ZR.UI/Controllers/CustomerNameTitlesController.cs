/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 04 -  Loyalty Card Scheme
*  Date     :  	5th October 2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.* 
*  Version  :   0.0.1
************************************************************************************************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.Models;
using ZR.Infrastructure.ViewModels;
using ZR.UI.Extensions;
using ZR.UI.Models;

namespace ZR.UI.Controllers
{
    
    public class CustomerNameTitlesController : BaseSiteController
    {
        private readonly ILoggerManagerService _logger;

        public CustomerNameTitlesController(ILoggerManagerService loggerManagerService)
        {
            _logger = loggerManagerService;
        }
        public async Task<IActionResult> Index(int? pageNumber, bool? softDeleted)
        {
            _logger.LogError("Testing It.");

            int pageSize = 5;

            if (softDeleted == true)
                return View(await PaginatedList<CustomerTitle>.CreateAsync(Services.Service<ICustomerTileService>().QueryAllCustomersTitlesSoftDeleted(), pageNumber ?? 1, pageSize));

            return View(await PaginatedList<CustomerTitle>.CreateAsync(Services.Service<ICustomerTileService>().QueryAllCustomersTitles(), pageNumber ?? 1, pageSize));
        }

        [HttpGet("CustomerNameTitles/Upsert")]
        public async Task<IActionResult> Upsert(Guid? id)
        {

            if (id == Guid.Empty || id.HasValue == false)
            {

                IEnumerable<SelectListItem> customerNameTitlesList = Services.Service<ICustomerTileService>().GetAllActive()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString(),

            });
                ViewBag.CustomerNameTitles = customerNameTitlesList;
                return View();
            }
            else
            {
                ModelState.Clear();
                CustomerVM customerVM = new CustomerVM();
                customerVM.CustomerTitle = await Services.Service<ICustomerTileService>().AsyncGetById(id.Value);

                IEnumerable<SelectListItem> customerNameTitlesList = Services.Service<ICustomerTileService>().GetAllActive()
               .Select(c => new SelectListItem
               {
                   Value = c.Id.ToString(),
                   Text = c.Name.ToString(),
                   Selected = c.Id == customerVM.CustomerTitle.Id ? true : false
               });

                ViewBag.CustomerNameTitles = customerNameTitlesList;

                return View(customerVM);
            }
        }


        [HttpPost("CustomerNameTitles/Upsert")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CustomerVM customerVM)
        {
            
            if (customerVM.CustomerTitle.Id == Guid.Empty )
            {
                customerVM.CustomerTitle.Id = Guid.NewGuid();
                customerVM.CustomerTitle.IsActive = customerVM.CustomerTitle.IsActive;
                customerVM.CustomerTitle.IsSoftDeleted = customerVM.CustomerTitle.IsSoftDeleted;
                customerVM.CustomerTitle.IsHardDeleted = customerVM.CustomerTitle.IsHardDeleted;

                await Services.Service<ICustomerTileService>().AsyncAdd(customerVM.CustomerTitle);
                return RedirectToAction(nameof(Index));

            }
            else
            {

                await Services.Service<ICustomerTileService>().AsyncUpdate(customerVM.CustomerTitle);

                return RedirectToAction(nameof(Index));
            }

            return View(customerVM);

        }


        [HttpGet("CustomerNameTitles/SoftDelete")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            CustomerVM customerVM = new CustomerVM();
            customerVM.CustomerTitle = await Task.Run(() => Services.Service<ICustomerTileService>().AsyncGetById(id));
            
            if (customerVM == null)
            {
                return NotFound();
            }

            return PartialView("SoftDelete", customerVM);

        }


        [HttpPost("CustomerNameTitles/SoftDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDeleteConfirmed(CustomerVM customerVM)
        {
                        
            customerVM.CustomerTitle = await Task.Run(() => Services.Service<ICustomerTileService>().AsyncGetById(customerVM.CustomerTitle.Id));

            await Services.Service<ICustomerTileService>().AsyncSoftDelete(customerVM.CustomerTitle.Id);

            return RedirectToAction("Index");

        }


        [HttpGet("CustomerNameTitles/HardDelete")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            CustomerVM customerVM = new CustomerVM();
            customerVM.CustomerTitle = await Task.Run(() => Services.Service<ICustomerTileService>().AsyncGetById(id));
            if (customerVM.CustomerTitle == null)
            {
                return NotFound();
            }

            return PartialView("HardDelete", customerVM);
        }


        [HttpPost("CustomerNameTitles/HardDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HardDeleteConfirmed(CustomerVM customerVM)
        {
            
            customerVM.CustomerTitle = await Task.Run(() => Services.Service<ICustomerTileService>().AsyncGetById(customerVM.CustomerTitle.Id));
            
            await Services.Service<ICustomerTileService>().AsyncDelete(customerVM.CustomerTitle.Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
