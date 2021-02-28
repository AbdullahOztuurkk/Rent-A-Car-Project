using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Result;
using RentACar.Core.Utilities.Security.JWT;
using RentACar.Entities.Dtos;

namespace RentACar.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
