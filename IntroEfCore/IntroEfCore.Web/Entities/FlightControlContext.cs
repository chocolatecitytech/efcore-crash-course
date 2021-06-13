using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IntroEfCore.Web.Entities
{
    public partial class FlightControlContext : DbContext
    {
        public FlightControlContext()
        {
        }

        public FlightControlContext(DbContextOptions<FlightControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DiscountType> DiscountTypes { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightDetail> FlightDetails { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Name=ConnectionStrings:FlightControlDbContext");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_CreditCard");

                entity.Property(e => e.Key).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Expires).HasColumnType("date");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CreditCard_Passenger");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key).ValueGeneratedNever();
            });

            modelBuilder.Entity<DiscountType>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_DiscountType");

                entity.Property(e => e.Key).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Arrival).HasColumnType("datetime");

                entity.Property(e => e.Departure).HasColumnType("datetime");

                entity.Property(e => e.FlightName).HasMaxLength(500);

                entity.Property(e => e.FromLocation)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ToLocation)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<FlightDetail>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key).ValueGeneratedNever();

                entity.Property(e => e.ChiefPilot)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SecondaryPilot).HasMaxLength(100);

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightDetails)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlightDetails_Flights");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_Passenger");

                entity.Property(e => e.Key).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_FlightId");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Passengers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
