using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NeighbourhoodManager : INeighbourhoodService
    {
        private INeighbourhoodDal _neighbourhoodDal;

        public NeighbourhoodManager(INeighbourhoodDal neighbourhoodDal)
        {
            _neighbourhoodDal = neighbourhoodDal;
        }
        public IResult Add(Neighbourhood neighbourhood)
        {
            try
            {
                _neighbourhoodDal.Add(neighbourhood);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new SuccessResult();

        }

        public IResult Delete(Neighbourhood neighbourhood)
        {
            _neighbourhoodDal.Delete(neighbourhood);
            return new SuccessResult();
        }

        public IDataResult<List<Neighbourhood>> GetAll()
        {
            return new SuccessDataResult<List<Neighbourhood>>(_neighbourhoodDal.GetList().ToList());
        }

        public IDataResult<Neighbourhood> GetById(int id)
        {
            return new SuccessDataResult<Neighbourhood>(_neighbourhoodDal.Get(x => x.Id == id));
        }

        public IResult Update(Neighbourhood neighbourhood)
        {
            _neighbourhoodDal.Update(neighbourhood);
            return new SuccessResult();
        }
    }
}
