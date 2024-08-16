using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonalInformationManager : IPersonalInformationService
    {
        private IPersonalInformationDal _personalInformationDal;

        public PersonalInformationManager(IPersonalInformationDal personalInformationDal)
        {
            _personalInformationDal = personalInformationDal;
        }
        public IResult Add(PersonalInformation personalInformation)
        {
            try
            {
                _personalInformationDal.Add(personalInformation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new SuccessResult();

        }

        public IResult Delete(PersonalInformation personalInformation)
        {
            _personalInformationDal.Delete(personalInformation);
            return new SuccessResult();
        }

        public IDataResult<List<PersonalInformation>> GetAll()
        {
            return new SuccessDataResult<List<PersonalInformation>>(_personalInformationDal.GetList().ToList());
        }

        public IDataResult<PersonalInformation> GetById(int id)
        {
            return new SuccessDataResult<PersonalInformation>(_personalInformationDal.Get(x => x.Id == id));
        }

        public IResult Update(PersonalInformation personalInformation)
        {
            _personalInformationDal.Update(personalInformation);
            return new SuccessResult();
        }
    }
}
