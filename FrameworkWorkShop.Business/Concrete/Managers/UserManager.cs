using FrameworkWorkShop.Business.Abstract;
using FrameworkWorkShop.DataAccess.Abstract;
using FrameworkWorkShop.Entities.ComplexType;
using FrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public User GetByUserNameAndPassword(string userName, string passsword)
        {
            return _userDal.SingleOrDefault(u => u.UserName == userName && u.Password == passsword);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
