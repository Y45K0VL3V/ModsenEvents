using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public class Result
    {
        public Result(bool isSuccess, Error error) 
        {
            if (!(isSuccess ^ error == Error.None))
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; private set; } 
        public Error Error { get; private set; }

        public static Result Success() => new(true, Error.None);
    }
}
