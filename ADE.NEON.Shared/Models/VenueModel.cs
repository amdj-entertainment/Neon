using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Models
{
    public class VenueModel
    {
        public string Name { get; set; }
        public AddressModel Address { get; set; }
        public int Rating { get; set; }
        public UserProfileLimitedModel ContactUser { get; set; }
    }
}
