using creditcardcreation.Models;
using Microsoft.EntityFrameworkCore;

namespace creditcardcreation.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
    }

}