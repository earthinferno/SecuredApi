using SessionService.Models;

namespace SessionService
{
    public interface IUserSession
    {
        SessionProfile GetSessionProfile();
    }
}