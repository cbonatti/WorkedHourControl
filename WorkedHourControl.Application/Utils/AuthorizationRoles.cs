using Microsoft.AspNetCore.Authorization;
using System.Linq;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils
{
    public class AuthorizationRoles : AuthorizeAttribute
    {
        public AuthorizationRoles(params Profile[] roles)
        {
            var allowedRoles = roles.Select(x => x.Description());
            Roles = string.Join(",", allowedRoles);
        }
    }
}
