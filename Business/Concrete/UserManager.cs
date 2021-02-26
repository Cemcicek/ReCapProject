using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal  _userDal;

        public UserManager(IUserDal userDal)
        {

            _userDal = userDal;

        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Message.RentalAdded);
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
