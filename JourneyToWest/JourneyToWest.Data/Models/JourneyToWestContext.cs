using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneyToWest.Models
{
    public partial class JourneyToWestContext : DbContext
    {
        public JourneyToWestContext()
        {
        }

        public JourneyToWestContext(DbContextOptions<JourneyToWestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<ActorRoleActor> ActorRoleActor { get; set; }
        public virtual DbSet<Challenge> Challenge { get; set; }
        public virtual DbSet<ChallengeActor> ChallengeActor { get; set; }
        public virtual DbSet<ChallengeActorIdRoleActorId> ChallengeActorIdRoleActorId { get; set; }
        public virtual DbSet<ChallengeTool> ChallengeTool { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleActor> RoleActor { get; set; }
        public virtual DbSet<Tool> Tool { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=JourneyToWest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.ActorId)
                    .HasColumnName("ActorID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActorName).HasMaxLength(100);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Actor)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Actor_Registration");
            });

            modelBuilder.Entity<ActorRoleActor>(entity =>
            {
                entity.ToTable("Actor_RoleActor");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActorId)
                    .IsRequired()
                    .HasColumnName("ActorID")
                    .HasMaxLength(50);

                entity.Property(e => e.RoleActorId)
                    .IsRequired()
                    .HasColumnName("RoleActorID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorRoleActor)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actor_RoleActor_Actor");

                entity.HasOne(d => d.RoleActor)
                    .WithMany(p => p.ActorRoleActor)
                    .HasForeignKey(d => d.RoleActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actor_RoleActor_RoleActor");
            });

            modelBuilder.Entity<Challenge>(entity =>
            {
                entity.Property(e => e.ChallengeId)
                    .HasColumnName("ChallengeID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ChallengeName).HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndTime).HasMaxLength(50);

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.StartTime).HasMaxLength(50);
            });

            modelBuilder.Entity<ChallengeActor>(entity =>
            {
                entity.ToTable("Challenge_Actor");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActorId)
                    .IsRequired()
                    .HasColumnName("ActorID")
                    .HasMaxLength(50);

                entity.Property(e => e.ChallengeId)
                    .IsRequired()
                    .HasColumnName("ChallengeID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ChallengeActor)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Challenge_Actor_Actor");

                entity.HasOne(d => d.Challenge)
                    .WithMany(p => p.ChallengeActor)
                    .HasForeignKey(d => d.ChallengeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Challenge_Actor_Challenge");
            });

            modelBuilder.Entity<ChallengeActorIdRoleActorId>(entity =>
            {
                entity.ToTable("Challenge_ActorID_RoleActorID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActorId)
                    .HasColumnName("ActorID")
                    .HasMaxLength(50);

                entity.Property(e => e.ChallengeId)
                    .HasColumnName("ChallengeID")
                    .HasMaxLength(50);

                entity.Property(e => e.RoleActorId)
                    .HasColumnName("RoleActorID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ChallengeActorIdRoleActorId)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_Challenge_ActorID_RoleActorID_Actor");

                entity.HasOne(d => d.Challenge)
                    .WithMany(p => p.ChallengeActorIdRoleActorId)
                    .HasForeignKey(d => d.ChallengeId)
                    .HasConstraintName("FK_Challenge_ActorID_RoleActorID_Challenge");

                entity.HasOne(d => d.RoleActor)
                    .WithMany(p => p.ChallengeActorIdRoleActorId)
                    .HasForeignKey(d => d.RoleActorId)
                    .HasConstraintName("FK_Challenge_ActorID_RoleActorID_RoleActor");
            });

            modelBuilder.Entity<ChallengeTool>(entity =>
            {
                entity.ToTable("Challenge_Tool");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ChallengeId)
                    .IsRequired()
                    .HasColumnName("ChallengeID")
                    .HasMaxLength(50);

                entity.Property(e => e.ToolId)
                    .IsRequired()
                    .HasColumnName("ToolID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Challenge)
                    .WithMany(p => p.ChallengeTool)
                    .HasForeignKey(d => d.ChallengeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Challenge_Tool_Challenge");

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.ChallengeTool)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Challenge_Tool_Tool");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("RoleID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_Role");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RoleActor>(entity =>
            {
                entity.Property(e => e.RoleActorId)
                    .HasColumnName("RoleActorID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.File).IsRequired();

                entity.Property(e => e.RoleActorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.Property(e => e.ToolId)
                    .HasColumnName("ToolID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
