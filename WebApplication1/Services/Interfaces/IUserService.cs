using WebApplication1.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface IUserService
    {
        string Authenticate(UserDto user);
    }
}