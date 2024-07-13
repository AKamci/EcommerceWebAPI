namespace Ecommerce.API.Infrastructure
{
    public class Result<T>
    {
        private Result(T value, bool isSuccess, string message)
        {
            Value = value;
            IsSuccess = isSuccess;
            Message = message;
        }

        public T Value { get; }

        public string Message { get; set; }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public static Result<T> Success(T value, string message) => new(value,true, message);

        public static Result<T> Success(T value) => new(value, true, default);

        public static Result<T> Failure(string message) => new(default, false, message);
    }
}
