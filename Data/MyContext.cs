using Microsoft.EntityFrameworkCore;
using efcore5_tpt.Entities;
using Microsoft.Extensions.Logging;

namespace efcore5_tpt.Data
{
    public class MyContext : DbContext
    {
		private static readonly ILoggerFactory _loggerFactory = LoggerFactory
			.Create(builder => builder.AddConsole());

        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {
            
        }

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Diarista> Diaristas { get; set; }
		public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClienteMap());
			modelBuilder.ApplyConfiguration(new DiaristaMap());
			modelBuilder.ApplyConfiguration(new UsuarioMap());

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLoggerFactory(_loggerFactory);
			base.OnConfiguring(optionsBuilder);
		}
    }    
}