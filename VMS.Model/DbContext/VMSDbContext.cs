using Microsoft.EntityFrameworkCore;

namespace VMS.Client.Models
{
    public class VMSDbContext : DbContext
    {
        public VMSDbContext(DbContextOptions<VMSDbContext> options) { }

    }
}