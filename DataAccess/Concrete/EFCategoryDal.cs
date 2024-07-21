using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Enitites.Concarete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EFCategoryDal:EFEntityRepositoryBase<NortwindContext,Category>,ICategoryDal
    {

    }
}
