using System.Text.Json.Serialization;
using RentACar.Core.Entities;
using RentACar.Core.Entities.Concrete;

namespace RentACar.Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relations
        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
    }
}
