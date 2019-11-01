using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Models
{
    public class EventModel
    {
        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long StatusId { get; set; }
        public AddressModel Address { get; set; }
        public long? VenueId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestOpenDate { get; set; }
        public DateTime RequestCloseDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
