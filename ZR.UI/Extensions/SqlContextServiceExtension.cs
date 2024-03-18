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


using ZR.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.API.Extensions.ApiServiceExtensions
{
    public static class SqlContextServiceExtension
    {
        public static void ConfigureSqlDbEntitiesContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DbEntities>(
               options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("DevDbConnection"),
                      x => x.MigrationsAssembly("ZR.Infrastructure.Migrations")));
                    }

    }
}