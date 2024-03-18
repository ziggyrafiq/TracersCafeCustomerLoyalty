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
using ZR.Business.Services;

namespace ZR.UI.Extensions
{
    public abstract class BaseSiteController : Controller
    {
        ServiceManager _Manager;
        internal ServiceManager Services
        {
            get
            {
                
                if (_Manager == null)
                {
                   
                    _Manager = new ServiceManager();

                    if (User != null && User.Identity != null && !string.IsNullOrWhiteSpace(User.Identity.Name))
                    {
               
                        _Manager = new ServiceManager();
                    }
                }

                return _Manager;
            }
        }
    }
}
