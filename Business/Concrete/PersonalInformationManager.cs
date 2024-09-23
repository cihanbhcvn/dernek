using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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


        public PersonalInformationManager(IPersonalInformationDal personalInformationDal)
        {
            _personalInformationDal = personalInformationDal;
        }


        #endregion CTOR

        #region Endpoints 

        [SecuredOperation("admin,personalInformation.add")]
        [ValidationAspect(typeof(PersonalInformationValidator))]
        [CacheRemoveAspect("IPersonalInformationService.Get")]
        public IResult Add(PersonalInformation personalInformation)
        {
            var result = BusinessRules.Run();
            if (true /*result*/) // İş kuralları
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

        [CacheAspect]
        public IDataResult<List<PersonalInformation>> GetAll()
        {
            return new SuccessDataResult<List<PersonalInformation>>(_personalInformationDal.GetList().ToList());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<PersonalInformation> GetById(int id)
        {
            return new SuccessDataResult<PersonalInformation>(_personalInformationDal.Get(x => x.Id == id));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(PersonalInformation personalInformation)
        {
            throw new NotImplementedException();
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