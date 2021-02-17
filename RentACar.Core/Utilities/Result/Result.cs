namespace RentACar.Core.Utilities.Result
{
    /// <summary>
    /// Base class for response model
    /// </summary>
    public class Result:IResult
    {
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            IsSuccess = success;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
