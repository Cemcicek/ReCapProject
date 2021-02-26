using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
