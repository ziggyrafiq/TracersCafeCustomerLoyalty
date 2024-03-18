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
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.UnitOfWork;
using ZR.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ZR.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly UnitOfWork _UnitOfWork;

        public CustomerService(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork is passing a NULL refernce. Please check if you can passed the UnitOfWork cobject correctly");
            }

            _UnitOfWork = unitOfWork;

        }

        public IQueryable<Customer> QueryAllCustomersWithAddress()
        {
            return _UnitOfWork.Repository<Customer>().Get()
                .Where(x=>x.IsSoftDeleted==false)
                .Include(x => x.CustomerAddress)
                .AsQueryable();
        }

        public IQueryable<Customer> QueryAllCustomersWithAddressSoftDeleted()
        {
            return _UnitOfWork.Repository<Customer>().Get()
                .Where(x => x.IsSoftDeleted == true)
                .Include(x => x.CustomerAddress)
                .AsQueryable();
        }

        public async Task<List<Customer>> AsyncGetAll()
        {
            return await Task.Run(() =>

               _UnitOfWork.Repository<Customer>()
            .Get()
               .OrderBy(o => o.Id)
            .ToListAsync());
        }


        public List<Customer> GetAllActive()
        {
            return
               _UnitOfWork.Repository<Customer>()
               .Get(g => g.IsActive == true)
               .OrderBy(o => o.Id)
               .ToList();
        }
        public async Task<List<Customer>> AsyncGetAllActive()
        {
            return await Task.Run(() =>
               _UnitOfWork.Repository<Customer>()
               .Get(g => g.IsActive == true)
               .OrderBy(o => o.Id)
               .ToListAsync());
        }

        public async Task<Customer> AsyncGetById(Guid id)
        {

            return await Task.Run(() => _UnitOfWork.Repository<Customer>().AsyncGetByID(id));
        }


        public async Task AsyncAdd(Customer model)
        {
            await _UnitOfWork.Repository<Customer>().AsyncInsert(model);
            await _UnitOfWork.SaveAsync();
        }
        public async Task AsyncUpdate(Customer model)
        {


            await _UnitOfWork.Repository<Customer>().AsyncUpdate(model);
            await _UnitOfWork.SaveAsync();


        }
        public async Task AsyncSoftDelete(Guid id)
        {
            Customer? dataModel = await AsyncGetById(id);

            dataModel.IsSoftDeleted = true;
            dataModel.IsActive = false;
           
            await AsyncUpdate(dataModel);
        }

        public async Task AsyncDelete(Guid id)
        {
            await _UnitOfWork.Repository<Customer>().AsyncDelete(id);

            await _UnitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _UnitOfWork.Dispose();
            GC.Collect(); ;
        }
    }
}
