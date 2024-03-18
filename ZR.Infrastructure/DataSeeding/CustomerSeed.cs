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
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

         
            builder.HasData
               (


                   new Customer
                   {

                       Id = Guid.Parse("b5c7ab75-c2f6-4e7a-bfa2-2888f0e29b66"),
                       CustomerTitleId = Guid.Parse("958CDA47-5346-455D-B3A0-91151802887A"),
                       FirstName = "Kenneth",
                       MiddleName = "Xena",
                       LastName = "Beckley",
                       Age = 40,
                       EmailAddress = "Kenneth.Beckley@BackleyScaffoldingLtd.com",
                       Telpehone= "0121-123-4567",
                       IsActive = true,
                       IsSoftDeleted = false,
                       IsHardDeleted = false                     
                   },
                    new Customer
                    {

                        Id = Guid.Parse("35a146db-fdf6-4c1e-89ae-04716fad097b"),
                        CustomerTitleId = Guid.Parse("958cda47-5346-455d-b3a0-91151802887a"),
                        FirstName = "Clifford",
                        MiddleName = "",
                        LastName = "Dickinson",
                        Age = 67,
                        EmailAddress = "Clifford.Dickinson@DickinsonOfficeSupplies.co.uk",
                        Telpehone = "0121-496-0643",
                        IsActive = true,
                        IsSoftDeleted = false,
                        IsHardDeleted = false
                    },
                   new Customer
                   {

                       Id = Guid.Parse("1f498795-4092-4490-919c-1a26d29df1c4"),
                       CustomerTitleId = Guid.Parse("daf16987-9661-486f-88b3-c2a1ed095ab2"),
                       FirstName = "Cheryl",
                       MiddleName = "",
                       LastName = "Nixon",
                       Age = 28,
                       EmailAddress = "Cheryl.Nixon@NixonNursingSupplies.co.uk",
                       Telpehone = "0121-496-0602",
                       IsActive = true,
                       IsSoftDeleted = false,
                       IsHardDeleted = false
                   } 

              );
        }
    }
}
