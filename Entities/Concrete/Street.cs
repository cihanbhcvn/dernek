using Core.Entities;

namespace Entities.Concrete
{
    public class Street : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NeighborhoodCode { get; set; }
    }


}
