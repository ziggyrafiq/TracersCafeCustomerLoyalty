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
using ZR.Infrastructure.DataSeeding;
using Microsoft.Extensions.Configuration;

namespace ZR.Infrastructure.Entities
{
    public class DbEntities : DbContext
    {
        public DbEntities() { }

        public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }


        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Customer> Customers { get; set; }
      
        public DbSet<CustomerTitle> CustomerTitles { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
                
            modelBuilder.ApplyConfiguration(new CustomerTitleSeed());
            modelBuilder.ApplyConfiguration(new CustomerSeed());
            modelBuilder.ApplyConfiguration(new CustomerAddressSeed());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
                   //.AddJsonFile(@Directory.GetCurrentDirectory() + "../Baseplate.MVC.UI/appsettings.json")
                   .AddJsonFile(@Directory.GetCurrentDirectory() + "../appsettings.json")
               .Build();

                var connectionString = configuration.GetConnectionString("DevDbConnection");

                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("ZR.Infrastructure.Migrations"));

            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
