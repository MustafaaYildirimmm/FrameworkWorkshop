using FrameworkWorkShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public int Role_Id { get; set; }
        public int User_Id { get; set; }
    }
}
