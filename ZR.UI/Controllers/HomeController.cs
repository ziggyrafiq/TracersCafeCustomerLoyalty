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
using System;
using System.Diagnostics;
using System.Net;
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.Models;
using ZR.Infrastructure.ViewModels;
using ZR.UI.Extensions;
using ZR.UI.Models;

namespace ZR.UI.Controllers
{
  
    
    public class HomeController : BaseSiteController
    {
        private readonly ILoggerManagerService _logger;

        public HomeController(ILoggerManagerService loggerManagerService)
        {
            _logger = loggerManagerService;
        }
        public async Task<IActionResult> Index(int? pageNumber, bool? softDeleted)
        {
            _logger.LogError("Testing It.");

            int pageSize = 5;
            if (softDeleted == true)
                return View(await PaginatedList<Customer>.CreateAsync(Services.Service<ICustomerService>().QueryAllCustomersWithAddressSoftDeleted(), pageNumber ?? 1, pageSize));

            return View(await PaginatedList<Customer>.CreateAsync(Services.Service<ICustomerService>().QueryAllCustomersWithAddress(), pageNumber ?? 1, pageSize));
        }
      
        [HttpGet("Home/Upsert")]
        public async Task<IActionResult> Upsert(Guid? id)
        {    

            if (id == Guid.Empty || id.HasValue==false)
            {
                
                IEnumerable<SelectListItem> customerNameTitlesList = Services.Service<ICustomerTileService>().GetAllActive()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString(),
               
            });
                ViewBag.CustomerNameTitles = customerNameTitlesList;
                return View( );
            }
            else
            {
                ModelState.Clear();
                CustomerVM  customerVM= new CustomerVM();
                customerVM.Customer = await Services.Service<ICustomerService>().AsyncGetById(id.Value);
                customerVM.Customer.CustomerAddress = await Services.Service<ICustomerAddressService>().AsyncGetByCustomerId(id.Value);
               

             IEnumerable<SelectListItem> customerNameTitlesList = Services.Service<ICustomerTileService>().GetAllActive()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString(),
                Selected = c.Id == customerVM.Customer.CustomerTitleId ? true : false
            });

                ViewBag.CustomerNameTitles = customerNameTitlesList;

                return View(customerVM);
            }
        }


        [HttpPost("Home/Upsert")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CustomerVM customerVM)
        {
     
            if (customerVM.Customer.Id == Guid.Empty && customerVM.Customer.CustomerAddress.Id == Guid.Empty)
            {
                customerVM.Customer.Id = Guid.NewGuid();
                customerVM.Customer.CustomerAddress.Id = Guid.NewGuid();

                customerVM.Customer.IsActive = customerVM.Customer.IsActive;
                customerVM.Customer.IsSoftDeleted = customerVM.Customer.IsSoftDeleted;
                customerVM.Customer.IsHardDeleted = customerVM.Customer.IsHardDeleted;

                customerVM.Customer.CustomerAddress.IsActive = customerVM.Customer.IsActive;
                customerVM.Customer.CustomerAddress.IsSoftDeleted = customerVM.Customer.IsSoftDeleted;
                customerVM.Customer.CustomerAddress.IsHardDeleted = customerVM.Customer.IsHardDeleted;


                await Services.Service<ICustomerService>().AsyncAdd(customerVM.Customer);
                return RedirectToAction(nameof(Index));
                                
            }
            else if (customerVM.Customer.CustomerAddress.Id == Guid.Empty && customerVM.Customer.Id != Guid.Empty)
            {
                CustomerAddress(customerVM);

                await Services.Service<ICustomerService>().AsyncUpdate(customerVM.Customer);


                return RedirectToAction(nameof(Index));
            }
            else
            {
                
                await Services.Service<ICustomerService>().AsyncUpdate(customerVM.Customer);


                return RedirectToAction(nameof(Index));
            }

            
             
            return View(customerVM);

        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Home/SoftDelete")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            CustomerVM customerVM = new CustomerVM();
            customerVM.Customer = await Task.Run(() => Services.Service<ICustomerService>().AsyncGetById(id));
            
            if (customerVM.Customer == null)
            {
                return NotFound();
            }

            return PartialView("SoftDelete", customerVM);



        }


        [HttpPost("Home/SoftDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDeleteConfirmed(CustomerVM customerVM)
        {
            
            customerVM.Customer = await Task.Run(() => Services.Service<ICustomerService>().AsyncGetById(customerVM.Customer.Id));

            await Services.Service<ICustomerService>().AsyncSoftDelete(customerVM.Customer.Id);

            return RedirectToAction("Index");

        }


        [HttpGet("Home/HardDelete")]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            CustomerVM customerVM = new CustomerVM();
            customerVM.Customer = await Task.Run(() => Services.Service<ICustomerService>().AsyncGetById(id));
            
            if (customerVM == null)
            {
                return NotFound();
            }

            return PartialView("HardDelete", customerVM);



        }


        [HttpPost("Home/HardDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HardDeleteConfirmed(CustomerVM customerVM)
        {

            
            customerVM.Customer = await Task.Run(() => Services.Service<ICustomerService>().AsyncGetById(customerVM.Customer.Id));

            await Services.Service<ICustomerService>().AsyncDelete(customerVM.Customer.Id);

            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static void CustomerAddress(CustomerVM customerVM)
        {
            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.Id = Guid.NewGuid();
            customerAddress.CustomerId = customerVM.Customer.Id;
            customerAddress.AddressLine1 = customerVM.Customer.CustomerAddress.AddressLine1;
            customerAddress.AddressLine2 = customerVM.Customer.CustomerAddress.AddressLine2;
            customerAddress.AddressLine3 = customerVM.Customer.CustomerAddress.AddressLine3;
            customerAddress.AddressLine4 = customerVM.Customer.CustomerAddress.AddressLine4;
            customerAddress.PostCode = customerVM.Customer.CustomerAddress.PostCode;
            customerAddress.IsActive = customerVM.Customer.IsActive;
            customerAddress.IsSoftDeleted = customerVM.Customer.IsSoftDeleted;
            customerAddress.IsHardDeleted = customerVM.Customer.IsHardDeleted;

        }
    }
}