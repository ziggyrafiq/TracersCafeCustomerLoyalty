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
using Microsoft.EntityFrameworkCore;
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.Models;
using ZR.Infrastructure.UnitOfWork;

namespace ZR.Business.Services
{
    public class CustomerTileService : ICustomerTileService
    {

        private readonly UnitOfWork _UnitOfWork;

        public CustomerTileService(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork is passing a NULL refernce. Please check if you can passed the UnitOfWork cobject correctly");
            }

            _UnitOfWork = unitOfWork;

        }

 

        public IQueryable<CustomerTitle> QueryAllCustomersTitles()
        {
            return _UnitOfWork.Repository<CustomerTitle>().Get()
             .Where(x => x.IsSoftDeleted == false)
                .AsQueryable();
        }

        public IQueryable<CustomerTitle> QueryAllCustomersTitlesSoftDeleted()
        {
            return _UnitOfWork.Repository<CustomerTitle>().Get()
                .Where(x=>x.IsSoftDeleted==true)

                .AsQueryable();
        }
        

        public async Task<List<CustomerTitle>> AsyncGetAll()
        {
            return await Task.Run(() =>

               _UnitOfWork.Repository<CustomerTitle>()
               .Get()
               .OrderBy(o => o.Id)
               .ToListAsync());
        }

        public List<CustomerTitle> GetAllActive()
        {
            return 
               _UnitOfWork.Repository<CustomerTitle>()
               .Get(g => g.IsActive == true)
               .OrderBy(o => o.Id)
               .ToList();
        }
        public async Task<List<CustomerTitle>> AsyncGetAllActive()
        {
            return await Task.Run(() =>
               _UnitOfWork.Repository<CustomerTitle>()
               .Get(g=>g.IsActive==true)
               .OrderBy(o => o.Id)
               .ToListAsync());
        }


        public async Task<CustomerTitle> AsyncGetById(Guid id)
        {

            return await Task.Run(() => _UnitOfWork.Repository<CustomerTitle>().AsyncGetByID(id));
        }

       

        public async Task<CustomerTitle> AsyncAdd(CustomerTitle model)
        {
            await _UnitOfWork.Repository<CustomerTitle>().AsyncInsert(model);
            await _UnitOfWork.SaveAsync();
            return model;
        }

        public async Task<CustomerTitle> AsyncUpdate(CustomerTitle model)
        {
            await _UnitOfWork.Repository<CustomerTitle>().AsyncUpdate(model);
            await _UnitOfWork.SaveAsync();

            return model;
        }
        public async Task AsyncSoftDelete(Guid id)
        {
            CustomerTitle? dataModel = await AsyncGetById(id);
            dataModel.IsSoftDeleted = true;
            dataModel.IsActive = false;
            await AsyncUpdate(dataModel);
        }

        public async Task AsyncDelete(Guid id)
        {
            await _UnitOfWork.Repository<CustomerTitle>().AsyncDelete(id);

            await _UnitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _UnitOfWork.Dispose();
            GC.Collect(); ;
        }
    }
}
