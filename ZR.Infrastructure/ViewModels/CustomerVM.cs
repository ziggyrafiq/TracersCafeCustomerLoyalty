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

namespace ZR.Infrastructure.ViewModels
{
    public class CustomerVM
    {
        public CustomerTitle? CustomerTitle { get; set; }
        public Customer? Customer { get; set; }
        public CustomerAddress? CustomerAddress { get; set; }


    }
}
