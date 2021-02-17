namespace RentACar.Core.Utilities.Result
{
    /// <summary>
    /// Errpr Response model
    /// </summary>
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}
