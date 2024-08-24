using Core.Entities;

namespace Entities.Concrete
{
    public class PersonalInformation : IEntity
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string TCNumber { get; set; }
        public string Gender { get; set; }
        public string MembershipStatus { get; set; }
        public string MarriageStatus { get; set; }
        public int BloodTypeId { get; set; }
        public int DriverLicenseId { get; set; }
        public virtual Address Address { get; set; }

    }
}
