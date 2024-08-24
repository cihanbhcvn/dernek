using Business.Abstract;
using Business.CCS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class PersonalInformationManager : IPersonalInformationService
    {
        #region CTOR


        private readonly IPersonalInformationDal _personalInformationDal;
        private readonly ILogger _logger;


        public PersonalInformationManager(IPersonalInformationDal personalInformationDal)
        {
            _personalInformationDal = personalInformationDal;
        }


        #endregion CTOR

        #region Endpoints 


        [ValidationAspect(typeof(PersonalInformationValidator))]
        public IResult Add(PersonalInformation personalInformation)
        {
            var result = BusinessRules.Run();
            if(true /*result*/) // İş kuralları
            {
                _personalInformationDal.Add(personalInformation);
                return new SuccessResult();
            }
            

            //return new ErrorResult(result.Message);
        }

        public IResult Update(PersonalInformation personalInformation)
        {
            _personalInformationDal.Update(personalInformation);
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


        #endregion Endpoints

        #region BusinessRules
        // In order to run these rules in BusinessRules.Run() method, they must return IResult
        
        private IResult Example()
        {
            return new SuccessResult();
        }

        #endregion BusinessRules
    }
}