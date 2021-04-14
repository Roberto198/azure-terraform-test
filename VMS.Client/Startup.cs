using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using VMS.Client.DbModels;

[assembly: FunctionsStartup(typeof(VMS.Client.Startup))]

namespace VMS.Client
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            string sqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<VMSContext>(options => options.UseSqlServer(sqlConnection));
            builder.Services.AddScoped<IVanController, VanController>();


        }
    }
}