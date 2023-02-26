﻿namespace Domain.Shared
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
    }
}
