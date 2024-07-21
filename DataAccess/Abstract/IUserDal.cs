using Core.DataAccess.EntityFramework;
using Core.Enitities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepositoryBase<User>
    {
        List<OparationClaim> GetClaims(User user);
    }
}
