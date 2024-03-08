using MarucciHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace MarucciHotel.Data
{
    public class MarucciHotelContext : DbContext
    {
        public MarucciHotelContext(DbContextOptions<MarucciHotelContext> options)
            : base(options)
        {
        }

        public DbSet<MarucciHotel.Models.Clienti> Clienti { get; set; } = default!;
        public DbSet<MarucciHotel.Models.Camera> Camera { get; set; } = default!;
        public DbSet<MarucciHotel.Models.Servizi> Servizi { get; set; } = default!;
        public DbSet<MarucciHotel.Models.Pensione> Pensione { get; set; } = default!;
        public DbSet<MarucciHotel.Models.Prenotazione> Prenotazione { get; set; } = default!;
        public DbSet<MarucciHotel.Models.Login> Login { get; set; } = default!;
        public DbSet<MarucciHotel.Models.CheckoutView> CheckoutView { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CheckoutView>().HasNoKey();
        }
    }
}
