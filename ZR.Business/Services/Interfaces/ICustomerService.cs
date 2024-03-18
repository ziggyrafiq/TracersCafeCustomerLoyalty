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
    public interface ICustomerService:IService
    {
       IQueryable<Customer> QueryAllCustomersWithAddress();
        IQueryable<Customer> QueryAllCustomersWithAddressSoftDeleted();
        List<Customer> GetAllActive();
        Task<List<Customer>> AsyncGetAllActive();

        Task<List<Customer>> AsyncGetAll();
        Task<Customer> AsyncGetById(Guid id);
        Task AsyncAdd(Customer model);

        Task AsyncUpdate(Customer model);

        Task AsyncSoftDelete(Guid id);
        Task AsyncDelete(Guid id);
    }
}
