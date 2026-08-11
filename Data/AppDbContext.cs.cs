using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<Agendamento> Servico {get; set;}

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Servico> Agendamento { get; set; }
    }
}
