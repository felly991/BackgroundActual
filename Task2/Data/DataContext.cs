using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<UserDate> usersDate { get; set; }
    }
}
