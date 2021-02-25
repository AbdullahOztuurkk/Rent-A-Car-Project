using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Utilities.Result;

namespace RentACar.Core.Utilities.Business
{
    /// <summary>
    /// General Business Rules Validator 
    /// </summary>
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.IsSuccess)
                    return logic;
            }
            return null;
        }
    }
}
