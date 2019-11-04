using ADE.NEON.Shared.Models.Address;

namespace ADE.NEON.Shared.Models.Users
{
    public class UserProfileModel
    {
        public UserModel User { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string AvatarUrl { get; set; }
        public AddressModel Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
