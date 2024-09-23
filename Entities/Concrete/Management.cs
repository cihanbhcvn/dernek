using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Management : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
