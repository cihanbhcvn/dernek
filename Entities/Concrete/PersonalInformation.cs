using Core.Entities;

namespace Entities.Concrete
{
    public class PersonalInformation : IEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int AddressId { get; set; }
        public string TCNumber { get; set; }
        public string Gender { get; set; }
        public string MarriageStatus { get; set; }
        public string BloodType { get; set; }
        public string DrivingLicense { get; set; }
        public virtual Member Member { get; set; }
        public virtual Address Address { get; set; }

    }
}
