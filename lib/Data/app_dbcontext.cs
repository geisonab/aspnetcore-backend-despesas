using despesas_pessoais.Models;
using Microsoft.EntityFrameworkCore;

namespace despesas_pessoais.Data
{
    public class AppDBContext : DbContext
    {
        public required DbSet<DespesasModel> DespesasTable { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set Increment
            modelBuilder.Entity<DespesasModel>()
                    .Property(p => p.IdDespesa)
                    .UseIdentityColumn(seed: 1, increment: 1);

        }
    }


}