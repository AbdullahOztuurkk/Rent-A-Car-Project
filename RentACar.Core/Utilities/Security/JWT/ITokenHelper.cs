using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Entities.Concrete;

namespace RentACar.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
