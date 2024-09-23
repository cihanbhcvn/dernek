using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPersonalInformationService : IGenericService<PersonalInformation>
    {
        IResult AddTransactionalTest(PersonalInformation personalInformation);
    }
}
