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
using ZR.Infrastructure.Models;

namespace ZR.Business.Services.Interfaces
{
    public interface ICustomerTileService : IService
    {
        IQueryable<CustomerTitle> QueryAllCustomersTitles();

        IQueryable<CustomerTitle> QueryAllCustomersTitlesSoftDeleted();

        Task<List<CustomerTitle>> AsyncGetAll();

        List<CustomerTitle> GetAllActive();
        Task<List<CustomerTitle>> AsyncGetAllActive();

        Task<CustomerTitle> AsyncGetById(Guid id);
       

        Task<CustomerTitle> AsyncAdd(CustomerTitle model);
        Task<CustomerTitle> AsyncUpdate(CustomerTitle model);
        Task AsyncSoftDelete(Guid id);
        Task AsyncDelete(Guid id);
    }
}
