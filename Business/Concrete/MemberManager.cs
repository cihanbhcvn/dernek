using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;

        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }
        public IResult Add(Member member)
        {
            try
            {
                _memberDal.Add(member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new SuccessResult();

        }

        public IResult Delete(Member member)
        {
            _memberDal.Delete(member);
            return new SuccessResult();
        }

        public IDataResult<List<Member>> GetAll()
        {
            return new SuccessDataResult<List<Member>>(_memberDal.GetList().ToList());
        }

        public IDataResult<Member> GetById(int id)
        {
            return new SuccessDataResult<Member>(_memberDal.Get(x => x.Id == id));
        }

        public IResult Update(Member member)
        {
            _memberDal.Update(member);
            return new SuccessResult();
        }
    }
}
