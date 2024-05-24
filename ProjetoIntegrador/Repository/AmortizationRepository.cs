using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Domain;
using Microsoft.Data.Sqlite;

namespace ProjetoIntegrador.Repository
{
    public class AmortizationRepository : DbContext
    {
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Installment> Installments { get; set; }

        private readonly SqliteConnection _connection;

        public AmortizationRepository()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_connection.ConnectionString);
        }

        public void Initialize()
        {
            Database.EnsureCreated();
        }
    }
}