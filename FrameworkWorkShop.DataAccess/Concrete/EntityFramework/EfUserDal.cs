using FrameworkWorkShop.Core.EntityFramework;
using FrameworkWorkShop.DataAccess.Abstract;
using FrameworkWorkShop.Entities.ComplexType;
using FrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles
                             on ur.User_Id equals r.Id
                             where ur.User_Id == user.Id
                             select new UserRoleItem { RoleName = r.Name};

                return result.ToList();
            }
        }
    }
}
