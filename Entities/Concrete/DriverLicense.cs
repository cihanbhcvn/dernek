using Core.Entities;

namespace Entities.Concrete
{
    public class DriverLicense:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonalInformationId { get; set; }

    }
}
