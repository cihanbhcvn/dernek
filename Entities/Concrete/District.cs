using Core.Entities;

namespace Entities.Concrete
{
    public class District: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int CityCode { get; set; }

    }


}
