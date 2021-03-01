using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Dtos;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Security.JWT;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);

        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);

        

        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
