 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZR.Infrastructure.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
 

namespace ZR.Infrastructure
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DbEntities>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }

            return host;
        }


        //public static WebApplication MigrateDatabase(this WebApplication webApp)
        //{
        //    using (var scope = webApp.Services.CreateScope())
        //    {
        //        using (var appContext = scope.ServiceProvider.GetRequiredService<DbEntities>())
        //        {
        //            try
        //            {
        //                appContext.Database.Migrate();
        //            }
        //            catch (Exception ex)
        //            {
        //                //Log errors or do anything you think it's needed
        //                throw;
        //            }
        //        }
        //    }
        //    return webApp;
        //}
    }
}
