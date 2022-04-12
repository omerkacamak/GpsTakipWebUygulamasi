using Microsoft.EntityFrameworkCore;
using proje.entity;

namespace proje.data.Concrete.EfCore
{
    public class ProjeContext:DbContext
    {
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Araba> Arabas { get; set; }
       public DbSet<KullaniciArabalari> KullaniciArabalaris { get; set; }
        public DbSet<KullaniciGiris> KullaniciGirises { get; set; }
         public DbSet<KullaniciCikis> KullaniciCikises { get; set; }
       
        

           

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=projeDb");
           // optionsBuilder.UseMySQl(@"server=localhost;port=3306;database=ProjeDb;user=root;password=1905;");
           // optionsBuilder.UseMySQL(@"server=localhost;port=3306;database=ProjeDb;user=root;password=1905;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KullaniciArabalari>()
            .HasKey(c=>new{c.ArabaId,c.KullaniciId});
             
             modelBuilder.Entity<KullaniciGiris>()
            .HasKey(c=>new{c.KullaniciId});
           
            modelBuilder.Entity<KullaniciCikis>()
            .HasKey(c=>new{c.KullaniciId});


            

            //  modelBuilder.Entity<ArabaYollari>()
            //  .HasKey(c=>new{c.ArabaId});
             
           
             


            // modelBuilder.Entity<Araba>()
            // .HasKey(c=>new{c.KullaniciId});
            
        }

    }
}