using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Core.Entities.Concrete
{
    /// <summary>
    /// A claim class for each project operations
    /// </summary>
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
