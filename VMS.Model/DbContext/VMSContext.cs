using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace VMS.Client.DbModels
{

    public class VMSContextFactory : IDesignTimeDbContextFactory<VMSContext>
    {
        public VMSContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VMSContext>();

            string sqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");

            optionsBuilder.UseSqlServer(sqlConnection);

            return new VMSContext(optionsBuilder.Options);
        }
    }
    public class VMSContext : DbContext
    {

        public VMSContext(DbContextOptions<VMSContext> options) : base(options)
        {

        }

        public DbSet<Van> Vans { get; set; }
    }
}
