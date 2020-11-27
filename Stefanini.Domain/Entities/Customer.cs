using Stefanini.Domain.Entities.Base;
using System;

namespace Stefanini.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }
        public DateTime? LastPurchase { get; set; }
        public int? ClassificationId { get; set; }
        public virtual Classification Classification { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }

}
