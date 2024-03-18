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
    public interface ICustomerAddressService : IService
    {
      
        Task<List<CustomerAddress>> AsyncGetAll();
        Task<CustomerAddress> AsyncGetById(Guid id);

        Task<CustomerAddress> AsyncGetByCustomerId(Guid id);

        Task<CustomerAddress> AsyncAdd(CustomerAddress model);
        Task<CustomerAddress> AsyncUpdate(CustomerAddress model);
        Task AsyncSoftDelete(Guid id);
        Task AsyncDelete(Guid id);
    }
}
