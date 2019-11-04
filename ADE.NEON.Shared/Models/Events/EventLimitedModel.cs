using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Models.Events
{
    public class EventLimitedModel
    {
        public string Title { get; set; }
        public long StatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestOpenDate { get; set; }
        public DateTime RequestCloseDate { get; set; }
    }
}
