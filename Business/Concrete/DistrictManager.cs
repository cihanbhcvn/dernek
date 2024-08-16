using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DistrictManager : IDistrictService
    {
        private IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }
        public IResult Add(District district)
        {
            try
            {
                _districtDal.Add(district);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new SuccessResult();

        }

        public IResult Delete(District district)
        {
            _districtDal.Delete(district);
            return new SuccessResult();
        }

        public IDataResult<List<District>> GetAll()
        {
            return new SuccessDataResult<List<District>>(_districtDal.GetList().ToList());
        }

        public IDataResult<District> GetById(int id)
        {
            return new SuccessDataResult<District>(_districtDal.Get(x => x.Id == id));
        }

        public IResult Update(District district)
        {
            _districtDal.Update(district);
            return new SuccessResult();
        }
    }
}
