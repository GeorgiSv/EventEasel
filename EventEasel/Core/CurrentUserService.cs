namespace EventEasel.Core
{
    using System.Security.Claims;

    public class CurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;
        }

        public string GetName()
            => this.user
            ?.Identity
            ?.Name;

        public string GetId()
            => this.user?
            .Claims
            .FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)
            ?.Value;
    }
}
