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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZR.Infrastructure.DataSeeding
{
    public class CustomerTitleSeed : IEntityTypeConfiguration<CustomerTitle>
    {
        public void Configure(EntityTypeBuilder<CustomerTitle> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData
           (
                   new CustomerTitle
                {
                    Id = Guid.Parse("3c9608a9-92d0-4e79-99fd-3ebed82a950f"),
                    Name = "Master",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new CustomerTitle
                {
                    Id = Guid.Parse("958cda47-5346-455d-b3a0-91151802887a"),
                    Name = "Mr",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new CustomerTitle
                {
                    Id = Guid.Parse("2fb65fb4-77b2-4db6-b838-ba366865aa44"),
                    Name = "Miss",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new CustomerTitle
                {
                    Id = Guid.Parse("58e08f27-e651-431a-b474-151e12b7d4c3"),
                    Name = "Mrs",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new CustomerTitle
                {
                    Id = Guid.Parse("daf16987-9661-486f-88b3-c2a1ed095ab2"),
                    Name = "Ms",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new CustomerTitle
                {
                    Id = Guid.Parse("88ed2dca-1bdc-485c-a571-d22dbb42abd7"),
                    Name = "Sir",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new CustomerTitle
                {
                    Id = Guid.Parse("e3a2005d-0121-4d0c-8a9c-ed8a82a2fe3e"),
                    Name = "Dr",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new CustomerTitle
                {
                    Id = Guid.Parse("fb1136d0-5c32-4c97-b0c3-f2ff78f1e7fb"),
                    Name = "Prof",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new CustomerTitle
                {
                    Id = Guid.Parse("270285a4-a176-4cd7-aeb7-d1004a18e7e7"),
                    Name = "Lord",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                }

            );

        }
    }
}
