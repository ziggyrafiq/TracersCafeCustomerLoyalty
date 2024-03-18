/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 04 -  Loyalty Card Scheme
*  Date     :  	10th October 2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*  Version  :   0.0.1  
************************************************************************************************************/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ZR.Infrastructure.Entities
{
    public class DbEntitiesContextFactory : IDesignTimeDbContextFactory<DbEntities>
    {
        //        public DbEntities CreateDbContext(string[] args)
        public DbEntities CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile(@Directory.GetCurrentDirectory() + "../appsettings.json")
                 .Build();

            string connectionString = configuration.GetConnectionString("DevDbConnection").ToString();

            DbContextOptionsBuilder<DbEntities> builder = new DbContextOptionsBuilder<DbEntities>();
            builder.EnableSensitiveDataLogging();
            builder.UseSqlServer(connectionString.ToString(), x => x.MigrationsAssembly("ZR.Infrastructure.Migrations"));

            return new DbEntities(builder.Options);
        }


    }
}
