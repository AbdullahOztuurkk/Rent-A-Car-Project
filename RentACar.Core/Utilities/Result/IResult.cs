using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Core.Utilities.Result
{
    /// <summary>
    /// A interface for response model
    /// </summary>
    public interface IResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
