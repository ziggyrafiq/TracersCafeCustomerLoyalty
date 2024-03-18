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
using ZR.Business.Services;

namespace ZR.UI.Extensions
{
    public static class LoggerServiceExtension
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {

            services.AddSingleton<ILoggerManagerService, LoggerManagerService>();
        }
    }
}
