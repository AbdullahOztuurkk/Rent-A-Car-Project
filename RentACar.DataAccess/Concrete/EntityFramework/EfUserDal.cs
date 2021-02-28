using System.Collections.Generic;
using System.Linq;
using RentACar.Core.DataAccess;
using RentACar.Core.Entities.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        /// <summary>
        /// Get All claims by User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
