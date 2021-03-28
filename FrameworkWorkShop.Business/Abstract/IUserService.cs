using FrameworkWorkShop.Entities.ComplexType;
using FrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserNameAndPassword(string userName, string passsword);
        List<UserRoleItem> GetUserRoles(User user);
    }
}
