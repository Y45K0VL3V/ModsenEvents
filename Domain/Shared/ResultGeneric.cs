namespace Domain.Shared
{
    public class Result<T> : Result
    {
        public Result(T? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        private readonly T? _value;
        public T Value => IsSuccess 
            ? _value 
            : throw new InvalidOperationException("Value of failure can't be accepted."); 
    }
}
