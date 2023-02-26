namespace Domain.Shared
{
    public class Result
    {
        protected internal Result(bool isSuccess, Error error) 
        {
            if (!(isSuccess ^ error == Error.None))
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; private set; } 
        public Error Error { get; private set; }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

        public static Result<T> Success<T>(T value) => new(value, true, Error.None);
        public static Result<T> Failure<T>(Error error, T value = default) => new(value, false, error);
    }
}
