using Bageriet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Context
{
    public class DBContext : IdentityDbContext<Users>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }


        public DbSet<Contacts> contacts { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Comments> comments { get; set; }
        public DbSet<Ratings> rating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>(b => { b.ToTable("Users"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(b => { b.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(b => { b.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityUserToken<string>>(b => { b.ToTable("UserTokens"); });
            modelBuilder.Entity<IdentityRole>(b => { b.ToTable("Roles"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(b => { b.ToTable("RoleClaims"); });
            modelBuilder.Entity<IdentityUserRole<string>>(b => { b.ToTable("UserRoles"); });

           // //seed contacts
           // modelBuilder.Entity<Contacts>().HasData(
           //         new Contacts
           //         {
           //             Id = 1,
           //             Title = "Kontakt information",
           //             Address = "Supergatan 100",
           //             City = "Växjö",
           //             Zip = "350 00",
           //             Phone = "0470-707000",
           //             Email = "bageri_vaxjo@bv.se",
           //             Visible = true
           //         }
           //);

           // // seed products
           // modelBuilder.Entity<Products>().HasData(
           //         new Products(1, "Baguette", "Baguette är ett franskt vitt matbröd innehållande vetemjöl, vatten, jäst och salt, som med sin avlånga form och frasiga yta blivit en fransk symbol. Brödet är känsligt för uttorkning och bör därför ätas inom ett dygn efter bakning", "baguette.png", true),
           //         new Products(2, "Småfranska", "Småfranska eller fralla är ett mindre och ofta runt franskbröd. Liknande bröd i de svenskspråkiga delarna av Finland heter semla, men bakas med inslag av bland annat fullkornsmjöl. I Skåne kallas småfranska i regel för bulle eller franskbrödsbulle för att skilja från vanliga söta bullar", "smafranska.png", true),
           //         new Products(3, "Croissant", "Croissant [kroasaŋ´] är ett bakverk av smördeg format i en halvmåne ofta förknippat med Frankrike. Croissanter är i grunden en fransk version av giffel och har en slående likhet med vissa typer av sådana. Namnet croissant är franskt och kommer från ordet croître, med betydelsen växa.", "croissant.png", true),
           //         new Products(4, "Korvbröd", "Korvbröd är ett avlångt, decimeterlångt mjukt bröd bakat av vetemjöl. I brödet skärs en längsgående skåra som är avsedd att ge plats för en varm korv och måltiden kallas på svenska vanligen korv med bröd och internationellt hot dog. Industriellt tillverkade korvbröd brukar vara färdigskurna.", "korvbrod.png", true),
           //         new Products(5, "Pannkaka", "Pannkaka är en maträtt som gräddas i en pannkakslagg eller stekpanna på spisplattan, vissa varianter i en långpanna i ugnen. Standardingredienserna är ägg, vetemjöl och mjölk samt matfett och salt. I Sverige äts pannkaka traditionellt som efterrätt till ärtsoppa på torsdagar", "pannkaka.png", true),
           //         new Products(6, "Wienerbröd", "Wienerbröd är ett bakverk som i grunden består av wienerdeg, som blir luftig och frasig vid bakning. Det finns i många varianter med olika fyllningar och garnityr.", "wienerbrod.png", true)
           // );

           // //seed products
           // modelBuilder.Entity<IdentityRole>().HasData(
           //         new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
           //         new IdentityRole { Name = "User", NormalizedName = "USER" }
           //         );
        }
    }
}
