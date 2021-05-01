using System;
using System.Collections.Generic;
using Guden.Business.Abstract;
using Guden.Core.Entities.Concrete.Core;
using Guden.Core.Utilities.Results;
using Guden.DataAccess.Abstract.Core;

namespace Guden.Business.Concrete.Core
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public List<Core_OperationClaim> GetClaims(Core_User user)
        {
            return _userDal.GetClaims(user);
        }

        public Core_User Add(Core_User user)
        { 
            _userDal.Add(user);
            return user;
        }

        public Core_User GetByMail(string email,int ? Id)
        {
            if(Id == null)
                return _userDal.Get(u => u.Email == email);
            else
                return _userDal.Get(u => u.Email == email && u.Id != Id);
        }

        public IDataResult<Core_User> GetUserById(int userId)
        {
            return new SuccessDataResult<Core_User>(_userDal.Get(p => p.Id == userId));
        }

        public void Update(Core_User user)
        {
            _userDal.Update(user);
        }
    }
}
