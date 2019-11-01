using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Models
{
    public class UserProfileLimitedModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
