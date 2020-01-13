using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIFoodPet.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cardapio> Cardapio { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Descricaopedido> Descricaopedido { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Enderecocliente> Enderecocliente { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=39841677;Database=bancopet");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cardapio>(entity =>
            {
                entity.HasKey(e => e.Idprato)
                    .HasName("PRIMARY");

                entity.ToTable("cardapio");

                entity.Property(e => e.Idprato)
                    .HasColumnName("IDPrato")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DsPrato)
                    .IsRequired()
                    .HasColumnType("varchar(150)");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.Idcliente)
                    .HasColumnName("IDCliente")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasColumnType("longtext");

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("dtCriacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.Senha).HasColumnType("longtext");

                entity.Property(e => e.Telefone).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Descricaopedido>(entity =>
            {
                entity.HasKey(e => e.IddescricaoPedido)
                    .HasName("PRIMARY");

                entity.ToTable("descricaopedido");

                entity.HasIndex(e => e.Idcliente)
                    .HasName("IDCliente");

                entity.HasIndex(e => e.Idprato)
                    .HasName("IDPrato");

                entity.Property(e => e.IddescricaoPedido)
                    .HasColumnName("IDdescricaoPedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DsPrato).HasColumnType("varchar(150)");

                entity.Property(e => e.Idcliente)
                    .HasColumnName("IDCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idprato)
                    .HasColumnName("IDPrato")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Descricaopedido)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("descricaopedido_ibfk_2");

                entity.HasOne(d => d.IdpratoNavigation)
                    .WithMany(p => p.Descricaopedido)
                    .HasForeignKey(d => d.Idprato)
                    .HasConstraintName("descricaopedido_ibfk_1");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.Idendereco)
                    .HasName("PRIMARY");

                entity.ToTable("endereco");

                entity.Property(e => e.Idendereco)
                    .HasColumnName("IDEndereco")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Complemento).HasColumnType("varchar(100)");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.NmCep)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Enderecocliente>(entity =>
            {
                entity.HasKey(e => e.IdenderecoCliente)
                    .HasName("PRIMARY");

                entity.ToTable("enderecocliente");

                entity.HasIndex(e => e.Idendereco)
                    .HasName("IDEndereco");

                entity.Property(e => e.IdenderecoCliente)
                    .HasColumnName("IDEnderecoCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idcliente)
                    .HasColumnName("IDCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idendereco)
                    .HasColumnName("IDEndereco")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdenderecoNavigation)
                    .WithMany(p => p.Enderecocliente)
                    .HasForeignKey(d => d.Idendereco)
                    .HasConstraintName("IDEndereco");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedido");

                entity.HasIndex(e => e.Idcliente)
                    .HasName("IDCliente");

                entity.HasIndex(e => e.IdenderecoCliente)
                    .HasName("IDEnderecoCliente");

                entity.HasIndex(e => e.Idprato)
                    .HasName("IDPrato");

                entity.Property(e => e.Idpedido)
                    .HasColumnName("IDPedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DtEntregaPedido).HasColumnType("datetime");

                entity.Property(e => e.DtPedidoRealizado).HasColumnType("datetime");

                entity.Property(e => e.Idcliente)
                    .HasColumnName("IDCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdenderecoCliente)
                    .HasColumnName("IDEnderecoCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idprato)
                    .HasColumnName("IDPrato")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("IDCliente");

                entity.HasOne(d => d.IdenderecoClienteNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdenderecoCliente)
                    .HasConstraintName("IDEnderecoCliente");

                entity.HasOne(d => d.IdpratoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.Idprato)
                    .HasConstraintName("IDPrato");
            });
        }
    }
}
