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
using System.Xml.Linq;

namespace ZR.Infrastructure.Models
{
    public class CustomerAddress : EntityBase
    {
 

        [Display(Name = "Address Line 1"),
         Required(ErrorMessage = "Missing Address Line 1."),
         Column(Order = 2)]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Address Line 2"), 
         Required(ErrorMessage = "Missing Address Line 2."),
         Column(Order = 3)]
        public string AddressLine2 { get; set; } = string.Empty;

        [Display(Name = "Address Line 3"), 
         Required(ErrorMessage = "Missing Address Line 3."),
         Column(Order = 4)]
        public string AddressLine3 { get; set; } = string.Empty;

        [Display(Name = "Address Line 4"), 
         Required(ErrorMessage = "Missing Address Line 4."),
         Column(Order = 5)]
        public string AddressLine4 { get; set; } = string.Empty;

        [Display(Name = "Post Code/Zip Code"), 
         Required(ErrorMessage = "Missing Post Code or Zip Code."),
         Column(Order = 6)]
        public string PostCode { get; set; } = string.Empty;

        [NotMapped]
        public string AddressSummary
        {
            get
            {
                return ($"{AddressLine1}, {AddressLine3} {PostCode}");
            }

        }

        public virtual Customer? Customer { get; set; }

        
        [ForeignKey("CustomerId"), Column(Order = 1)]
        public Guid CustomerId { get; set; }
    }
}
