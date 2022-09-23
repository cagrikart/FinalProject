using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, true, message)
        {

        }
        public ErrorDataResult(T data) : base(data, true)
        {
        }

        public ErrorDataResult(T data, bool success) : base(data, success)
        {
        }

        public ErrorDataResult(string message) : base(default, true, message)
        {
        }
        public ErrorDataResult() : base(default, true)
        {

        }
    }
}
