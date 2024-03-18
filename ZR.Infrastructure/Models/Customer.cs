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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ZR.Infrastructure.Entity;

namespace ZR.Infrastructure.Models
{
    public class Customer : EntityBase
    {
 
        [ForeignKey("CustomerTitleId"),
        Display(Name ="Title"),
        Required(ErrorMessage ="Please select your Title !"),
        Column(Order = 1)]
        public Guid CustomerTitleId { get; set; }

        
        [Display(Name ="First Name"),
         Required(ErrorMessage = "Please Enter Your First Name."),
        Comment("Customer First Name"),
        Column(Order = 2)]
        public string? FirstName { get; set; } = string.Empty;

        [Display(Name = "Middle Name"), 
        Comment("Customer Middle Name"),
        Column(Order = 3)]
        public string? MiddleName { get; set; } = string.Empty;


        [Display(Name = "Last Name"),
         Required(ErrorMessage = "Please Enter Your Last Name."),
         Comment("Customer Last Name"),
        Column(Order = 4)]
        public string? LastName { get; set; } = string.Empty;

        [Display(Name = "Email Address"),
         Required(ErrorMessage = "Please enter Your Email Address"),
         DataType(DataType.EmailAddress, ErrorMessage = "Please Type in Valid Email Address!"),
         EmailAddress(ErrorMessage = "Please Type in Valid Email Address!"),
         Comment("Customer Email Address"),
         Column(Order = 5)]
        public string? EmailAddress { get; set; } = string.Empty;

        [Display(Name = "Telpehone Number"),
         Required(ErrorMessage = "Please Enter Ypur Telephone Number."),
         Comment("Customer Telpehone Number"),
         DataType(DataType.PhoneNumber),
         RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number"),
        Column(Order = 6)]
        public string? Telpehone { get; set; } = string.Empty;

        [Display(Name = "Age"),
         Range(1,100, ErrorMessage = "Please enter valid age from 1 to 100"),
         Required(ErrorMessage = "Please enter Your Age"),
         Comment("Customer Age"),
        Column(Order = 7)]

        public int? Age { get; set; } 

        [NotMapped]
        public string DisplayName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            
        }

        public virtual CustomerAddress? CustomerAddress { get; set; }
        public virtual CustomerTitle? CustomerTile { get; set; }



    }
}
