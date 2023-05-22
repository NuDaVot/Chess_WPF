using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chess2;

public partial class DbA96cdbChessContext : DbContext
{
    public DbA96cdbChessContext()
    {
    }

    public DbA96cdbChessContext(DbContextOptions<DbA96cdbChessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=mysql8003.site4now.net;user=a96cdb_chess;password=xmSMBMn7Dq.A32W;database=db_a96cdb_chess", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_unicode_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Idparty).HasName("PRIMARY");

            entity
                .ToTable("party")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.BlackUser, "Fkblack_idx");

            entity.HasIndex(e => e.WhiteUser, "Fkwhite_idx");

            entity.Property(e => e.Idparty)
                .ValueGeneratedNever()
                .HasColumnName("idparty");
            entity.Property(e => e.BlackUser)
                .HasComment("iD черного игрока ")
                .HasColumnName("black_user");
            entity.Property(e => e.Date)
                .HasMaxLength(6)
                .HasColumnName("date");
            entity.Property(e => e.Duration)
                .HasColumnType("time")
                .HasColumnName("duration");
            entity.Property(e => e.Mode)
                .HasComment("0 - класический\\n1 - на время ")
                .HasColumnName("mode");
            entity.Property(e => e.Notation)
                .HasColumnType("text")
                .HasColumnName("notation");
            entity.Property(e => e.Result)
                .HasComment("0 - белый проиграл \n1 - белый выйграл ")
                .HasColumnName("result");
            entity.Property(e => e.WhiteUser)
                .HasComment("iD белого игрока ")
                .HasColumnName("white_user");

            entity.HasOne(d => d.BlackUserNavigation).WithMany(p => p.PartyBlackUserNavigations)
                .HasForeignKey(d => d.BlackUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fkblack");

            entity.HasOne(d => d.WhiteUserNavigation).WithMany(p => p.PartyWhiteUserNavigations)
                .HasForeignKey(d => d.WhiteUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fkwhite");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PRIMARY");

            entity
                .ToTable("user")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("iduser");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Nick)
                .HasMaxLength(45)
                .HasColumnName("nick");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Role)
                .HasComment("1 - игрок \\n0 - админ ")
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasComment("1 - играет \n0 - забанен")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
