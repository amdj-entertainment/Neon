using ADE.NEON.Shared.Models.Address;
using ADE.NEON.Shared.Models.Users;

namespace ADE.NEON.Shared.Models.Venues
{
    public class VenueModel
    {
        public string Name { get; set; }
        public AddressModel Address { get; set; }
        public int Rating { get; set; }
        public UserProfileLimitedModel ContactUser { get; set; }
    }
}
