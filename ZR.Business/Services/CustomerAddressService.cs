/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 04 -  Loyalty Card Scheme
*  Date     :  	5th October 2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*  Version  :   0.0.1
************************************************************************************************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.Models;
using ZR.Infrastructure.UnitOfWork;

namespace ZR.Business.Services
{
 
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly UnitOfWork _UnitOfWork;

        public CustomerAddressService(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork is passing a NULL refernce. Please check if you can passed the UnitOfWork cobject correctly");
            }

            _UnitOfWork = unitOfWork;

        }
        

        


        public async Task<List<CustomerAddress>> AsyncGetAll()
        {
            return await Task.Run(() =>

               _UnitOfWork.Repository<CustomerAddress>()
               .Get()
               .OrderBy(o => o.Id)
               .ToListAsync());
        }

        public async Task<CustomerAddress> AsyncGetById(Guid id)
        {

            return await Task.Run(() => _UnitOfWork.Repository<CustomerAddress>().AsyncGetByID(id));
        }


        public async Task<CustomerAddress> AsyncGetByCustomerId(Guid id)
        {
            return await Task.Run(() =>
             _UnitOfWork.Repository<CustomerAddress>()
             .Get()
             .Where(x=>x.CustomerId==id)
             .SingleOrDefaultAsync());
        }


         

        public async Task<CustomerAddress> AsyncAdd(CustomerAddress model)
        {
            await _UnitOfWork.Repository<CustomerAddress>().AsyncInsert(model);
            await _UnitOfWork.SaveAsync();
            return model;
        }

        public async Task<CustomerAddress> AsyncUpdate(CustomerAddress model)
        {
            await _UnitOfWork.Repository<CustomerAddress>().AsyncUpdate(model);
            await _UnitOfWork.SaveAsync();

            return model;
        }
        public async Task AsyncSoftDelete(Guid id)
        {
            CustomerAddress? dataModel = await AsyncGetById(id);
            dataModel.IsSoftDeleted = true;
            dataModel.IsActive = false;
            await AsyncUpdate(dataModel);
        }

        public async Task AsyncDelete(Guid id)
        {
            await _UnitOfWork.Repository<CustomerAddress>().AsyncDelete(id);

            await _UnitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _UnitOfWork.Dispose();
            GC.Collect(); ;
        }
    }
}
