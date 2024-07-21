using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T Data, string message) : base(Data, message, false)
        {

        }
        public ErrorDataResult(T Data) : base(Data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, message, false)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
