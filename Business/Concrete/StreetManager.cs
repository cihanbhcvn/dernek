using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StreetManager : IStreetService
    {
        private IStreetDal _streetDal;

        public StreetManager(IStreetDal streetDal)
        {
            _streetDal = streetDal;
        }
        public IResult Add(Street street)
        {
            try
            {
                _streetDal.Add(street);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new SuccessResult();

        }

        public IResult Delete(Street street)
        {
            _streetDal.Delete(street);
            return new SuccessResult();
        }

        public IDataResult<List<Street>> GetAll()
        {
            return new SuccessDataResult<List<Street>>(_streetDal.GetList().ToList());
        }

        public IDataResult<Street> GetById(int id)
        {
            return new SuccessDataResult<Street>(_streetDal.Get(x => x.Id == id));
        }

        public IResult Update(Street street)
        {
            _streetDal.Update(street);
            return new SuccessResult();
        }
    }
}
