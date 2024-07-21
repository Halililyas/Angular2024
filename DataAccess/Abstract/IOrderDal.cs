using Core.DataAccess.EntityFramework;
using Core.Enitities;
using Enitites.Concarete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepositoryBase<Order>
    {
    }
}
