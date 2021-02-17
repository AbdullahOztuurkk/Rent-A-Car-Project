namespace RentACar.Core.Utilities.Result
{
    /// <summary>
    /// Error data result response
    /// </summary>
    /// <typeparam name="T">any object</typeparam>

    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }
        public ErrorDataResult(T data) : base(data, false)
        {
        }
        public ErrorDataResult(string message) : base(default, false,message)
        {
        }
        public ErrorDataResult() : base(default,false)
        {
        }
    }
}
