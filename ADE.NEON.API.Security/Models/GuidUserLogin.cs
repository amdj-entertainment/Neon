using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ADE.NEON.API.Security.Models
{
    public class GuidUserLogin : IdentityUserLogin<Guid> { }
}