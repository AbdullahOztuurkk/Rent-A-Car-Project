using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Core.Utilities.Result
{
    /// <summary>
    /// Base data response model
    /// </summary>
    public interface IDataResult<T>:IResult
    {
        public T Data { get; }
    }
}
