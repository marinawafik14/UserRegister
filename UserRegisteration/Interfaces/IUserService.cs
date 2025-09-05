using UserRegisteration.DTOs;
using UserRegisteration.Entities;

namespace UserRegisteration.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseDto> RegisterAsync (RegisterUserDto dto);
        Task<AuthResponseDto> LoginAsync(LoginUserDto dto);
    }
}
