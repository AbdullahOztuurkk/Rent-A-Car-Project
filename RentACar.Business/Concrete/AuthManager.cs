using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Result;
using RentACar.Core.Utilities.Security.Hashing;
using RentACar.Core.Utilities.Security.JWT;
using RentACar.Entities.Dtos;

namespace RentACar.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public string User_Successful_Login { get; private set; }

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        /// <summary>
        /// Sign Up
        /// </summary>
        /// <returns>User</returns>
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.User_Register_Message);
        }
        /// <summary>
        /// Sıgn In
        /// </summary>
        /// <returns>User</returns>
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.User_Not_Found);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.User_Password_Doesnt_Match);
            }

            return new SuccessDataResult<User>(userToCheck, User_Successful_Login);
        }
        /// <summary>
        /// Check the email if it exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.User_Already_Exist);
            }
            return new SuccessResult();
        }
        /// <summary>
        /// Generate Access Token from user informations
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Token Response</returns>
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.User_Token_Created);
        }
    }
}
