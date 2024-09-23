using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DriverLicenseManager : IDriverLicenseService
    {
        public IResult Add(DriverLicense entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DriverLicense entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<DriverLicense>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<DriverLicense> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(DriverLicense entity)
        {
            throw new NotImplementedException();
        }
    }
}
