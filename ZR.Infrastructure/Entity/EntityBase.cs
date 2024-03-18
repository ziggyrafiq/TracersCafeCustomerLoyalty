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


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ZR.Infrastructure.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ZR.Infrastructure.Entity
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public Guid Id { get; set; }


        [Display(Name = "Active")]
        public virtual bool IsActive { get; set; }

        [Display(Name = "Soft Delete")]
        public virtual bool IsSoftDeleted { get; set; }

        [Display(Name = "Hard Delete")]
        public virtual bool IsHardDeleted { get; set; }
    }
}
