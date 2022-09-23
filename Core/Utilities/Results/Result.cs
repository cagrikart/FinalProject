using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        

        public Result(bool success, string messeage):this(success)
        {
            Message= messeage;
        }

        public Result(bool success)
        {
            Success = success;
        }

        bool Success { get; }

        string Message { get; }

        bool IResult.Success => throw new NotImplementedException();
        string IResult.Message => throw new NotImplementedException();
    }
}
