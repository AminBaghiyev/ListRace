using ListRace.BL.DTOs;

namespace ListRace.BL.Services.Abstractions;

public interface IAccountService
{
    Task RegisterAsync(UserRegisterDTO dto);
    Task LoginAsync(UserLoginDTO dto);
    Task LogoutAsync();
}
