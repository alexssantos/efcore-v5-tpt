using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using efcore5_tpt.Entities;

namespace efcore5_tpt.Data
{       
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

            builder.Property(x => x.DataCriacao)
				.HasColumnName("dt_criacao")
				.IsRequired();

			builder.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");
        }
    }

    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.ToTable(nameof(Cliente));

            builder.Property(x => x.NomeContrato)
                .HasColumnName("tx_contrato");

            builder.Property(x => x.DataCriacao)
				.HasColumnName("dt_criacao")
				.IsRequired();
			builder.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");
        }
    }

    public class DiaristaMap : IEntityTypeConfiguration<Diarista>
    {
        public void Configure(EntityTypeBuilder<Diarista> builder)
        {
            builder.ToTable(nameof(Diarista));

            builder.Property(x => x.NumeroCartao)
				.HasColumnName("tx_cartao");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("dt_criacao")
				.IsRequired();
			builder.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");
        }
    }
}