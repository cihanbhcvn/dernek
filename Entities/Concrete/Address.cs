using Core.Entities;

namespace Entities.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int StreetId { get; set; }
        public string? ApartmentName { get; set; } = null;
        public string? Floor { get; set; }
        public string? DoorNumber { get; set; }


    }
}
