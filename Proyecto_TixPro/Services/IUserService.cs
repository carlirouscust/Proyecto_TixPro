using System.Security.Claims;

namespace Proyecto_TixPro.Services;

public interface IUserService
{
    ClaimsPrincipal? GetCurrentUser();
}
public class UserService : IUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public ClaimsPrincipal? GetCurrentUser()
    {
        return _contextAccessor.HttpContext?.User;
    }
}