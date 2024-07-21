using Core.DataAccess.EntityFramework;
using Enitites.Concarete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    internal interface ICustomerDal:IEntityRepositoryBase<Customer>
    {
    }
}
