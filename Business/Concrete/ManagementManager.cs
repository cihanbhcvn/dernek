using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ManagementManager : IManagementService
    {
        public IResult Add(Management entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Management entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Management>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Management> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Management entity)
        {
            throw new NotImplementedException();
        }
    }
}
