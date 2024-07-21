using Core.DataAccess.EntityFramework;
using Core.Enitities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EFEntityRepositoryBase<NortwindContext, User>, IUserDal
    {
        public List<OparationClaim> GetClaims(User user)
        {
            using (var context = new NortwindContext())
            {
                var result = from operationClaim in context.OparationClaims
                             join userOperationClaim in context.UserOparationClaims
                                 on operationClaim.Id equals userOperationClaim.OparationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OparationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
