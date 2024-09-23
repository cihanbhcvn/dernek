using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class DernekContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Dernek;Trusted_Connection=true;TrustServerCertificate=True");
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<Management> Managements { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighbourhood> Neighborhoods { get; set; }
        public DbSet<Street> Streets { get; set; }


        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }



        #region AuthenticationAuthorization

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        #endregion AuthenticationAuthorization

    }
}
