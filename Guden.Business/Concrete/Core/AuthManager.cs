using System;
using System.Collections.Generic;
using System.Linq;
using Guden.Business.Abstract;
using Guden.Business.Abstract.Core;
using Guden.Core.Contants;
using Guden.Core.Entities.Concrete.Core;
using Guden.Core.Utilities.Hashing;
using Guden.Core.Utilities.Results;
using Guden.Core.Utilities.Security.Jwt;
using Guden.DataAccess.Abstract.Core;
using Guden.Entities.Dtos;

namespace Guden.Business.Concrete.Core
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimDal _userOperationClaims;
        private IOperationClaimDal _operationClaimDal;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimDal userOperationClaims,IOperationClaimDal operationClaimDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaims = userOperationClaims;
            _operationClaimDal = operationClaimDal;
        }
        public IDataResult<Core_User> Register(UserForRegisterDto userForRegisterDto)
        {
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte [] passwordHash,out byte []passwordSalt);
            var user = new Core_User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                BirthDate = userForRegisterDto.BirthDate,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                RegDate = DateTime.Now, 
                Status = true
            };
            _userService.Add(user);


            foreach(var operationClaimId in userForRegisterDto.OperationClaimIds.Split(","))
            {
                if(int.TryParse(operationClaimId,out int value))
                {
                    _userOperationClaims.Add( new Core_UserOperationClaim()
                                            {
                                                OperationClaimId = value,
                                                UserId = user.Id
                    }
                                            );
                }

            }
             

            return new SuccessDataResult<Core_User>(user, Messages.UserRegistered);

        }

        public IDataResult<Core_User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email,null);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Core_User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Core_User>(Messages.PasswordError);
            }

            return new SuccessDataResult<Core_User>(userToCheck, Messages.SuccessfulLogin);
        }

        public Result UserExists(string email,int ?id)
        {
            if (_userService.GetByMail(email, id) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            
                return new SuccessResult("");
        }

        public IDataResult<AccessToken> CreateAccessToken(Core_User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken=_tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.SuccessfulLogin);
        }

        public IDataResult<Core_User> UpdateUser(UserForRegisterDto userForRegisterDto)
        {
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _userService.GetUserById(Convert.ToInt32(userForRegisterDto.Id)).Data;

            user.Email = userForRegisterDto.Email;
            user.FirstName = userForRegisterDto.FirstName;
            user.LastName = userForRegisterDto.LastName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.BirthDate = userForRegisterDto.BirthDate;
            user.PhoneNumber = userForRegisterDto.PhoneNumber;
            user.UpdateDate = DateTime.Now;
           
            _userService.Update(user);

            List<Core_UserOperationClaim> lastUserOperationClaimIds= _userOperationClaims.GetList(x=>x.UserId==userForRegisterDto.Id).ToList();


            foreach (var operationClaimId in userForRegisterDto.OperationClaimIds.Split(","))
            {
                if (int.TryParse(operationClaimId, out int value) && lastUserOperationClaimIds.Select(x=>x.OperationClaimId==value).Any())
                {
                    _userOperationClaims.Add(new Core_UserOperationClaim()
                    {
                        OperationClaimId = value,
                        UserId = user.Id
                    }
                                            );
                }

            }
            List<Core_UserOperationClaim> userOperationClaimIds = _userOperationClaims.GetList(x => x.UserId == userForRegisterDto.Id).ToList();
            foreach (var operationClaimId in userOperationClaimIds)
            {
                if (!userForRegisterDto.OperationClaimIds.Split(",").Contains(operationClaimId.OperationClaimId.ToString()))
                {
                    var oClaims = _userOperationClaims.Get(x => x.Id == operationClaimId.Id);
                    _userOperationClaims.Delete(oClaims);
                }

            }



            return new SuccessDataResult<Core_User>(user, Messages.UserUpdated);
        }

        public IDataResult<List<Core_OperationClaim>> GetOperationClaim()
        {
            
            return new DataResult<List<Core_OperationClaim>>(_operationClaimDal.GetList().ToList(),true);
        }
    }
}
