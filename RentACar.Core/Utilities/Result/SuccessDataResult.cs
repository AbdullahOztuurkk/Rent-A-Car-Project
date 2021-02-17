namespace RentACar.Core.Utilities.Result
{
    /// <summary>
    /// Success data result response
    /// </summary>
    /// <typeparam name="T">any object</typeparam>
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }

        public SuccessDataResult(T data) : base(data, true)
        {
        }
        public SuccessDataResult(string message) : base(default, true,message)
        {
        }
        public SuccessDataResult() : base(default, true)
        {
        }
    }
}
