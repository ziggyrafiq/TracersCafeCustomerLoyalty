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
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZR.Infrastructure.Models;

namespace ZR.Infrastructure.DataSeeding
{
    public class CustomerAddressSeed : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.HasData
               (

                   new CustomerAddress
                       {

                           Id = Guid.NewGuid(),
                           CustomerId = Guid.Parse("b5c7ab75-c2f6-4e7a-bfa2-2888f0e29b66"),
                           AddressLine1 = "N End Way",
                           AddressLine2 = "Golders Green",
                           AddressLine3 = "London",
                           AddressLine4 = "United Kingdom",
                           PostCode = "NW3 7HE",
                           IsActive = true,
                           IsSoftDeleted = false,
                           IsHardDeleted = false
                       },
                    new CustomerAddress
                    {

                        Id = Guid.NewGuid(),
                        CustomerId = Guid.Parse("35a146db-fdf6-4c1e-89ae-04716fad097b"),
                        AddressLine1 = "115 Fallows Road",
                        AddressLine2 = "Hall Green",
                        AddressLine3 = "Birmingham",
                        AddressLine4 = "United Kingdom",
                        PostCode = "B11 1PH",
                        IsActive = true,
                        IsSoftDeleted = false,
                        IsHardDeleted = false
                    },
                     new CustomerAddress
                     {

                         Id = Guid.NewGuid(),
                         CustomerId = Guid.Parse("1f498795-4092-4490-919c-1a26d29df1c4"),
                         AddressLine1 = "20 Stone Street",
                         AddressLine2 = "Oldbury",
                         AddressLine3 = "Birmingham",
                         AddressLine4 = "United Kingdom",
                         PostCode = "B69 4JL",
                         IsActive = true,
                         IsSoftDeleted = false,
                         IsHardDeleted = false
                     } 

              );
        }
    }
}
