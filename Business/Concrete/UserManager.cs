using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }



        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<User> Get(int id)
        {

            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));

            //User user = _userDal.Get(p => p.Id == id);
            //if (user == null)
            //{
            //    return new ErrorDataResult<User>(Message.UserNotFound);
            //}
            //else
            //{
            //    return new SuccessDataResult<User>(user);
            //}
        }

        public IDataResult<List<User>> GetAll()
        {
            List<User> users = _userDal.GetAll();
            if (users.Count == 0)
            {
                return new ErrorDataResult<List<User>>(Message.UserNotFound);
            }
            else
            {
                return new SuccessDataResult<List<User>>(users);
            }
        }

        public IDataResult<User> GetByEmail(string email)
        {
            User user = _userDal.Get(p => p.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }
            else
            {
                return new SuccessDataResult<User>(user);
            }
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }



        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult();
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Message.UserRegistered);
        }

        
    }
}
