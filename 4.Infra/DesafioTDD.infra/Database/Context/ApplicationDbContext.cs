using DesafioTDD.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioTDD.infra.Database.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CashMachine> CashMachines { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}