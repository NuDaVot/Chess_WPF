using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chess2.Data;

public partial class HistoryChessContext : DbContext
{
    public HistoryChessContext()
    {
    }

    public HistoryChessContext(DbContextOptions<HistoryChessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=9sQecrJCyhh;database=chess", ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Idparty).HasName("PRIMARY");

            entity.ToTable("party");

            entity.HasIndex(e => e.BlackUser, "FkBlack_idx");

            entity.HasIndex(e => e.WhiteUser, "FkWhite_idx");

            entity.Property(e => e.Idparty).HasColumnName("idparty");
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
            entity.Property(e => e.Status)
                .HasComment("1 - играет \\\\n0 - забанен")
                .HasColumnName("status");
            entity.Property(e => e.WhiteUser)
                .HasComment("iD белого игрока ")
                .HasColumnName("white_user");

            entity.HasOne(d => d.BlackUserNavigation).WithMany(p => p.PartyBlackUserNavigations)
                .HasForeignKey(d => d.BlackUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkBlack");

            entity.HasOne(d => d.WhiteUserNavigation).WithMany(p => p.PartyWhiteUserNavigations)
                .HasForeignKey(d => d.WhiteUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkWhite");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Idreport).HasName("PRIMARY");

            entity.ToTable("report");

            entity.HasIndex(e => e.IdGame, "FKGameID_idx");

            entity.HasIndex(e => e.Object, "FKObject_idx");

            entity.HasIndex(e => e.Subject, "FKSubject_idx");

            entity.HasIndex(e => e.IdAdmin, "FKidadmin_idx");

            entity.Property(e => e.Idreport).HasColumnName("idreport");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.IdGame).HasColumnName("id_game");
            entity.Property(e => e.Object)
                .HasComment("ответчик ")
                .HasColumnName("object");
            entity.Property(e => e.Status)
                .HasComment("0 - на расмотрении\\n1 - удовлетворена\\n2 - отклонена ")
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasComment("заявитель")
                .HasColumnName("subject");
            entity.Property(e => e.Text)
                .HasMaxLength(300)
                .HasColumnName("text");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.ReportIdAdminNavigations)
                .HasForeignKey(d => d.IdAdmin)
                .HasConstraintName("FKidadmin");

            entity.HasOne(d => d.IdGameNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdGame)
                .HasConstraintName("FKGameID");

            entity.HasOne(d => d.ObjectNavigation).WithMany(p => p.ReportObjectNavigations)
                .HasForeignKey(d => d.Object)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKObject");

            entity.HasOne(d => d.SubjectNavigation).WithMany(p => p.ReportSubjectNavigations)
                .HasForeignKey(d => d.Subject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSubject");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Nick)
                .HasMaxLength(45)
                .HasColumnName("nick");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .HasColumnName("password");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Role)
                .HasComment("1 - игрок \\n0 - админ ")
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasComment("1 - играет \\n0 - забанен")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
