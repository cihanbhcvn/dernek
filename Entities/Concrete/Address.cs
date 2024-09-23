using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Address : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int StreetId { get; set; }
        public string? DoorNumber { get; set; }
        public string? Floor { get; set; }
        public string? BuildingName { get; set; } = null;
    }
}
