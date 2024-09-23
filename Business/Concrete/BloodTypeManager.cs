using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BloodTypeManager : IBloodTypeService
    {
        private IBloodTypeDal _bloodTypeDal;

        public BloodTypeManager(IBloodTypeDal bloodTypeDal)
        {
            _bloodTypeDal = bloodTypeDal;
        }
        public IResult Add(BloodType bloodType)
        {
            try
            {
                _bloodTypeDal.Add(bloodType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new SuccessResult();

        }

        public IResult Delete(BloodType bloodType)
        {
            _bloodTypeDal.Delete(bloodType);
            return new SuccessResult();
        }

        public IDataResult<List<BloodType>> GetAll()
        {
            return new SuccessDataResult<List<BloodType>>(_bloodTypeDal.GetList().ToList());
        }

        public IDataResult<BloodType> GetById(int id)
        {
            return new SuccessDataResult<BloodType>(_bloodTypeDal.Get(x => x.Id == id));
        }

        public IResult Update(BloodType bloodType)
        {
            _bloodTypeDal.Update(bloodType);
            return new SuccessResult();
        }
    }
}
