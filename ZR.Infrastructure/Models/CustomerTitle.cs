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


using ZR.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZR.Infrastructure.Models
{
    public class CustomerTitle : EntityBase
    {
        public CustomerTitle()
        {
            Customers = Customers ?? new List<Customer>();

        }


    
        [Required(ErrorMessage = "Please Enter Tile Name. i.e. Mr, Mrs"),
        Column(Order = 1)]
        public string Name { get; set; } = string.Empty;
        
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
