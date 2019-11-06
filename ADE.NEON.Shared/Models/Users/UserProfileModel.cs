using ADE.NEON.Shared.Models.Address;
using System;

namespace ADE.NEON.Shared.Models.Users
{
    public class UserProfileModel
    {
        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public virtual UserModel User { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string AvatarUrl { get; set; }
        public virtual AddressModel Address { get; set; }
        public long AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
