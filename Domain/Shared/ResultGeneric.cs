using System.Runtime.InteropServices;

namespace Domain.Shared
{
    public class Result<T> : Result
    {
        protected internal Result(T? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        private readonly T? _value;
        public T Value => IsSuccess 
            ? _value 
            : throw new InvalidOperationException("Value of failure can't be accessed."); 

        //public static implicit operator Result<T>(T? value) => 
    }
}
