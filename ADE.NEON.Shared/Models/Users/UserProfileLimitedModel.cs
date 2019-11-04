namespace ADE.NEON.Shared.Models.Users
{
    public class UserProfileLimitedModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
