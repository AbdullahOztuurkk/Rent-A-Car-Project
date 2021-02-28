using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Core.Entities.Concrete
{
    /// <summary>
    /// A relation class between User and OperationClaim
    /// </summary>
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
